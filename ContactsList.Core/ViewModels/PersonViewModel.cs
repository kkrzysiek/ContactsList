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
		private ICustomAlert customAlert;

		public PersonViewModel(IPersonService personService, IMyCamera _myCam, ICustomAlert alert)
		{
			this.personService = personService;
			myCamera = _myCam;
			customAlert = alert;
		}

		// this init is used to provide from other view our own parameters: in this case the details of the person.
		public void Init(int _id)
		{
			if (_id > 0)
			{
				selectedPerson = personService.GetById(_id);
				firstName = selectedPerson.FirstName;
				lastName = selectedPerson.LastName;
				imageName = selectedPerson.ImageName;
				id = selectedPerson.Id;
			}
			else
			{
				selectedPerson = new Person();
			}
		}

		public override void Start()
		{
			base.Start();
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
			get { return new MvxCommand(SavePerson); }
		}

		public MvxCommand TakePictureCommand
		{
			get { return new MvxCommand(TakePictureCtr); }
		}

		public MvxCommand ChoosePictureCommand
		{
			get { return new MvxCommand(ChoosePictureCtr); }
		}

		async void TakePictureCtr()
		{
			var picture = await myCamera.TakePicture();
			if (picture != null)
			{
				ImageName = picture;
			}
		}

		async void ChoosePictureCtr()
		{
			var picture = await myCamera.ChoosePicture();
			if (picture != null)
			{
				ImageName = "saved.jpg";
			}
		}

		void SavePerson()
		{
			if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
			{
				customAlert.DisplayAlert();
				return;
			}

			var imgName = firstName[0] + lastName + ".jpg";
			var name = myCamera.ChangePictureName(imgName);

			personService.SavePerson(new Person { Id = id, FirstName = firstName, ImageName = name, LastName = lastName });
			Close(this);
		}

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
	}
}
