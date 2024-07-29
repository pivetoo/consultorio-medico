using ConsultorioMedico.Dominio.Entities;
using ConsultorioMedico.Dominio.Repositories;
using ConsultorioMedico.Dominio.ValueObjects;
using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioMedico.Infrastructure.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ISessionFactory _sessionFactory;

        public MedicoRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public bool Create(Medico medico, out List<ValidationResult> errors)
        {
            errors = new List<ValidationResult>();
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            try
            {
                session.Save(medico);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                errors.Add(new ValidationResult($"Ocorreu um erro ao criar o Médico. {ex.Message}"));
                return false;
            }
        }

        public bool Delete(Medico medico, out List<ValidationResult> errors)
        {
            errors = new List<ValidationResult>();
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            try
            {
                session.Delete(medico);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                errors.Add(new ValidationResult($"Ocorreu um erro ao remover o Médico. {ex.Message}"));
                return false;
            }
        }

        public IEnumerable<Medico> GetAll(int page, int size, string search, out int totalMedicos)
        {
            using var session = _sessionFactory.OpenSession();

            var query = session.Query<Medico>();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(m => m.Nome.ToLower().Contains(search.ToLower()) ||
                                    m.Crm.Contains(search) ||
                                    m.Especialidade.ToString().ToLower().Contains(search.ToLower()));
            }

            totalMedicos = query.Count();

            return query
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();
        }

        public Medico GetById(int id)
        {
            using var session = _sessionFactory.OpenSession();
            var medico = session.Get<Medico>(id);
            return medico;
        }

        public IEnumerable<Medico> GetBySpecialty(EspecialidadeMedica especialidadeMedica)
        {
            using var session = _sessionFactory.OpenSession();
            var medico = session.Query<Medico>()
                .Where(m => m.Especialidade == especialidadeMedica)
                .ToList();
            return medico;
        }

        public bool Update(Medico medico, out List<ValidationResult> errors)
        {
            errors = new List<ValidationResult>();
            using var session = _sessionFactory.OpenSession();
            using var transaction = session.BeginTransaction();

            try
            {
                session.Merge(medico);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                errors.Add(new ValidationResult($"Ocorreu um erro ao atualizar o Médico. {ex.Message}"));
                return false;
            }
        }
    }
}