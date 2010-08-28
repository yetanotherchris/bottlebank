using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BottleBank;

namespace Flabber.Core
{
	public class User : NHibernateObject<User, UserRepository>
	{
		public virtual Guid Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string OpenId { get; set; }
	}
}
