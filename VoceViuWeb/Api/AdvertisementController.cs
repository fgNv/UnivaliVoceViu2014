using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VoceViuModel.ServiceSolicitations.Messages;
using VoceViuModel.ServiceSolicitations.Services;

namespace VoceViuWeb.Api
{
    public class AdvertisementController : ApiController
    {
        private readonly AdvertisementService _advertisementService;

        public AdvertisementController(AdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        public void DenyContent(int id, DenyAdvertisementContentMessage message)
        {
            _advertisementService.DenyContent(id, message);
        }

        public void ApproveContent(int id)
        {
            _advertisementService.ApproveContent(id);
        }
    }
}