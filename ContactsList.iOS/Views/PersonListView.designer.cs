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
    [Register ("PersonListView")]
    partial class PersonListView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView savedPersonTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (savedPersonTableView != null) {
                savedPersonTableView.Dispose ();
                savedPersonTableView = null;
            }
        }
    }
}