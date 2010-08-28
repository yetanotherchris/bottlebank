using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BottleBank;

namespace Flabber.Core
{
	public class FoodEntry : NHibernateObject<FoodEntry, FoodEntryRepository>
	{
		public virtual Guid Id { get; set; }
		public virtual string Title { get; set; }
		public virtual double Calories { get; set; }
		public virtual DateTime Date { get; set; }
		public virtual User User { get; set; }
	}
}
