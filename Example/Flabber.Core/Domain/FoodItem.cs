using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BottleBank;

namespace Flabber.Core
{
	public class FoodItem : NHibernateObject<FoodItem, FoodItemRepository>
	{
		public virtual Guid Id { get; set; }
		public virtual string Brand { get; set; }
		public virtual string Title { get; set; }
		public virtual double Calories { get; set; }
		public virtual User User { get; set; }
	}
}
