using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceViuModel.ServiceSolicitation.Domain
{
    public enum AdvertisementStatus
    {
        PendingDispatch,// EnvioPendente,
        PendingApproval,// AprovacaoPendente,
        PendingPayment,// PagamentoPendente,
        AwaitingExibhitionPeriod,// AguardandoPeriodoExibicao,
        ExibhitionHappening,// ExibicaoEmAndamento,
        ExpiredPeriod,// PeriodoExpirado,
        InvalidAdvertisement,// AnuncioInvalidado
    }
}
