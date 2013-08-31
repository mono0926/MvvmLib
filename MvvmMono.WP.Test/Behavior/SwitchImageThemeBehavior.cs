using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using GalaSoft.MvvmLight;
using Mono.Framework.Mvvm.ViewModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System;

namespace Mono.Framework.Mvvm.Test.Behavior
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class SwitchImageThemeBehavior : Behavior<Image>
    {


        public string SourcePath
        {
            get { return (string)GetValue(SourcePathProperty); }
            set { SetValue(SourcePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SourcePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourcePathProperty =
            DependencyProperty.Register("SourcePath", typeof(string), typeof(SwitchImageThemeBehavior), new PropertyMetadata(null, OnSourcePathChanged));

        private static void OnSourcePathChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var that = (SwitchImageThemeBehavior)sender;
            that.SetImageSource(e.NewValue as string);
        }

        protected override void OnAttached()
        {
            SetImageSource(SourcePath);
        }

        private void SetImageSource(string path)
        {
            if (AssociatedObject == null || string.IsNullOrEmpty(path))
            {
                return;
            }
            AssociatedObject.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
        }
    }
}