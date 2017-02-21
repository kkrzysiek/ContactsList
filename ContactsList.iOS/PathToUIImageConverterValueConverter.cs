
using System;
using MvvmCross.Platform.Converters;
using UIKit;
namespace ContactsList.iOS
{
	public class PathToUIImageConverterValueConverter: MvxValueConverter<string, UIImage>
	{
		protected override UIImage Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (string.IsNullOrEmpty(value)) return UIImage.FromFile("default.jpg");

			var img = UIImage.FromFile(value);
			return img;
		}
	}
}
