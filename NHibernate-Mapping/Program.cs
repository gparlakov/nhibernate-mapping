using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using NHibernate_Mapping.Entities;
using NHibernate_Mapping.MoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "FullUri=file:inMemory1?mode=memory&cache=shared;Version=3";

            var autoMaps = AutoMap
              .AssemblyOf<Person>(new FluentMappings())
              .AddEntityAssembly(typeof(AnotherPerson).Assembly)
              .AddMappingsFromAssemblyOf<Program>()
              .UseOverridesFromAssemblyOf<Program>();


            var config = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.ConnectionString(connectionString))
                .Mappings(c => c.UsePersistenceModel(autoMaps))
                //.ExposeConfiguration(c => new SchemaExport(c).Execute(false, true, false))
                .BuildConfiguration();

            var sessionFactory = config.BuildSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                new SchemaExport(config).Execute(false, true, false, session.Connection, null);
         

                var p1 = new Person() { Name = "FirstPerson", Description = "test" };
                var p2 = new Person() { Name = "Second FirstPerson", Description = "second test" };

                session.Save(p1);
                session.Save(p2);
                session.Flush();

                var s1 = session.QueryOver<ShortPerson>().List();
                System.Diagnostics.Debug.WriteLine(s1.Count);

                var s2 = session.QueryOver<YetAnotherPerson>().List();
                System.Diagnostics.Debug.WriteLine(s2.Count);
            }

        }
    }
}
