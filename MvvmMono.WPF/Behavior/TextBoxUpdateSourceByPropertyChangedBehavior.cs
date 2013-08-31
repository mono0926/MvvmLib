using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Mono.Framework.Mvvm.Behavior
{
    public class TextBoxUpdateSourceByPropertyChangedBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.TextChanged += (sender, e) =>
            {
                var binding = AssociatedObject.GetBindingExpression(TextBox.TextProperty);
                binding.UpdateSource();
            };
        }
    }
}