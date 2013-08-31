using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mono.Framework.Mvvm.Behavior;

namespace MvvmMono.WP.UnitTest
{
    [TestClass]
    public class BehaviorTest
    {
        [TestMethod]
        public void WhenDarkThemeAndSwitchImageThemeBehaviorAttachedToImageExpectSourceReflected()
        {
            var image = new Image();
            Assert.IsNull(image.Source);
            var b = new SwitchImageThemeBehavior { SourcePath = "a/b/c.jpg" };
            b.Attach(image);
            Assert.AreEqual(@"a\b\c.dark.jpg", (image.Source as BitmapImage).UriSource.ToString());
        }

        [TestMethod]
        public void WhenAAA()
        {
            var panorama = new Panorama();
            Assert.IsNull(panorama.Background);
            var b = new PanoramaBackgroundSwitchBehavior { Type = "bbb" };
            b.ImagePairs = new List<ImagePair>
                {
                    new ImagePair { Type = "aaa", Path = "AAA" },
                    new ImagePair { Type = "bbb", Path = "BBB" },
                    new ImagePair { Type = "ccc", Path = "CCC" },
                };
            b.Attach(panorama);
            Assert.AreEqual("BBB", ((panorama.Background as ImageBrush).ImageSource as BitmapImage).UriSource.ToString());
            b.Type = "ccc";
            Assert.AreEqual("CCC", ((panorama.Background as ImageBrush).ImageSource as BitmapImage).UriSource.ToString());
            b.Type = "notExist";
            Assert.IsNull(panorama.Background);
        }
    }
}