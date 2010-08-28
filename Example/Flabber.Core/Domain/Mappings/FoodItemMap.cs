using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Flabber.Core.Domain.Mappings
{
	public class FoodItemMap : ClassMap<FoodItem>
	{
		public FoodItemMap()
		{
			Table("flabber_fooditems");
			Id(prop => prop.Id).GeneratedBy.Assigned();
			Map(prop => prop.Brand);
			Map(prop => prop.Calories);
			Map(prop => prop.Title);
			References(prop => prop.User);
		}
	}
}
