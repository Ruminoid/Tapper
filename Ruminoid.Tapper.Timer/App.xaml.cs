﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MetroRadiance.UI;
using Ruminoid.Tapper.Timer.Windows;

namespace Ruminoid.Tapper.Timer
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DispatcherUnhandledException += (sender, args) =>
            {
                args.Handled = true;
                MessageBox.Show(
                    args.Exception.Message,
                    "灾难性故障",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error,
                    MessageBoxResult.OK);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                MessageBox.Show(
                    ((Exception)args.ExceptionObject)?.Message ?? "Exception",
                    "灾难性故障",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error,
                    MessageBoxResult.OK);
            };

            Timer.Properties.Resources.Culture = CultureInfo.CurrentUICulture;

            MainWindow ??= new MainWindow();
            MainWindow.Show();

            Current.Dispatcher?.Invoke(() => ThemeService.Current.ChangeTheme(Theme.Dark));
            Current.Dispatcher?.Invoke(() => ThemeService.Current.ChangeAccent(Accent.Blue));

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ThemeService.Current.Register(this, Theme.Windows, Accent.Windows);
        }
    }
}
