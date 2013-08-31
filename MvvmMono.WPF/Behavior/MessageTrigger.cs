using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;

namespace Mono.Framework.Mvvm.Behavior
{
    public class MessageTrigger : TriggerBase<FrameworkElement>
    {
        public Messenger Messenger
        {
            get { return (Messenger)GetValue(MessengerProperty); }
            set { SetValue(MessengerProperty, value); }
        }

        public static readonly DependencyProperty MessengerProperty =
            DependencyProperty.Register("Messenger", typeof(Messenger), typeof(MessageTrigger), new PropertyMetadata(MessengerChanged));

        public string MessageKey
        {
            get { return (string)GetValue(MessageKeyProperty); }
            set { SetValue(MessageKeyProperty, value); }
        }

        public static readonly DependencyProperty MessageKeyProperty =
            DependencyProperty.Register("MessageKey", typeof(string), typeof(MessageTrigger), new PropertyMetadata(null));

        private static void MessengerChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var thisReference = (MessageTrigger)sender;

            if (e.OldValue != null)
            {
                var oldMessenger = (Messenger)e.OldValue;
                oldMessenger.Unregister(thisReference);
            }

            if (e.NewValue != null)
            {
                var newMessenger = (Messenger)e.NewValue;
                newMessenger.Register<GenericMessage<string>>(thisReference, true, m =>
                {
#if SILVERLIGHT

                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                   {
                       if (m.Content == thisReference.MessageKey)
                       {
                           thisReference.InvokeActions(m);
                       }
                   });
#else
                    Dispatcher.CurrentDispatcher.BeginInvoke((Action)(() =>
                    {
                        if (m.Content == thisReference.MessageKey)
                        {
                            thisReference.InvokeActions(m);
                        }
                    }));

#endif
                });
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
        }
    }
}