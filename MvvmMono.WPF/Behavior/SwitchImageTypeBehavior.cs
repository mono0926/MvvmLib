using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using Mono.Framework.Mvvm.ViewModel;

namespace Mono.Framework.Mvvm.Behavior
{
    public class SwitchImageTypeBehavior : Behavior<Image>
    {
        public string SourcePath
        {
            get { return (string)GetValue(SourcePathProperty); }
            set { SetValue(SourcePathProperty, value); }
        }

        public static readonly DependencyProperty SourcePathProperty =
            DependencyProperty.Register("SourcePath", typeof(string), typeof(SwitchImageTypeBehavior), new PropertyMetadata(null, OnSourcePathChanged));

        private static void OnSourcePathChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var that = (SwitchImageTypeBehavior)sender;
            that.SetImageSource(e.NewValue as string, that.Type);
        }

        public string Type
        {
            get { return (string)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(string), typeof(SwitchImageTypeBehavior), new PropertyMetadata(null, OnTypeChaged));

        private static void OnTypeChaged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var that = (SwitchImageTypeBehavior)sender;
            that.SetImageSource(that.SourcePath, e.NewValue as string);
        }

        protected override void OnAttached()
        {
            SetImageSource(SourcePath, Type);
        }

        private void SetImageSource(string path, string type)
        {
            if (AssociatedObject == null || string.IsNullOrEmpty(path))
            {
                return;
            }
            var formattedPath = path;
            if (!string.IsNullOrEmpty(type))
            {
                var filename = Path.GetFileNameWithoutExtension(path);
                formattedPath = Path.Combine(Path.GetDirectoryName(path), string.Format("{0}.{1}{2}", filename, type, Path.GetExtension(path)));
            }
            AssociatedObject.Source = new BitmapImage(new Uri(formattedPath, UriKind.RelativeOrAbsolute));
        }
    }
}