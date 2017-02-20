using System;
using System.Collections.Generic;

namespace ContactsList.Core
{
	public interface IPersonRepository
	{
		IEnumerable<Person> GetPersons();
		void SavePerson(Person person);
		void Update(Person person);
	}
}
