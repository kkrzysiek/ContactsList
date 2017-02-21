using System;
namespace ContactsList.Core
{
	public class Person
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string ImageName { get; set; }

		public Person()
		{
			Id = -1;
		}
	}
}
