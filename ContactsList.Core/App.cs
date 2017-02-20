using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
namespace ContactsList.Core
{
	public class App: MvxApplication
	{
		public override void Initialize()
		{
			base.Initialize();

			CreatableTypes()
				.EndingWith("Repository")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			RegisterAppStart(new AppStart());
		}
	}
}
