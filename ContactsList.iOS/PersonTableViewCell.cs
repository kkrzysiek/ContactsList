using System;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using Foundation;

namespace ContactsList.iOS
{
	public class PersonTableViewCell: MvxTableViewSource
	{
		public PersonTableViewSource(UITableView tableView) : base(tableView)
		{
			//tableView.RegisterClassForCellReuse(null, "PersonViewCell");
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			if (ItemsSource == null)
				return -1;

			return ItemsSource.Count();
		}

		public override nint NumberOfSections(UITableView tableView)
		{
			return 1;
		}

		protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
		{
			var cell = (PersonViewCell)tableView.DequeueReusableCell("PersonViewCell");
			return cell;
		}
	}
}
