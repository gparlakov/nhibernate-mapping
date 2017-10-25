using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using NHibernate_Mapping.Entities;
using NHibernate_Mapping.MoreEntities;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "FullUri=file:memorydb.db?mode=memory&cache=shared;Version=3";
            //var connectionString = "FullUri=file:memorydb.db?mode=memory&cache=shared";
            //var connectionString = "FullUri=file::memory:?cache=shared";
            //var connectionString = "DataSource='file:memdb1?mode=memory&cache=shared'";

            var autoMaps = AutoMap
              .AssemblyOf<Person>(new FluentMappings())
              .AddEntityAssembly(typeof(AnotherPerson).Assembly)
              .AddMappingsFromAssemblyOf<Program>()
              .UseOverridesFromAssemblyOf<Program>();


            var config = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                    .ConnectionString(connectionString)
                    .Provider<NHibernate.Connection.DriverConnectionProvider>())
                .Mappings(c => c.UsePersistenceModel(autoMaps))
                //.ExposeConfiguration(c => new SchemaExport(c).Execute(false, true, false))
                .BuildConfiguration();

            var sessionFactory = config.BuildSessionFactory();
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            new SchemaExport(config).Execute(false, true, false, connection, null);
            
            using (var session = sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {

                    var p1 = new Person() { Name = "FirstPerson", Description = "test" };
                    var p2 = new Person() { Name = "Second FirstPerson", Description = "second test" };

                    session.Save(p1);
                    session.Save(p2);
                    session.Flush();

                    var shorts = session.QueryOver<ShortPerson>().List();
                    System.Diagnostics.Debug.WriteLine(shorts.Count);

                    var yetAnothers = session.QueryOver<YetAnotherPerson>().List();
                    System.Diagnostics.Debug.WriteLine(yetAnothers.Count);
                    tx.Commit();
                }
            }



            var sessionFactory1 = config.BuildSessionFactory();
            using (var session = sessionFactory1.OpenSession())
            {
                var shortPersons = session.QueryOver<ShortPerson>().List();
                System.Diagnostics.Debug.WriteLine(shortPersons.Count);

                var yetAnotherPersons = session.QueryOver<YetAnotherPerson>().List();
                System.Diagnostics.Debug.WriteLine(yetAnotherPersons.Count);
            }

        }
    }
}
