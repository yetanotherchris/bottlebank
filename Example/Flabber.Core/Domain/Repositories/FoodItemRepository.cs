using System;
using System.Linq;
using System.Collections.Generic;
using BottleBank;
using NHibernate.Criterion;

namespace Flabber.Core
{
	public class FoodItemRepository : Repository<FoodItem, FoodItemRepository>
	{
		public List<FoodItem> ForUser(User user)
		{
			return base.List("@User", user).ToList();
		}
	}
}
