using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using ContactsList.Core;
using UIKit;
namespace ContactsList.iOS
{
	public partial class PersonView : MvxViewController<PersonViewModel>
	{
		protected PersonViewModel PersonViewModel => ViewModel as PersonViewModel;
		public PersonView() : base("PersonView", null)
		{
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			CreateBindings();
			txtFirstName.ShouldReturn += (textField) => { ((UITextField)textField).ResignFirstResponder(); return true; };
			txtLastName.ShouldReturn += (textField) => { ((UITextField)textField).ResignFirstResponder(); return true; };
			UITapGestureRecognizer tap = new UITapGestureRecognizer(() => View.EndEditing(true));
			tap.NumberOfTapsRequired = 1;
			tap.NumberOfTouchesRequired = 1;
			View.AddGestureRecognizer(tap);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();

		}

		protected void CreateBindings()
		{
			var set = this.CreateBindingSet<PersonView, PersonViewModel>();

			set.Bind(txtFirstName).To(vm => vm.FirstName);
			set.Bind(txtLastName).To(vm => vm.LastName);
			set.Bind(personImageView).For(v => v.Image).To(vm => vm.ImageName)
			   .WithConversion(new PathToUIImageConverterValueConverter(), new MvxImageViewLoader(() => personImageView));

			set.Bind(btnSave).To(vm => vm.AddCommand);
			set.Bind(btnCancel).To(vm => vm.CloseCommand);
			set.Bind(btnTakePicture).To(vm => vm.TakePictureCommand);
			set.Bind(btnChoosePicture).To(vm => vm.ChoosePictureCommand);
			set.Apply();
		}
	}
}

