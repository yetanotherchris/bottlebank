# Bottlebank 

![](https://github.com/yetanotherchris/bottlebank/blob/master/images/logo.png)

## Welcome

Bottlebank is a light-weight repository for NHibernate and Fluent NHibernate. 

It makes use of the NHibernate Query Manager I wrote and the repository pattern. It's extremely easy to use:

- Add a reference to Bottlebank  
- Ensure you have referenced the appropriate assemblies needed: NHibernate, FluentNHibernate and their dependencies.  
- Create your domain objects, and extend Repository if needed.  

## Example
The source comes with a fairly hefty example project called Flabber. This was a site I was intending to create for calorie counting, but eventually ran out of free time to do. It's an ASP.NET MVC site that demonstrates Bottlebank with very few domain objects, and some jQuery autocomplete.

One of the domain objects in Flabber is the User object:

	public class User : NHibernateObject<User, UserRepository>
	{
		public virtual Guid Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string OpenId { get; set; }
	}

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

	public class UserRepository : Repository<User, UserRepository>
	{
	}

It's not much more difficult than that - infact you don't have to create your own Repository if you don't want to add anything to it. The repository class comes with a number of inbuilt methods:

* SaveOrUpdate
* Delete
* List
* OrderedList(bool ascending, params string[] orderBy)
* Count
* Query(string hql)
* Page(int page, int pageSize, string orderBy)

For example, you can use:

	User.Repository.Delete();

It's mix of the Active Record pattern and the classic Repository pattern where you would use UserRepository.Delete(user). 

As you'd expect with DDD architecture, the Repository property your domain object gets is really just a large tangle of indirection that ultimately calls the NHibernateQueryManager, which creates the session and disposes of it. 

Currently sessions are disposed of immediately by Bottlebank (the default behaviour of NHibernateQueryManager). It's fairly easy to change this though, change the Repository.cs source:

	public NHibernateQueryManager Manager()
	{
		return new NHibernateQueryManager(NHibernateManager.Current.SessionFactory);
	}


to

	public NHibernateQueryManager Manager()
	{
		NHibernateQueryManager manager = new NHibernateQueryManager(NHibernateManager.Current.SessionFactory);
		manager.DisposeSessions = false;
		return manager;
	}

The source was a great learning tool for me for brushing up on generics and inheritence, hopefully it'll be of some use to others.

## Getting the example working

You'll need Visual Studio 2010.

The fastest way to get the Flabber example working, assuming you have SQLExpress installed, is to create the database as shown in the images below. It should "just work" then, set the flabber.site as the startup project and hit F5.

![](https://github.com/yetanotherchris/bottlebank/blob/master/images/step1.png)
![](https://github.com/yetanotherchris/bottlebank/blob/master/images/step2.png)
![](https://github.com/yetanotherchris/bottlebank/blob/master/images/step3.png)