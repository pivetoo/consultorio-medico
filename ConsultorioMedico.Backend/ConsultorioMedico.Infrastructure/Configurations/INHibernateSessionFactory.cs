using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioMedico.Infrastructure.Configurations
{
    public interface INHibernateSessionFactory
    {
        ISessionFactory GetSessionFactory();
    }
}
