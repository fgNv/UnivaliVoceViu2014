using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoceViuModel.ServiceSolicitations.Abstraction;
using System.Net.Mime;
using VoceViuModel.AdminContent.Abstractions;

namespace VoceViuWeb.Controllers
{
    public class AttachmentController : Controller
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IContentRepository _contentRepository;

        public AttachmentController(IAdvertisementRepository advertisementRepository, IContentRepository contentRepository)
        {
            _advertisementRepository = advertisementRepository;
            _contentRepository = contentRepository;
        }

        public FileResult AdvertisementContent(int id)
        {
            var advertisement = _advertisementRepository.Get(id);
            var attachment = advertisement.Content;
            return File(attachment.File, MediaTypeNames.Application.Octet, attachment.Name);
        }

        public FileResult AdministratorContent(int id)
        {
            var content = _contentRepository.Get(id);
            var attachment = content.Attachment;

            return File(attachment.File, MediaTypeNames.Application.Octet, attachment.Name);
        }

	}
}