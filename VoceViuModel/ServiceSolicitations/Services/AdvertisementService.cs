using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Attachments;
using VoceViuModel.ServiceSolicitations.Abstraction;
using VoceViuModel.ServiceSolicitations.Domain;
using VoceViuModel.ServiceSolicitations.Messages;

namespace VoceViuModel.ServiceSolicitations.Services
{
    public class AdvertisementService
    {
        private readonly IAdvertisementRepository _advertisementRepository;

        public AdvertisementService(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }

        public void SetContent(int id, SetAdvertisementContentMessage message)
        {
            var advertisement = _advertisementRepository.Get(id);

            if (advertisement == null)
                throw new Exception("Anúncio não encontrado");

            if (advertisement.Content != null && advertisement.Status == Domain.AdvertisementStatus.PendingContentApproval)
                throw new Exception("Esse anúncio conteúdo atribuído pendente de aprovação");

            if (advertisement.Content != null && advertisement.Status != Domain.AdvertisementStatus.PendingContentDispatch)
                throw new Exception("Esse anúncio possui conteúdo aprovado");

            var attachment = new Attachment();
            attachment.File = message.File;
            attachment.Name = message.FileName;
            advertisement.Content = attachment;
            advertisement.Status = AdvertisementStatus.PendingContentApproval;
            _advertisementRepository.SaveChanges();
        }

        public void DenyContent(int id, DenyAdvertisementContentMessage message)
        {
            var advertisement = _advertisementRepository.Get(id);

            if (advertisement.Status != AdvertisementStatus.PendingContentApproval || advertisement.Content == null)
                throw new Exception("Não há conteúdo atribuido a esse anúncio");

            advertisement.Status = AdvertisementStatus.PendingContentDispatch;
            var deniedContent = new AdvertisementContent();
            deniedContent.Content = advertisement.Content;
            deniedContent.DenialDate = DateTime.Now;
            deniedContent.Comment = message.Comment;
            advertisement.Content = null;
            advertisement.DeniedContents.Add(deniedContent);

            _advertisementRepository.SaveChanges();
        }

        public void ApproveContent(int id)
        {
            var advertisement = _advertisementRepository.Get(id);

            if (advertisement.Status != AdvertisementStatus.PendingContentApproval || advertisement.Content == null)
                throw new Exception("Não há conteúdo atribuido a esse anúncio");

            advertisement.Status = AdvertisementStatus.PendingPayment;
            _advertisementRepository.SaveChanges();
        }

        public void SetAsPaid(int id)
        {
            var advertisement = _advertisementRepository.Get(id);

            if (advertisement.Status != AdvertisementStatus.PendingPayment)
                throw new Exception("Não há pagamento pendente desse anúncio");

            SetVariableStatus(advertisement);
            _advertisementRepository.SaveChanges();
        }

        private void SetVariableStatus(Advertisement advertisement)
        {
            var allowedStatusesToMethodBeUsed = new[] 
            {
                AdvertisementStatus.PendingPayment,
                AdvertisementStatus.AwaitingExibhitionPeriod,
                AdvertisementStatus.ExibhitionHappening
            };

            if (!allowedStatusesToMethodBeUsed.Contains(advertisement.Status))
                return;

            if (advertisement.ServiceSolicitation.StartDate < DateTime.Now)
                advertisement.Status = AdvertisementStatus.AwaitingExibhitionPeriod;
            else if (advertisement.ServiceSolicitation.EndDate > DateTime.Now)
                advertisement.Status = AdvertisementStatus.ExpiredPeriod;
            else
                advertisement.Status = AdvertisementStatus.ExibhitionHappening;
        }

        public void UpdateStatuses()
        {
            var advertisements = _advertisementRepository.GetAll()
                                                         .Where(a => a.Status == AdvertisementStatus.AwaitingExibhitionPeriod ||
                                                                     a.Status == AdvertisementStatus.ExibhitionHappening);
            foreach (var adv in advertisements)
                SetVariableStatus(adv);

            _advertisementRepository.SaveChanges();
        }
    }
}
