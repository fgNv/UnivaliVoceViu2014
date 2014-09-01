using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceViuModel.ServiceSolicitations.Domain
{
    public enum AdvertisementStatus
    {
        [Description("Envio de conteúdo pendente")]
        PendingContentDispatch = 1,// EnvioDeConteudoPendente,

        [Description("Aprovação de conteúdo pendente")]
        PendingContentApproval = 2,// AprovacaoDeConteudoPendente,

        [Description("Pagamento pendente")]
        PendingPayment = 3,// PagamentoPendente,

        [Description("Aguardando período de exibição")]
        AwaitingExibhitionPeriod = 5,// AguardandoPeriodoExibicao,

        [Description("Exibição em andamento")]
        ExibhitionHappening = 8,// ExibicaoEmAndamento,

        [Description("Período expirado")]
        ExpiredPeriod = 13,// PeriodoExpirado,

        //[Description("Anúncio invalidado")]
        //InvalidAdvertisement = 21// AnuncioInvalidado
    }
}
