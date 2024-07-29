using ConsultorioMedico.Dominio.Entities;
using ConsultorioMedico.Dominio.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioMedico.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ISessionFactory _sessionFactory;

        public PacienteRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public bool Create(Paciente paciente, out List<ValidationResult> errors)
        {
            errors = new List<ValidationResult>();
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            try
            {
                session.Save(paciente);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                errors.Add(new ValidationResult($"Ocorreu um erro ao criar o Paciente. {ex.Message}"));
                return false;
            }
        }

        public bool Delete(Paciente paciente, out List<ValidationResult> errors)
        {
            errors = new List<ValidationResult>();
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            try
            {
                session.Delete(paciente);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                errors.Add(new ValidationResult($"Ocorreu um erro ao remover o Paciente. {ex.Message}"));
                return false;
            }
        }

        public IEnumerable<Paciente> GetAll(int page, int size, string search, out int totalPacientes)
        {
            using var session = _sessionFactory.OpenSession();

            var query = session.Query<Paciente>();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(m => m.Nome.ToLower().Contains(search.ToLower()) ||
                                    m.Cpf.Contains(search) ||
                                    m.Id.ToString().ToLower().Contains(search.ToLower()));
            }

            totalPacientes = query.Count();

            return query
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();
        }

        public IEnumerable<Paciente> GetByCpf(string cpf)
        {
            using var session = _sessionFactory.OpenSession();
            var paciente = session.Query<Paciente>()
                .Where(p => p.Cpf == cpf)
                .ToList();
            return paciente;
        }

        public Paciente GetById(int id)
        {
            using var session = _sessionFactory.OpenSession();
            var paciente = session.Get<Paciente>(id);
            return paciente;
        }

        public bool Update(Paciente paciente, out List<ValidationResult> errors)
        {
            errors = new List<ValidationResult>();
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            try
            {
                session.Merge(paciente);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                errors.Add(new ValidationResult($"Ocorreu um erro ao atualizar o Paciente. {ex.Message}"));
                return false;
            }
        }
    }
}
