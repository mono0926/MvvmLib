using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using Mono.Framework.Mvvm.Util;
using Mono.Framework.Mvvm.ViewModel;

namespace Mono.Framework.Mvvm.Behavior
{
    public class SwitchImageThemeBehavior : Behavior<Image>
    {
        public string SourcePath
        {
            get { return (string)GetValue(SourcePathProperty); }
            set { SetValue(SourcePathProperty, value); }
        }

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
            var type = Platform.IsDarkTheme ? "dark" : "light";
            var filename = Path.GetFileNameWithoutExtension(path);
            var formattedPath = Path.Combine(Path.GetDirectoryName(path), string.Format("{0}.{1}{2}", filename, type, Path.GetExtension(path)));

            AssociatedObject.Source = new BitmapImage(new Uri(formattedPath, UriKind.RelativeOrAbsolute));
        }
    }
}