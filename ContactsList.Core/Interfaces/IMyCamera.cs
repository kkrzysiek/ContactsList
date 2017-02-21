using System;
using System.Threading.Tasks;
namespace ContactsList.Core
{
	public interface IMyCamera
	{
		Task<string> TakePicture();
		Task<string> ChoosePicture();
		string ChangePictureName(string newName);
	}
}
