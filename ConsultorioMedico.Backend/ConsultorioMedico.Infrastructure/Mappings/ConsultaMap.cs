using FluentNHibernate.Mapping;
using ConsultorioMedico.Dominio.Entities;

namespace ConsultorioMedico.Infrastructure.Mappings
{
    public class ConsultaMap : ClassMap<Consulta>
    {
        public ConsultaMap()
        {
            Table("Consultas");

            Id(x => x.Id).GeneratedBy.Sequence("consulta_sequence");

            Map(x => x.DataHoraConsulta)
                .Not.Nullable()
                .CustomType("timestamp");

            Map(x => x.Observacoes)
                .Length(100)
                .Nullable();

            References(x => x.Paciente)
                .Column("PacienteId")
                .Not.Nullable()
                .Cascade.None();

            References(x => x.Medico)
                .Column("MedicoId")
                .Not.Nullable()
                .Cascade.None();
        }
    }
}
