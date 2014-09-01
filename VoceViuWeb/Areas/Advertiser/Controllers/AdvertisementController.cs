using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoceViuModel.ServiceSolicitations.Messages;
using VoceViuModel.ServiceSolicitations.Services;
using VoceViuWeb.Areas.Advertiser.Models;
using VoceViuWeb.Filters;

namespace VoceViuWeb.Areas.Advertisers.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly AdvertisementService _advertisementService;

        public AdvertisementController(AdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        public ViewResult Index()
        {
            return View();
        }

        [ExceptionHandler]
        public JsonResult SubmitContent(SubmitContentRequest request)
        {
            var length = request.File.ContentLength;
            var buffer = new Byte[length];
            request.File.InputStream.Read(buffer,0,length);
            
            var message = new SetAdvertisementContentMessage();
            message.File = buffer;
            message.FileName = request.File.FileName;
            _advertisementService.SetContent(request.AdvertisementId, message);

            var result = new JsonResult();
            result.ContentType = "application/json";
            result.Data = new { Result = "Success" };
            return result;
        }
    }
}