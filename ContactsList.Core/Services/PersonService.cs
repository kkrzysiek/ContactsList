using System.Collections.Generic;
using System.Linq;
namespace ContactsList.Core
{
	public class PersonService: IPersonService
	{
		private readonly IPersonRepository personRepository;

		public PersonService(IPersonRepository personRepository)
		{
			this.personRepository = personRepository;
		}

		public List<Person> GetAllPersons()
		{
			var persons = personRepository.GetPersons().ToList();
			if (persons == null || persons.Count() <= 0)
				return new List<Person>();

			return persons;
		}

		public void SavePerson(Person person)
		{
			if (string.IsNullOrEmpty(person.FirstName) || string.IsNullOrEmpty(person.LastName))
				return;

			// new person
			if (person.Id <= 0)
			{
				int highestId = personRepository.GetPersons().OrderByDescending(x => x.Id).First().Id;
				person.Id = highestId + 1;
				personRepository.SavePerson(person);
				return;
			}

			// existing record
			var p = personRepository.GetPersons().First(x => x.Id == person.Id);
			if (p != null)
			{
				personRepository.Update(person);
				return;
			}
		}

		public Person GetById(int id)
		{
			var person = personRepository.GetPersons().FirstOrDefault(x => x.Id == id);
			if (person == null)
				return new Person();
			return person;
		}


		public Person GetByEmail(string email)
		{
			var person = personRepository.GetPersons().FirstOrDefault(x => x.ImageName.ToLower() == email.ToLower());
			if (person == null)
				return new Person();
			return person;
		}
	}

}
