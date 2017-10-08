using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using CmsEngine.Attributes;
using CmsEngine.Data.AccessLayer;
using CmsEngine.Data.EditModels;
using CmsEngine.Data.Models;
using CmsEngine.Data.ViewModels;
using CmsEngine.Utils;
using Microsoft.AspNetCore.Http;

namespace CmsEngine.Services
{
    public abstract class BaseService<T> where T : BaseModel
    {
        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private Website _websiteInstance;

        #region Properties

        //public IPrincipal CurrentUser
        //{
        //    get
        //    {
        //        return _httpContextAccessor.HttpContext.User;
        //    }
        //}

        public Website WebsiteInstance
        {
            get
            {
                if (_websiteInstance == null)
                {
                    _websiteInstance = _unitOfWork.GetRepository<Website>().Get(q => q.SiteUrl == _httpContextAccessor.HttpContext.Request.Host.Host).FirstOrDefault();
                }

                return _websiteInstance;
            }
        }

        /// <summary>
        /// Repository used by the Service
        /// </summary>
        protected IRepository<T> Repository
        {
            get { return _repository; }
        }

        protected IMapper Mapper
        {
            get { return _mapper; }
        }

        /// <summary>
        /// Unit of work used by the Service
        /// </summary>
        protected IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        #endregion

        protected internal BaseService(IUnitOfWork uow, IMapper mapper, IHttpContextAccessor hca)
        {
            _repository = uow.GetRepository<T>();
            _unitOfWork = uow;
            _mapper = mapper;
            _httpContextAccessor = hca;
        }

        //public IEnumerable<T> Filter(string searchTerm, IEnumerable<T> listItems)
        //{
        //    if (!string.IsNullOrWhiteSpace(searchTerm))
        //    {
        //        var searchableProperties = typeof(T).GetProperties().Where(p => Attribute.IsDefined(p, typeof(Searchable)));
        //        List<ExpressionFilter> expressionFilter = new List<ExpressionFilter>();

        //        foreach (var property in searchableProperties)
        //        {
        //            expressionFilter.Add(new ExpressionFilter
        //            {
        //                PropertyName = property.Name,
        //                Operation = Operations.Contains,
        //                Value = searchTerm
        //            });
        //        }

        //        var lambda = ExpressionBuilder.GetExpression<T>(expressionFilter, LogicalOperators.Or).Compile();
        //        listItems = listItems.Where(lambda);
        //    }

        //    return listItems;
        //}

        //public abstract IEnumerable<T> Order(int orderColumn, string orderDirection, IEnumerable<T> listItems);

        public DataTableViewModel BuildDataTable(IEnumerable<IViewModel> listItems)
        {
            var listColumnString = new List<string> { string.Empty };
            var listDataItems = new List<DataItem>();

            foreach (var item in listItems)
            {
                // Get the properties which should appear in the DataTable
                var itemProperties = item.GetType()
                                         .GetProperties()
                                         .Where(p => Attribute.IsDefined(p, typeof(ShowOnDataTable)))
                                         .OrderBy(o => o.GetCustomAttributes(false).OfType<ShowOnDataTable>().First().Order);

                // An empty value must *always* be the first property because of the checkboxes
                var dataItem = new DataItem
                {
                    DataProperties = new List<DataProperty>
                    {
                        new DataProperty { DataType = "Boolean", DataContent = string.Empty }
                    }
                };

                // Loop through and add the properties found
                foreach (var property in itemProperties)
                {
                    var columnName = item.GetType().GetProperty(property.Name).Name;
                    if (!listColumnString.Contains(columnName))
                    {
                        listColumnString.Add(columnName);
                    }

                    dataItem.DataProperties.Add(PrepareProperty(item, property));
                }

                // VanityId must *always* be the last property
                dataItem.DataProperties.Add(
                    new DataProperty
                    {
                        DataContent = item.VanityId.ToString(),
                        DataType = "Guid"
                    });

                listDataItems.Add(dataItem);
            }

            DataTableViewModel dataTableViewModel;

            dataTableViewModel = new DataTableViewModel
            {
                Columns = listColumnString,
                Rows = listDataItems,
                RecordsTotal = this.GetAllReadOnly().Count(),
                RecordsFiltered = listItems.Count()
            };

            return dataTableViewModel;
        }

        #region Get

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        protected IQueryable<T> GetAll()
        {
            IQueryable<T> listItems;

            try
            {
                listItems = Repository.Get(q => q.IsDeleted == false);
            }
            catch
            {
                throw;
            }

            return listItems;
        }

        public abstract IEnumerable<IViewModel> GetAllReadOnly();

        public abstract IViewModel GetById(int id);

        public abstract IViewModel GetById(Guid id);

        #endregion

        #region Setup View and Edit models

        public abstract IEditModel SetupEditModel();

        public abstract IEditModel SetupEditModel(int id);

        public abstract IEditModel SetupEditModel(Guid id);

        #endregion

        public abstract ReturnValue Save(IEditModel editModel);

        public abstract ReturnValue Delete(Guid id);

        public abstract ReturnValue BulkDelete(Guid[] id);

        public abstract ReturnValue Delete(int id);

        #region Helpers

        private DataProperty PrepareProperty(IViewModel item, PropertyInfo property)
        {
            var propertyInfo = item.GetType().GetProperty(property.Name);

            var dataProperty = new DataProperty
            {
                DataContent = propertyInfo.GetValue(item)?.ToString() ?? "",
                DataType = propertyInfo.PropertyType.Name
            };


            //if (property.PropertyType.Name == "DocumentStatus")
            //{
            //    GeneralStatus generalStatus;
            //    switch (propertyValue)
            //    {
            //        case "Published":
            //            generalStatus = GeneralStatus.Success;
            //            break;
            //        case "PendingApproval":
            //            generalStatus = GeneralStatus.Warning;
            //            break;
            //        case "Draft":
            //        default:
            //            generalStatus = GeneralStatus.Info;
            //            break;
            //    }

            //    propertyValue = $"<span class=\"label label-{generalStatus.ToString().ToLowerInvariant()}\">{propertyValue.ToEnum<DocumentStatus>().GetDescription()}</status-label>" ?? "";
            //}

            return dataProperty;
        }

        protected virtual T GetItemById(int id)
        {
            T item;

            try
            {
                item = this.GetAll().Where(q => q.Id == id).FirstOrDefault();
            }
            catch
            {
                throw;
            }

            return item;
        }

        protected virtual T GetItemById(Guid id)
        {
            T item;

            try
            {
                item = this.GetAll().Where(q => q.VanityId == id).FirstOrDefault();
            }
            catch
            {
                throw;
            }

            return item;
        }

        protected abstract ReturnValue Delete(T item);

        protected abstract void PrepareForSaving(IEditModel editModel);

        #endregion
    }
}
