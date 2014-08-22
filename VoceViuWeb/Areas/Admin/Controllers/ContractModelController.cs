using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoceViuWeb.Models.ContractModel;

namespace VoceViuWeb.Areas.Admin.Controllers
{
    public class ContractModelController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public JsonResult CreateContractModel(CreateContractModelRequest request)
        {
            throw new NotImplementedException();
        }

        public JsonResult UpdateContractModel(CreateContractModelRequest request, int id)
        {
            throw new NotImplementedException();
        }

        public FileResult DownloadAttachment(int id)
        {
            throw new NotImplementedException();
        }
    }
}