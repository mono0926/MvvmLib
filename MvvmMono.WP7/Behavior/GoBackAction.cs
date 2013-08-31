using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Mono.Framework.Mvvm.Behavior
{
    public class GoBackAction : TriggerAction<PhoneApplicationPage>
    {
        protected override void Invoke(object parameter)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (AssociatedObject.NavigationService.CanGoBack)
                {
                    AssociatedObject.NavigationService.GoBack();
                }
            });
        }
    }
}