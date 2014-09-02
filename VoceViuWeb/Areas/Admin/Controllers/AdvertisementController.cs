using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoceViuModel.AdminContent.Messages;
using VoceViuModel.AdminContent.Services;
using VoceViuWeb.Areas.Admin.Models;
using VoceViuWeb.Filters;

namespace VoceViuWeb.Areas.Admin.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly ContentServices _contentServices;

        public AdvertisementController(ContentServices contentServices)
        {
            _contentServices = contentServices;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Manage()
        {
            return View();
        }

        [ExceptionHandler]
        public JsonResult AddContent(AddContentRequest request)
        {
            var length = request.File.ContentLength;
            var buffer = new Byte[length];
            request.File.InputStream.Read(buffer, 0, length);

            var message = new SaveContentMessage();
            message.File = buffer;
            message.FileName = request.File.FileName;
            _contentServices.Add(message);

            var result = new JsonResult();
            result.ContentType = "application/json";
            result.Data = new { Result = "Success" };
            return result;
        }
    }
}