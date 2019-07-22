using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using UI.Plan.Web.NH.Mappings;

namespace UI.Plan.Web.NH
{
    public sealed class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory _sessionFactory;
        private static ISession _session;

        static NHibernateHelper()
        {
            var nhiberCfg = new Configuration().Configure();
            var configuration = Fluently.Configure(nhiberCfg)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EventMap>())
                .BuildConfiguration();

            var exporter = new SchemaExport(configuration);
            exporter.Execute(true, true, false);
            
            _sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            if (_session == null)
            {
                _session = _sessionFactory.OpenSession();
            }

            return _session;
        }

        public static void CloseSession()
        {

            if (_session == null)
            {
                // No current session
                return;
            }

            _session.Close();
            _session = null;
        }

        public static void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }
    }
}