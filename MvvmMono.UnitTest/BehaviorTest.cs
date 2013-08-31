using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mono.Framework.Mvvm.Behavior;

namespace MvvmMono.UnitTest
{
    /// <summary>
    /// UnitTest1 の概要の説明
    /// </summary>
    [TestClass]
    public class BehaviorTest
    {
        public BehaviorTest()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///現在のテストの実行についての情報および機能を
        ///提供するテスト コンテキストを取得または設定します。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 追加のテスト属性

        //
        // テストを作成する際には、次の追加属性を使用できます:
        //
        // クラス内で最初のテストを実行する前に、ClassInitialize を使用してコードを実行してください
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // クラス内のテストをすべて実行したら、ClassCleanup を使用してコードを実行してください
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 各テストを実行する前に、TestInitialize を使用してコードを実行してください
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 各テストを実行した後に、TestCleanup を使用してコードを実行してください
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion 追加のテスト属性

        /// <summary>
        /// ImageにSwitchImageTypeBehaviorを添付すると、
        /// SourcePathのファイル名と拡張子の間に指定したTypeを挿入した画像リソースが
        /// ImageのSourceにセットされます。
        /// </summary>
        [TestMethod]
        public void WhenSwichImageTypeBehaviorAttachedToImageExpectSourceReflected()
        {
            var image = new Image();
            Assert.IsNull(image.Source);
            var b = new SwitchImageTypeBehavior { SourcePath = "a/b/c.jpg", Type = "type" };
            b.Attach(image);
            Assert.AreEqual(@"a\b\c.type.jpg", image.Source.ToString());
        }
    }
}