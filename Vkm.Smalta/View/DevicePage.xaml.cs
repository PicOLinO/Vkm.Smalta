﻿#region Usings

using System.Windows.Controls;
using System.Windows.Navigation;
using Vkm.Smalta.Services;
using Vkm.Smalta.View.InnerPages.ViewModel;
using Vkm.Smalta.View.ViewModel;

#endregion

namespace Vkm.Smalta.View
{
    /// <summary>
    /// Interaction logic for DevicePage.xaml
    /// </summary>
    public partial class DevicePage : Page
    {
        public DevicePage()
        {
            InitializeComponent();
        }

        private void Frame_OnNavigated(object sender, NavigationEventArgs e)
        {
            var vm = (DevicePageViewModel) DataContext;
            vm.NavigateOnInnerPage(((MainInnerDevicePageViewModel)e.Content).PageKey);
        }
    }
}