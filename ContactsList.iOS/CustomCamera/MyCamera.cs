using System;
using System;
using System.IO;
using System.Threading.Tasks;
using Foundation;
using ContactsList.Core;
using ContactsList.iOS;
using UIKit;
namespace ContactsList.iOS
{
	public class MyCamera:IMyCamera
	{
		public Task<string> ChoosePicture()
		{
			var tcs = new TaskCompletionSource<string>();

			CameraImplementation.SelectPicture(
			   UIApplication.SharedApplication.KeyWindow.RootViewController,
			   (imagePickerResult) =>
			   {
				   if (imagePickerResult == null) return;
				   var imageName = imagePickerResult["UIImagePickerControllerReferenceURL"].ToString();
				   tcs.TrySetResult(imageName);
			   });

			return tcs.Task;
		}

		public Task<string> TakePicture()
		{
			var tcs = new TaskCompletionSource<string>();

			CameraImplementation.TakePicture(
				UIApplication.SharedApplication.KeyWindow.RootViewController,
				(imagePickerResult) =>
				{
					if (imagePickerResult == null) return;
					var imageName = imagePickerResult["UIImagePickerControllerOriginalImage"].ToString();
					tcs.TrySetResult(imageName);
				});

			return tcs.Task;
		}

		public string ChangePictureName(string newName)
		{
			var dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			string fileName = System.IO.Path.Combine(dir, "saved.jpg");
			string newImg = System.IO.Path.Combine(dir, newName);
			UIImage photo = UIImage.FromFile(fileName);
			if (photo != null)
			{
				NSData data = photo.AsJPEG();
				NSError err = null;
				data.Save(newImg, false, out err);
				return newImg;
			}
			return string.Empty;
		}
	}
}
