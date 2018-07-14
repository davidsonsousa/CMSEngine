using System.Diagnostics;
using AutoMapper;
using CmsEngine.Data.AccessLayer;
using CmsEngine.Data.Models;
using CmsEngine.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CmsEngine.Ui.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork uow, IMapper mapper, IHttpContextAccessor hca, UserManager<ApplicationUser> userManager)
                       : base(uow, mapper, hca, userManager)
        {
        }

        public IActionResult Index()
        {
            return View(instance);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            instance.PageTitle = $"About - {instance.Name}";
            return View(instance);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            instance.PageTitle = $"Contact - {instance.Name}";
            return View(instance);
        }

        public IActionResult Error()
        {
            instance.PageTitle = $"Error - {instance.Name}";
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
