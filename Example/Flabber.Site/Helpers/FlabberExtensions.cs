using System.Collections.Generic;
using System.Text;
using System.Linq;

using Flabber.Core;

namespace Flabber.Site
{
	public static class FlabberExtensions
	{
		public static string AutoCompleteList(this List<FoodItem> list,string query)
		{
			var filtered = list.Where(i => i.Title.ToLower().StartsWith(query.ToLower())).ToList();
			StringBuilder builder = new StringBuilder();
			foreach (FoodItem item in filtered)
			{
				builder.AppendFormat("{0}|{1}\n", item.Title,item.Calories);
			}

			return builder.ToString();
		}
	}
}
