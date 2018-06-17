using AutoMapper;
using CmsEngine.Data.AccessLayer;
using CmsEngine.Data.Models;
using CmsEngine.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CmsEngine.Ui.Controllers
{
    public class BaseController : Controller
    {
        protected readonly CmsService service;
        protected readonly InstanceViewModel instance;

        public BaseController(IUnitOfWork uow, IMapper mapper, IHttpContextAccessor hca, UserManager<ApplicationUser> userManager)
        {
            service = new CmsService(uow, mapper, hca, userManager);
            instance = service.Instance;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            instance.PagedPosts = service.GetPostsByStatusReadOnly<PostViewModel>(DocumentStatus.Published, 4);
            instance.LatestPosts = service.GetPostsByStatusReadOnly<PostViewModel>(DocumentStatus.Published,3);
            instance.Pages = service.GetPagesByStatusReadOnly<PageViewModel>(DocumentStatus.Published);
            instance.Categories = service.GetCategoriesWithPostCount<CategoryViewModel>();
            instance.Tags = service.GetAllTagsReadOnly<TagViewModel>();
        }
    }
}
