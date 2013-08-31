using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace Mono.Framework.Mvvm.Message
{
    public class NavigationMessage : GenericMessage<string>
    {
        public NavigationMessage(Uri uri, ViewModelBase viewmodel, string key)
            : base(key)
        {
            ViewModel = viewmodel;
            Uri = uri;
        }

        public ViewModelBase ViewModel
        {
            get;
            private set;
        }

        public Uri Uri
        {
            get;
            private set;
        }
    }
}