using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace ConsultorioMedico.Infrastructure.Configurations
{
    public class NHibernateSessionFactory : INHibernateSessionFactory
    {
        private readonly string _connectionString;
        private ISessionFactory _sessionFactory;

        public NHibernateSessionFactory(string connectionString)
        {
            _connectionString = connectionString;
            _sessionFactory = BuildSessionFactory();
        }

        private ISessionFactory BuildSessionFactory()
        {
            return Fluently.Configure()
                .Database(PostgreSQLConfiguration.Standard.ConnectionString(_connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
        }

        public ISessionFactory GetSessionFactory()
        {
            return _sessionFactory;
        }
    }
}
