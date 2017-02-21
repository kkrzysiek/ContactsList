using System;
using System.Collections.Generic;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using ContactsList.Core;
using UIKit;

namespace ContactsList.iOS
{
	public partial class PersonListView : MvxViewController<PersonListViewModel>
	{
		private PersonTableViewSource _personTableViewSource;
		protected PersonListViewModel PersonListViewModel => ViewModel as PersonListViewModel;
		UIBarButtonItem button = new UIBarButtonItem();

		public PersonListView() : base("PersonListView", null)
		{
			this.Title = "People list";
			button.Image = UIImage.FromBundle("Images");
			NavigationItem.RightBarButtonItem = button;
		}

		public override void ViewDidLoad()
		{
			savedPersonTableView.RegisterNibForCellReuse(PersonViewCell.Nib, "PersonViewCell");

			_personTableViewSource = new PersonTableViewSource(savedPersonTableView);
			base.ViewDidLoad();

			savedPersonTableView.Source = _personTableViewSource;
			CreateBindings();
			savedPersonTableView.ReloadData();
		}

		protected void CreateBindings()
		{
			var set = this.CreateBindingSet<PersonListView, PersonListViewModel>();

			set.Bind(_personTableViewSource).To(vm => vm.Persons);
			set.Bind(_personTableViewSource).For(source => source.SelectionChangedCommand)
			   .To(vm => vm.PersonDetailsCommand);

			this.AddBindings(
				new Dictionary<object, string>(){
					{
						button, "Clicked NewPersonCommand"
					}
				});

			set.Apply();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			PersonListViewModel.ReloadDataCommand.Execute();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}
	}
}

