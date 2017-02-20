using System.Collections.Generic;
using System.Linq;
namespace ContactsList.Core
{
	public class PersonRepository: IPersonRepository
	{
		public IEnumerable<Person> GetPersons()
		{
			return persons;
		}

		public void Update(Person person)
		{
			persons.Remove(persons.First(x => x.Id == person.Id));
			persons.Add(person);
			persons = persons.OrderBy(x => x.Id).ToList();
		}

		public void SavePerson(Person person)
		{
			persons.Add(person);
		}

		private List<Person> persons = new List<Person>
		{
			new Person{ Id = 1, FirstName = "k", ImageName = "kkrzysiek", LastName = "krzysiek" },
			new Person{ Id = 2, FirstName = "test", ImageName = "testtest", LastName = "test" },
			new Person{ Id = 3, FirstName = "test1", ImageName = "test1test", LastName = "test1test" }
		};
	}
}
