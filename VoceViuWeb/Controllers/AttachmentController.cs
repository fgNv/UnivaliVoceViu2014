using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoceViuModel.ServiceSolicitations.Abstraction;
using System.Net.Mime;

namespace VoceViuWeb.Controllers
{
    public class AttachmentController : Controller
    {
        private readonly IAdvertisementRepository _advertisementRepository;

        public AttachmentController(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }

        public FileResult AdvertisementContent(int id)
        {
            var advertisement = _advertisementRepository.Get(id);
            var attachment = advertisement.Content;
            return File(attachment.File, MediaTypeNames.Application.Octet, attachment.Name);
        }
	}
}