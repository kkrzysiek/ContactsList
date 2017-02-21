using System;
using UIKit;
namespace ContactsList.iOS
{
	public class LinkerPleaseInclude
	{
		public void Include(UIBarButtonItem button)
		{
			button.Clicked += (sender, e) => { button.Title = button.Title + ""; };
		}
	}
}
