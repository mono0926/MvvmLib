using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MvvmMono;

namespace Mono.Framework.Mvvm.Util
{
    public static class Platform
    {
        public static bool IsDarkTheme
        {
            get
            {
                var light = (Visibility)App.Current.Resources["PhoneLightThemeVisibility"];
                var dark = (Visibility)App.Current.Resources["PhoneDarkThemeVisibility"];
                if (dark == System.Windows.Visibility.Visible)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
