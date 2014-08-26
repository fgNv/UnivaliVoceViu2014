using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceViuModel.ServiceSolicitations.Domain
{
    public enum AdvertisementStatus
    {
        PendingContentDispatch,// EnvioDeConteudoPendente,
        PendingContentApproval,// AprovacaoDeConteudoPendente,
        PendingPayment,// PagamentoPendente,
        AwaitingExibhitionPeriod,// AguardandoPeriodoExibicao,
        ExibhitionHappening,// ExibicaoEmAndamento,
        ExpiredPeriod,// PeriodoExpirado,
        InvalidAdvertisement,// AnuncioInvalidado
    }
}
