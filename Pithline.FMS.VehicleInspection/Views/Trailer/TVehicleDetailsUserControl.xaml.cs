﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Pithline.FMS.VehicleInspection.UILogic.ViewModels;
using Pithline.FMS.BusinessLogic;
using System.Runtime.Serialization;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Pithline.FMS.VehicleInspection.Views
{
    public sealed partial class TVehicleDetailsUserControl : UserControl
    {
        public TVehicleDetailsUserControl()
        {
            this.InitializeComponent();
        }

        async private void TakePicture_Tapped(object sender, TappedRoutedEventArgs e)
        {
           //var vm = (VehicleDetailsUserControlViewModel)this.DataContext;
           // var img = (Image)sender;
           // await vm.TakePictureAsync(img.Source as ImageCapture);
        }
    }
}
