using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Controls;
using Mono.Framework.Mvvm.Util;

namespace Mono.Framework.Mvvm.Behavior
{
    public class PanoramaBackgroundThemeBehavior : Behavior<Panorama>
    {
        public string SourcePath
        {
            get { return (string)GetValue(SourcePathProperty); }
            set { SetValue(SourcePathProperty, value); }
        }

        public static readonly DependencyProperty SourcePathProperty =
            DependencyProperty.Register("SourcePath", typeof(string), typeof(PanoramaBackgroundThemeBehavior), new PropertyMetadata(null, OnSourcePathChanged));

        private static void OnSourcePathChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var that = (PanoramaBackgroundThemeBehavior)sender;
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

            AssociatedObject.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(formattedPath, UriKind.Relative))
            };
        }
    }
}