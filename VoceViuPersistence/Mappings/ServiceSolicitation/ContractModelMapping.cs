using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.ServiceSolicitations.Domain;

namespace VoceViuPersistence.Mappings.ServiceSolicitations
{
    public class ContractModelMapping : EntityTypeConfiguration<ContractModel>
    {
        public ContractModelMapping()
        {
            ToTable("VV_ContractModel");
            HasKey(a => a.Id);

        }
    }
}
