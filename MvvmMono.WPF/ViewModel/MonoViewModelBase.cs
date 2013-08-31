using System;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace Mono.Framework.Mvvm.ViewModel
{
    public abstract class MonoViewModelBase : ViewModelBase
    {
        private Messenger messenger;

        public Messenger Messenger
        {
            get
            {
                if (messenger == null)
                {
                    messenger = new Messenger();
                }
                return messenger;
            }
        }

        public IMessenger GlobalMessenger
        {
            get
            {
                return Messenger.Default;
            }
        }

#if SILVERLIGHT
        private Dispatcher dispatcher = Deployment.Current.Dispatcher;
#else
        private Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
#endif

        public void ExecuteOnUIThread(Action action)
        {
            //var dispatcher = Deployment.Current.Dispatcher;

            if (dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                dispatcher.BeginInvoke(action);
            }
        }

        public void ExecuteOnBackgroundThread(Action action)
        {
            var thread = new Thread(new ThreadStart(action));
            thread.Start();
        }

        public bool IsDark { get { return IsDarkStatic; } }

        private static bool? isDarkStatic;

        public static bool IsDarkStatic
        {
            get
            {
                if (!isDarkStatic.HasValue)
                {
                    Visibility light = (Visibility)Application.Current.Resources["PhoneLightThemeVisibility"];
                    Visibility dark = (Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"];
                    if (dark == Visibility.Visible)
                    {
                        isDarkStatic = true;
                    }
                    else
                    {
                        isDarkStatic = false;
                    }
                }
                return isDarkStatic.Value;
            }
        }
    }
}