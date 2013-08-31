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

namespace Mono.Framework.Mvvm.Behavior
{
    public class ShowMessageBoxBehavior : Behavior<FrameworkElement>
    {
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(ShowMessageBoxBehavior), new PropertyMetadata(string.Empty, MessageChanged));

        public static void MessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var msg = e.NewValue as string;
            if (!string.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg);
            }
        }
    }
}