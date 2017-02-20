using MvvmCross.Core.ViewModels;
namespace ContactsList.Core
{
	public class PersonViewModel: MvxViewModel
	{
		private int id;
		private string firstName;
		private string lastName;
		private string imageName;
		private Person selectedPerson;
		private IPersonService personService;
		private IMyCamera myCamera;

		public Person SelectedPerson
		{
			get { return selectedPerson; }
			set
			{
				selectedPerson = value;
				RaisePropertyChanged(() => SelectedPerson);
			}
		}

		public string FirstName
		{
			get { return firstName; }
			set
			{
				firstName = value;
				RaisePropertyChanged(() => FirstName);
			}
		}

		public int Id
		{
			get { return id; }
			set
			{
				id = value;
				RaisePropertyChanged(() => Id);
			}
		}

		public string LastName
		{
			get { return lastName; }
			set
			{
				lastName = value;
				RaisePropertyChanged(() => LastName);
			}
		}

		public string ImageName
		{
			get { return imageName; }
			set
			{
				imageName = value;
				RaisePropertyChanged(() => ImageName);
			}
		}

		public PersonViewModel(IPersonService personService, IMyCamera _myCam)
		{
			this.personService = personService;
			myCamera = _myCam;
		}

		// this init func is used to provide data from other view: in this case the details of the person.
		public void Init(int _id)
		{
			if (_id > 0)
			{
				selectedPerson = personService.GetById(_id);
				firstName = selectedPerson.FirstName;
				lastName = selectedPerson.LastName;
				id = selectedPerson.Id;
			}
			else
			{
				selectedPerson = new Person();
				id = 0;
			}
		}

		public override void Start()
		{
			base.Start();
		}

		void TakePictureCtr()
		{
			myCamera.ChoosePicture();
		}

		public MvxCommand CloseCommand
		{
			get
			{
				return new MvxCommand(() =>
					{
						Close(this);
					});
			}
		}

		public MvxCommand AddCommand
		{
			get
			{
				return new MvxCommand(SavePerson);
			}
		}

		async void SavePerson()
		{
			personService.SavePerson(new Person { Id = id, FirstName = firstName, ImageName = imageName, LastName = lastName });
			Close(this);
		}

		public MvxCommand TakePictureCommand
		{
			get
			{
				return new MvxCommand(TakePictureCtr);
			}
		}
	}
}
