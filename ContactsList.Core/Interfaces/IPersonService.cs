using System;
using System.Collections.Generic;
namespace ContactsList.Core
{
	public interface IPersonService
	{
		List<Person> GetAllPersons();
		void SavePerson(Person person);
		Person GetByEmail(string email);
		Person GetById(int id);
	}
}
