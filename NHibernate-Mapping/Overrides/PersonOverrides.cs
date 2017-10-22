using FluentNHibernate.Automapping.Alterations;
using NHibernate_Mapping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using NHibernate_Mapping.MoreEntities;

namespace ConsoleApplication1.Overrides
{
    public class PersonOverrides : IAutoMappingOverride<Person>
    {
        public void Override(AutoMapping<Person> mapping)
        {
            mapping.Table(nameof(Person));
            mapping.Schema("dbo");
        }
    }

    public class ShortPersonOverrides : IAutoMappingOverride<ShortPerson>
    {
        public void Override(AutoMapping<ShortPerson> mapping)
        {
            mapping.SchemaAction.None();
            mapping.Table(nameof(Person));
            mapping.Schema("dbo");
            mapping.Map(m => m.Name);
            mapping.IgnoreProperty(m => m.MissingName);
        }
    }

    public class AnotherPersonOverrides : IAutoMappingOverride<AnotherPerson>
    {
        public void Override(AutoMapping<AnotherPerson> mapping)
        {
            mapping.Table(nameof(Person));
            mapping.Schema("dbo");
        }
    }

}
