using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Krillin.App.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            this.app = AppInitializer.StartApp(this.platform);
            this.app.Screenshot("First screen.");
        }

        [Test]
        public void WhenInitApp_ListViewIsFilled()
        {
            this.app.WaitForElement("ListPost", timeout: TimeSpan.FromSeconds(20));
            AppResult[] result = this.app.Query(x => x.Marked("ListPost").Child());
            Assert.IsTrue(result.Length > 0);
        }

        [Test]
        public void TouchInACell_NavigateToDetail()
        {
            this.app.WaitForElement("ListPost", timeout: TimeSpan.FromSeconds(20));

            if (this.platform == Platform.Android)
                this.app.Tap(x => x.Class("ListViewRenderer").Child(0));
            else if (this.platform == Platform.iOS)
                this.app.Tap(x => x.Class("UITableView").Child(0));

            this.app.WaitForNoElement("ListPost");
        }
    }
}

