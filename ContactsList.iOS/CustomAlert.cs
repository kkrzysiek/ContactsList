using System;
using System.Threading.Tasks;
using ContactsList.Core;
using UIKit;
namespace ContactsList.iOS
{
	public class CustomAlert: ICustomAlert
	{
		public void DisplayAlert()
		{
			UIAlertView alert = new UIAlertView("Empty fields!", null, null, "OK", null);
			alert.Show();
		}
	}
}
