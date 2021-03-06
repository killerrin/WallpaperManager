﻿using KillerrinStudiosToolkit;
using KillerrinStudiosToolkit.UserProfile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using AdvancedWallpaperManager.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AdvancedWallpaperManager.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomeViewModel ViewModel { get { return (HomeViewModel)DataContext; } }

        public HomePage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.Loaded();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.OnNavigatedTo();
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.OnNavigatedFrom();
            base.OnNavigatedFrom(e);
        }

        private void ActiveThemeGridTapped_OpenFlyout(object sender, RightTappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout(sender as FrameworkElement);
        }

        private async void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TestInput.Text))
            {
                var folder = await StorageTask.Instance.GetFolder(StorageTask.LocalFolder, LockscreenManager.LockscreenImagesFolderName);
                var items = await StorageTask.Instance.GetAllFilesInFolder(folder);
                CurrentLockscreenImage.Source = new BitmapImage(new Uri(items[0].Path));
            }
            else
            {
                var file = await StorageTask.Instance.GetFileFromPath(new Uri(TestInput.Text));
                var bitmapImage = await StorageTask.StorageFileToBitmapImage(file);
                CurrentLockscreenImage.Source = bitmapImage;
            }
        }
    }
}
