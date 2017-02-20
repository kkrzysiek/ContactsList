
using MvvmCross.Core.ViewModels;
namespace ContactsList.Core
{
	public class AppStart: MvxNavigatingObject, IMvxAppStart
	{
		public void Start(object hint = null)
		{
			ShowViewModel<PersonListViewModel>();
		}
	}
}
