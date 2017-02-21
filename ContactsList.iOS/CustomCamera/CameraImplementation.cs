using System;
using UIKit;
using Foundation;
namespace ContactsList.iOS
{
	public class CameraImplementation
	{
		static UIImagePickerController picker;
		static Action<NSDictionary> _callback;

		static void Init()
		{
			if (picker != null)
				return;

			picker = new UIImagePickerController();
			picker.Delegate = new CameraDelegate();
		}

		class CameraDelegate : UIImagePickerControllerDelegate
		{
			public override void FinishedPickingMedia(UIImagePickerController picker, NSDictionary info)
			{
				var cb = _callback;
				_callback = null;

				picker.DismissViewController(true, (Action)null);
				cb(info);

				UIImage photo = info[UIImagePickerController.OriginalImage] as UIImage;
				var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				string fileName = System.IO.Path.Combine(dir, "saved.jpg");

				NSData data = photo.AsJPEG();
				NSError err = null;
				data.Save(fileName, false, out err);
			}

			public override void Canceled(UIImagePickerController picker)
			{
				var cb = _callback;
				_callback = null;

				picker.DismissViewController(true, (Action)null);
				cb(null);
			}
		}

		public static void TakePicture(UIViewController parent, Action<NSDictionary> callback)
		{
			Init();
			picker.SourceType = UIImagePickerControllerSourceType.Camera;
			_callback = callback;
			parent.PresentViewController((UIViewController)picker, true, (Action)null);
		}

		public static void SelectPicture(UIViewController parent, Action<NSDictionary> callback)
		{
			Init();
			picker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
			_callback = callback;
			parent.PresentViewController((UIViewController)picker, true, (Action)null);
		}
	}
}
