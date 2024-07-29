using ConsultorioMedico.Dominio.Entities;
using FluentNHibernate.Mapping;

namespace ConsultorioMedico.Infrastructure.Mappings
{
    public class PacienteMap : ClassMap<Paciente>
    {
        public PacienteMap()
        {
            Table("Pacientes");

            Id(x => x.Id).GeneratedBy.Sequence("paciente_sequence");

            Map(x => x.Nome)
                .Not.Nullable()
                .Length(100);

            Map(x => x.Cpf)
                .Not.Nullable()
                .Unique()
                .Length(11);

            Map(x => x.DataNascimento)
                .Not.Nullable()
                .CustomType("timestamp");

            Map(x => x.Telefone)
                .Not.Nullable()
                .Length(15);

            Map(x => x.Email)
                .Not.Nullable()
                .Length(200);

            Map(x => x.Endereco)
                .Not.Nullable()
                .Length(100);
        }
    }
}
