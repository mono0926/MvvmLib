using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using Microsoft.Phone.Controls;
using Mono.Framework.Mvvm.ViewModel;

namespace Mono.Framework.Mvvm.Behavior
{
    public class PanoramaBackgroundSwitchBehavior : Behavior<Panorama>
    {
        public string Type
        {
            get { return (string)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(string), typeof(PanoramaBackgroundSwitchBehavior), new PropertyMetadata(null, OnTypeChaged));

        private static void OnTypeChaged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var that = (PanoramaBackgroundSwitchBehavior)sender;
            that.SetImageSource();
        }

        public List<ImagePair> ImagePairs
        {
            get { return (List<ImagePair>)GetValue(ImagePairsProperty); }
            set { SetValue(ImagePairsProperty, value); }
        }

        public static readonly DependencyProperty ImagePairsProperty =
            DependencyProperty.Register("ImagePairs", typeof(List<ImagePair>), typeof(PanoramaBackgroundSwitchBehavior), new PropertyMetadata(new List<ImagePair>()));

        protected override void OnAttached()
        {
            SetImageSource();
        }

        private void SetImageSource()
        {
            if (AssociatedObject == null)
            {
                return;
            }
            var ip = ImagePairs.FirstOrDefault(x => x.Type == this.Type);
            if (ip == null)
            {
                AssociatedObject.Background = null;
                return;
            }
            AssociatedObject.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri(ip.Path, UriKind.Relative))
            };
        }
    }
}