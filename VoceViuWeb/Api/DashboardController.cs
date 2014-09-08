using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Advertiser = VoceViuWeb.Areas.Advertiser;
using Administrator = VoceViuWeb.Areas.Admin.Models;
using VoceViuWeb.Helpers;
using VoceViuModel.ServiceSolicitations.Queries;
using VoceViuModel.ServiceSolicitations.Abstraction;
using VoceViuModel.ServiceSolicitations.Domain;

namespace VoceViuWeb.Api
{
    public class DashboardController : ApiController
    {
        private readonly PendingPaymentAdvertisementsPerAdvertiserQuery _pendingPaymentQuery;
        private readonly PendingContentAdvertisementsPerAdvertiserQuery _pendingContentQuery;
        private readonly IServiceSolicitationRepository _serviceSolicitationRepository;
        private readonly IAdvertisementRepository _advertisementRepository;

        public DashboardController(PendingContentAdvertisementsPerAdvertiserQuery pendingContentQuery,
                                   PendingPaymentAdvertisementsPerAdvertiserQuery pendingPaymentQuery,
                                   IServiceSolicitationRepository serviceSolicitationRepository,
                                   IAdvertisementRepository advertisementRepository)
        {
            _pendingContentQuery = pendingContentQuery;
            _pendingPaymentQuery = pendingPaymentQuery;
            _serviceSolicitationRepository = serviceSolicitationRepository;
            _advertisementRepository = advertisementRepository;
        }

        public Advertiser.DashboardViewModel GetAdvertiserData()
        {
            var user = HttpContext.Current.User;
            var userId = user.GetUserId();
            var response = new Advertiser.DashboardViewModel();

            response.PendingContentAdvertisementCount = _pendingContentQuery.Get(userId).Count();
            response.PendingPaymentAdvertisementCount = _pendingPaymentQuery.Get(userId).Count();

            return response;
        }

        public Administrator.DashboardViewModel GetAdministratorData()
        {
            var pendingContentApprovalCount = _advertisementRepository.GetAll()
                                                                      .Where(a => a.Status == AdvertisementStatus.PendingContentApproval)
                                                                      .Count();

            var pendingServiceSolicitationsCount = _serviceSolicitationRepository.GetAll()
                                                                                 .Where(ss => ss.Advertisement == null)
                                                                                 .Count();

            var pendingPaymentCount = _advertisementRepository.GetAll()
                                                              .Where(a => a.Status == AdvertisementStatus.PendingPayment)
                                                              .Count();

            var response = new Administrator.DashboardViewModel();
            response.PendingContentApprovalAdvertisementsCount = pendingContentApprovalCount;
            response.PendingServiceSolicitationsCount = pendingServiceSolicitationsCount;
            response.PendingPaymentAdvertisementsCount = pendingPaymentCount;

            return response;
        }
    }
}