using FluentNHibernate.Automapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using NHibernate_Mapping.Entities;
using NHibernate_Mapping.MoreEntities;

namespace ConsoleApplication1
{
    public class FluentMappings: DefaultAutomappingConfiguration
    {
        private List<Type> _mappedTypes = new List<Type>
        {
            typeof(Person)
            //,typeof(ShortPerson)
            ,typeof(AnotherPerson)
            ,typeof(YetAnotherPerson)
        };

        public override bool ShouldMap(Type type)
        {
            return type.Namespace != null
                   && type.IsPublic &&
                   _mappedTypes.Contains(type);
        }

    }
}
