using FluentNHibernate.Mapping;
using NHibernate_Mapping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Mappings
{
    public class PersonMappings: ClassMap<YetAnotherPerson>
    {
        public PersonMappings()
        {
            Table(nameof(Person));
            Schema("dbo");

            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description);
        }

    }
}
