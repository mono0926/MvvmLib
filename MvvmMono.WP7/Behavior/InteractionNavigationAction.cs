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
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using Microsoft.Phone.Controls;
using Mono.Framework.Mvvm.Message;
using Mono.Framework.Mvvm.View;

namespace Mono.Framework.Mvvm.Behavior
{
    public class InteractionNavigationAction : TriggerAction<PhoneApplicationPage>
    {
        protected override void Invoke(object parameter)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                var transitionMessage = (NavigationMessage)parameter;
                MonoPage.ViewModelContainer = transitionMessage.ViewModel;
                AssociatedObject.NavigationService.Navigate(transitionMessage.Uri);
            });
        }
    }
}