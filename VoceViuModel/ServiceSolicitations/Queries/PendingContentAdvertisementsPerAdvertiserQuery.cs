using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.ServiceSolicitations.Abstraction;

namespace VoceViuModel.ServiceSolicitations.Queries
{
    public class PendingContentAdvertisementsPerAdvertiserQuery
    {
        private readonly IAdvertisementRepository _advertisementRepository;

        public PendingContentAdvertisementsPerAdvertiserQuery(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }

        public IEnumerable<Advertisement> Get(int advertiserId)
        {
            var advertisements = _advertisementRepository.GetByAdvertiser(advertiserId)
                                                         .Where(a => a.Status == Domain.AdvertisementStatus.PendingContentDispatch);

            return advertisements;
        }
    }

}
