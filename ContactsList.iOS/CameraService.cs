
using System;
using Foundation;
using UIKit;
namespace ContactsList.iOS
{
	public class CameraService
	{
		static UIImagePickerController picker;
		public static UIImage staticImgView;

		public CameraService()
		{
		}


		public static void TakePicture()
		{
			if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera))
			{
				picker = new UIImagePickerController();
				picker.Delegate = new CameraDelegate();
				picker.SourceType = UIImagePickerControllerSourceType.Camera;
			}
		}

	}
}
