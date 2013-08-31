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
using GalaSoft.MvvmLight;
using Microsoft.Phone.Controls;

namespace Mono.Framework.Mvvm.View
{
    public class MonoPage : PhoneApplicationPage
    {
        public static ViewModelBase ViewModelContainer { get; set; }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (ViewModelContainer != null)
            {
                this.DataContext = ViewModelContainer;
                ViewModelContainer = null;
            }
        }
    }
}