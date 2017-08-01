﻿using AutoMapper;
using CmsEngine.Data.AccessLayer;
using CmsEngine.Data.EditModels;
using CmsEngine.Data.Models;
using CmsEngine.Data.ViewModels;
using CmsEngine.Extensions;
using CmsEngine.Utils;
using System;
using System.Linq;

namespace CmsEngine.Services
{
    public class PostService : BaseService<Post>
    {
        public PostService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public override ReturnValue BulkDelete(Guid[] id)
        {
            var returnValue = new ReturnValue();
            try
            {
                Repository.BulkUpdate(q => id.Contains(q.VanityId), u => new Post { IsDeleted = true });

                returnValue.IsError = false;
                returnValue.Message = string.Format("Selected items deleted at {0}.", DateTime.Now.ToString("d"));
            }
            catch
            {
                returnValue.IsError = true;
                returnValue.Message = "An error has occurred while deleting the post";
                throw;
            }

            return returnValue;
        }

        public override ReturnValue Delete(Guid id)
        {
            var returnValue = new ReturnValue();
            try
            {
                var post = this.GetAll().Where(q => q.VanityId == id).FirstOrDefault();
                returnValue = this.Delete(post);
            }
            catch
            {
                returnValue.IsError = true;
                returnValue.Message = "An error has occurred while deleting the post";
                throw;
            }

            return returnValue;
        }

        public override ReturnValue Delete(int id)
        {
            var returnValue = new ReturnValue();
            try
            {
                var post = this.GetAll().Where(q => q.Id == id).FirstOrDefault();
                returnValue = this.Delete(post);
            }
            catch
            {
                returnValue.IsError = true;
                returnValue.Message = "An error has occurred while deleting the post";
                throw;
            }

            return returnValue;
        }

        public override ReturnValue Save(IEditModel editModel)
        {
            var returnValue = new ReturnValue
            {
                IsError = false,
                Message = $"Post '{((PostEditModel)editModel).Title}' saved."
            };

            try
            {
                PrepareForSaving(editModel);

                UnitOfWork.Save();
            }
            catch
            {
                returnValue.IsError = true;
                returnValue.Message = "An error has occurred while saving the post";
                throw;
            }

            return returnValue;
        }

        public override IEditModel SetupEditModel()
        {
            return new PostEditModel();
        }

        protected override IEditModel SetupEditModel(Post item)
        {
            var editModel = new PostEditModel();
            item.MapTo(editModel);

            return editModel;
        }

        protected override IViewModel SetupViewModel(Post item)
        {
            var viewModel = new PostViewModel();
            item.MapTo(viewModel);

            return viewModel;
        }

        protected override ReturnValue Delete(Post item)
        {
            var returnValue = new ReturnValue();
            try
            {
                if (item != null)
                {
                    item.IsDeleted = true;
                    Repository.Update(item);
                }

                UnitOfWork.Save();
                returnValue.IsError = false;
                returnValue.Message = string.Format("Post '{0}' deleted at {1}.", item.Title, DateTime.Now.ToString("d"));
            }
            catch
            {
                returnValue.IsError = true;
                returnValue.Message = "An error has occurred while deleting the post";
                throw;
            }

            return returnValue;
        }

        protected override void PrepareForSaving(IEditModel editModel)
        {
            var post = new Post();
            editModel.MapTo(post);

            if (post.IsNew)
            {
                Repository.Insert(post);
            }
            else
            {
                Repository.Update(post);
            }
        }
    }
}