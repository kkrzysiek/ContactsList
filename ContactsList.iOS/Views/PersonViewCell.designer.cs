// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ContactsList.iOS
{
    [Register ("PersonViewCell")]
    partial class PersonViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblFirstName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblLastName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView personImage { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblFirstName != null) {
                lblFirstName.Dispose ();
                lblFirstName = null;
            }

            if (lblLastName != null) {
                lblLastName.Dispose ();
                lblLastName = null;
            }

            if (personImage != null) {
                personImage.Dispose ();
                personImage = null;
            }
        }
    }
}