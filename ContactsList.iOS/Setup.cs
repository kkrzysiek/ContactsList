using System;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using ContactsList.Core;
using UIKit;

namespace ContactsList.iOS
{
	public class Setup: MvxIosSetup
	{
		public Setup(MvxApplicationDelegate del, UIWindow window) : base(del, window)
		{
		}

		public Setup(IMvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter) : base(applicationDelegate, presenter)
		{
		}

		protected override MvvmCross.Core.ViewModels.IMvxApplication CreateApp()
		{
			return new App();
		}

		protected override void InitializeIoC()
		{
			base.InitializeIoC();
		}

		protected override void InitializeFirstChance()
		{
			Mvx.RegisterSingleton<IMyCamera>(new MyCamera());
			Mvx.RegisterSingleton<ICustomAlert>(new CustomAlert());
			base.InitializeFirstChance();
		}

		protected override IMvxIosViewPresenter CreatePresenter()
		{
			return base.CreatePresenter();
		}
	}
}
