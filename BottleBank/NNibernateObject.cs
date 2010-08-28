﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;

namespace BottleBank
{
	/// <summary>
	/// Holds NHibernate session information plus any other application wide settings.
	/// </summary>
	public class NHibernateObject<T,TRepository> 
		where T : NHibernateObject<T,TRepository>
		where TRepository : class, IRepository<T,TRepository>,new()  // can't be abstract and must have a parameterless constructor
	{
		public static TRepository Repository
		{
			get
			{
				if (NHibernateManager.Current.SessionFactory == null)
					throw new InvalidOperationException("The NHibernateManager.Current.SessionFactory is null. Please use NHibernateManager.Current.Configure() before any NHibernate operations");

				return new TRepository();
			}
		}

		public static void Configure(string connection)
		{
			NHibernateManager.Current.Configure<T>(connection);
		}

		public static void Configure(string connection, bool createSchema)
		{
			NHibernateManager.Current.Configure<T>(connection,createSchema);
		}
	}
}