using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Flabber.Core.Domain.Mappings
{
	public class FoodEntryMap : ClassMap<FoodEntry>
	{
		public FoodEntryMap()
		{
			Table("flabber_foodentries");
			Id(prop => prop.Id).GeneratedBy.Assigned();
			Map(prop => prop.Calories);
			Map(prop => prop.Date);
			Map(prop => prop.Title);
			References(prop => prop.User);
		}
	}
}
