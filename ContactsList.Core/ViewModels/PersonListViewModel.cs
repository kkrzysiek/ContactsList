using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;

namespace ContactsList.Core
{
	public class PersonListViewModel: MvxViewModel
	{
		private readonly IPersonService personService;
		private ObservableCollection<Person> persons;

		public ObservableCollection<Person> Persons
		{
			get
			{
				return persons;
			}
			set
			{
				persons = value;
				RaisePropertyChanged(() => Persons);
			}
		}

		public MvxCommand ReloadDataCommand
		{
			get
			{
				return new MvxCommand(() =>
				{
					Persons = Initialize();
				});
			}
		}

		public PersonListViewModel(IPersonService personService)
		{
			this.personService = personService;
			Initialize();
		}

		public MvxCommand<Person> PersonDetailsCommand
		{
			get
			{
				return new MvxCommand<Person>(selectedPerson =>
				{
					ShowViewModel<PersonViewModel>(new { _id = selectedPerson.Id });
				});
			}
		}

		public MvxCommand NewPersonCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<PersonViewModel>(new { _id = 0 }));
			}
		}

		private ObservableCollection<Person> Initialize()
		{
			persons = new ObservableCollection<Person>();
			var p = personService.GetAllPersons();
			foreach (var item in p)
			{
				persons.Add(item);
			}
			return persons;
		}
	}
}
