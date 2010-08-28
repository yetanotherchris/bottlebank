using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Flabber.Core.Domain.Mappings
{
	public class UserMap : ClassMap<User>
	{
		public UserMap()
		{
			Table("flabber_users");
			Id(prop => prop.Id).GeneratedBy.Assigned();
			Map(prop => prop.Name);
			Map(prop => prop.OpenId);
		}
	}
}
