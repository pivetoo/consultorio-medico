using ConsultorioMedico.Dominio.Entities;
using ConsultorioMedico.Dominio.ValueObjects;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioMedico.Infrastructure.Mappings
{
    public class MedicoMap : ClassMap<Medico>
    {
        public MedicoMap()
        {
            Table("Medicos");

            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Nome)
                .Not.Nullable()
                .Length(100);

            Map(x => x.Crm)
                .Not.Nullable()
                .Length(20);

            Map(x => x.Especialidade)
                .Not.Nullable()
                .CustomType<EspecialidadeMedica>();

            Map(x => x.Telefone)
                .Length(15);

            Map(x => x.Email)
                .Length(100);
        }
    }
}
