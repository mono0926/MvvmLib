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
    public class CompressionAction : TriggerAction<ListBox>
    {
        private VisualStateGroup vgroup;

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(CompressionAction), new PropertyMetadata(null));

        private VisualStateGroup GetVGroup()
        {
            VisualStateGroup vgroup = null;

            // ListBox の初めに定義されている ScrollViewerを取り出す
            //AssociatedObject.ApplyTemplate();
            var ListboxScrollViewer = VisualTreeHelper.GetChild(AssociatedObject, 0);

            // Visual State はコントロールテンプレートの常に最上位に定義されている
            var element = (FrameworkElement)VisualTreeHelper.GetChild(ListboxScrollViewer, 0);
            // Visual State を取り出しその中から 縦横Compression のVisualStateを取り出す
            foreach (VisualStateGroup group in VisualStateManager.GetVisualStateGroups(element))
                if (group.Name == "VerticalCompression")
                {
                    vgroup = group;
                }
            return vgroup;
        }

        protected override void Invoke(object parameter)
        {
            vgroup = GetVGroup();
            //縦横Compressionの状態が変わった時のイベントハンドラ
            vgroup.CurrentStateChanging += vgroup_CurrentStateChanging;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            vgroup.CurrentStateChanging -= vgroup_CurrentStateChanging;
        }

        private void vgroup_CurrentStateChanging(object sender, VisualStateChangedEventArgs e)
        {
            Command.Execute(null);
        }
    }
}