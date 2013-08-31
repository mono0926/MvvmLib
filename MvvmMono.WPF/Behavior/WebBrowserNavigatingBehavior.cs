using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;

#if WINDOWS_PHONE
using Microsoft.Phone.Controls;
#endif

namespace Mono.Framework.Mvvm.Behavior
{
    public class WebBrowserNavigatingBehavior : Behavior<WebBrowser>
    {
        public string NavigatingUrl
        {
            get { return (string)GetValue(NavigatedUrlProperty); }
            set { SetValue(NavigatedUrlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NavigatedUrl.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NavigatedUrlProperty =
            DependencyProperty.Register("NavigatingUrl", typeof(string), typeof(WebBrowserNavigatingBehavior), new PropertyMetadata(""));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(WebBrowserNavigatingBehavior), new PropertyMetadata(""));

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Navigating += AssociatedObject_Navigating;

            AssociatedObject.LoadCompleted += AssociatedObject_LoadCompleted;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Navigating -= AssociatedObject_Navigating;
            AssociatedObject.LoadCompleted -= AssociatedObject_LoadCompleted;
        }

#if SILVERLIGHT
        private void AssociatedObject_Navigating(object sender, NavigatingEventArgs e)
        {
            NavigatingUrl = e.Uri.ToString();
        }
#else

        private void AssociatedObject_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            NavigatingUrl = e.Uri.ToString();
        }

#endif

        private void AssociatedObject_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            try
            {
                Title = AssociatedObject.InvokeScript("eval", "document.title").ToString();
            }
            catch (SystemException)
            {
                System.Diagnostics.Debug.WriteLine("fail to get title");
            }
        }
    }
}