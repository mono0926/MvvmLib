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
using GalaSoft.MvvmLight.Messaging;
using Mono.Framework.Mvvm.Message;

namespace Mono.Framework.Mvvm.Behavior
{
    public class ShowMessageBoxAction : TriggerAction<FrameworkElement>
    {
        protected override void Invoke(object parameter)
        {
            var message = parameter as MyDialogMessage;
            if (message != null)
            {
#if SILVERLIGHT
                var result = MessageBox.Show(Content, Caption, Button);
                if (message.Callback != null)
                {
                    message.Callback(result);
                }
#else
                var result = MessageBox.Show(Content, Caption, Button);
                if (message.Callback != null)
                {
                    message.Callback(result);
                }
#endif
            }
        }

        public string Content
        {
            get { return (string)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(string), typeof(ShowMessageBoxAction), new PropertyMetadata(""));

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Caption.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(ShowMessageBoxAction), new PropertyMetadata(""));

        public MessageBoxButton Button
        {
            get { return (MessageBoxButton)GetValue(ButtonProperty); }
            set { SetValue(ButtonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Button.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonProperty =
            DependencyProperty.Register("Button", typeof(MessageBoxButton), typeof(ShowMessageBoxAction), new PropertyMetadata(MessageBoxButton.OKCancel));
    }
}