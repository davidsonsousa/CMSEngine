using System;
using System.Threading.Tasks;
using AutoMapper;
using CmsEngine.Data.AccessLayer;
using CmsEngine.Data.EditModels;
using CmsEngine.Data.Models;
using CmsEngine.Data.ViewModels.DataTableViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CmsEngine.Ui.Areas.Cms.Controllers
{
    [Area("Cms")]
    public class WebsiteController : BaseController
    {
        private readonly IHostingEnvironment _env;

        public WebsiteController(IUnitOfWork uow, IMapper mapper, IHttpContextAccessor hca, UserManager<ApplicationUser> userManager,
                                 IHostingEnvironment env, ILogger<WebsiteController> logger) : base(uow, mapper, hca, userManager, logger)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            this.SetupMessages("Websites", PageType.List, panelTitle: "List of websites");
            //var websiteViewModel = service.SetupViewModel();
            return View("List");
        }

        public IActionResult Create()
        {
            this.SetupMessages("Website", PageType.Create, panelTitle: "Create a new website");
            var websiteEditModel = service.SetupWebsiteEditModel();

            return View("CreateEdit", websiteEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WebsiteEditModel websiteEditModel)
        {
            if (!ModelState.IsValid)
            {
                this.SetupMessages("Websites", PageType.Create, panelTitle: "Create a new website");
                return View("CreateEdit", websiteEditModel);
            }

            return this.Save(websiteEditModel);
        }

        public IActionResult Edit(Guid vanityId)
        {
            this.SetupMessages("Websites", PageType.Edit, panelTitle: "Edit an existing website");
            var websiteEditModel = service.SetupWebsiteEditModel(vanityId);

            return View("CreateEdit", websiteEditModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WebsiteEditModel websiteEditModel)
        {
            if (!ModelState.IsValid)
            {
                this.SetupMessages("Websites", PageType.Edit, panelTitle: "Edit an existing website");
                return View("CreateEdit", websiteEditModel);
            }

            var websiteToUpdate = (WebsiteEditModel)service.SetupWebsiteEditModel(websiteEditModel.VanityId);

            if (await TryUpdateModelAsync(websiteToUpdate))
            {
                return this.Save(websiteEditModel);
            }

            return View("CreateEdit", websiteEditModel);
        }

        [HttpPost]
        public IActionResult Delete(Guid vanityId)
        {
            return Ok(service.DeleteWebsite(vanityId));
        }

        [HttpPost("cms/website/bulk-delete")]
        public IActionResult BulkDelete([FromForm]Guid[] vanityId)
        {
            return Ok(service.BulkDelete<Website>(vanityId));
        }

        [HttpPost]
        public IActionResult GetData([FromForm]DataParameters parameters)
        {
            var filteredItems = service.FilterWebsite(parameters.Search.Value, service.GetAllWebsitesReadOnly<WebsiteTableViewModel>());
            var orderedItems = service.OrderWebsite(parameters.Order[0].Column, parameters.Order[0].Dir, filteredItems);

            var dataTable = service.BuildDataTable<Website>(orderedItems, parameters.Start, parameters.Length);
            dataTable.Draw = parameters.Draw;

            return Ok(dataTable);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles()
        {
            return await this.PrepareAndUploadFiles(_env.WebRootPath, "Website");
        }

        #region Helpers

        private IActionResult Save(WebsiteEditModel websiteEditModel)
        {
            var returnValue = service.SaveWebsite(websiteEditModel);

            if (!returnValue.IsError)
            {
                TempData["SuccessMessage"] = returnValue.Message;
            }
            else
            {
                return View("CreateEdit", websiteEditModel);
            }

            return RedirectToAction("Index");
        }

        #endregion

    }
}
