using System;
using ContactsList.Core;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace ContactsList.iOS
{
	public partial class PersonViewCell : MvxTableViewCell
	{
		public static readonly NSString Identifier = new NSString("PersonViewCell");
		public static readonly UINib Nib;

		static PersonViewCell()
		{
			Nib = UINib.FromName("PersonViewCell", NSBundle.MainBundle);
		}

		public PersonViewCell(IntPtr handle) : base(handle)
		{
		}

		void CreateBindings()
		{
			var set = this.CreateBindingSet<PersonViewCell, Person>();
			set.Bind(lblLastName).To(vm => vm.LastName);
			set.Bind(lblFirstName).To(vm => vm.FirstName);
			set.Bind(personImage).For(v => v.Image).To(vm => vm.ImageName)
			   .WithConversion(new PathToUIImageConverterValueConverter(), new MvxImageViewLoader(() => personImage));

			set.Apply();
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			CreateBindings();
			lblLastName.Font = UIFont.FromName(lblLastName.Font.Name, 10f);
			lblFirstName.Font = UIFont.FromName(lblFirstName.Font.Name, 10f);
		}
	}
}

