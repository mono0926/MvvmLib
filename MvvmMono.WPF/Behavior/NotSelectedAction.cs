using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Mono.Framework.Mvvm.Behavior
{
    public class NotSelectedAction : TriggerAction<Selector>
    {
        protected override void Invoke(object parameter)
        {
            AssociatedObject.SelectedItem = null;
        }
    }
}