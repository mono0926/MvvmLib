using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace Mono.Framework.Mvvm.Message
{
    public class MyDialogMessage : GenericMessage<string>
    {
        public MyDialogMessage(string key)
            : base(key)
        {
        }

        public MyDialogMessage(string key, Action<MessageBoxResult> callback)
            : this(key)
        {
            this.Callback = callback;
        }

        public Action<MessageBoxResult> Callback { get; set; }
    }
}