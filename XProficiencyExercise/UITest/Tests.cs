using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest
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
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Repl();
            app.Screenshot("First Screen");
        }

        [Test,Category("Feed Display")]
        public void ListViewEmptyDescription()
        {
            // Wait for the Activity to load
            app.WaitForElement(c => c.Marked("lblHeaderTitle"));

            //get first list of items 
            AppResult[] results = app.Query("lblDescription");

            foreach(var item in results)
            {
                Assert.IsFalse(item.Text.Length > 0,item.Label+ " :Description cannot be empty.Display of such item is not allowed");
            }

            //to get further items of list view & check for the same.
            //app.ScrollDownTo(...);
        }

        /// <summary>
        /// This Test case is introduced as part of bug fix.
        /// Check FactsData.cs line 27. Commenting line 27 will produce the issue.
        /// </summary>
        [Test, Category("Feed Display")]
        public void ListViewNoTitle()
        {
            // Wait for the Activity to load
            app.WaitForElement(c => c.Marked("lblHeaderTitle"));

            //get first list of items 
            AppResult[] results = app.Query("lblTitle");

            foreach (var item in results)
            {
                Assert.IsFalse(item.Text.Length > 0, "Content without title should not be displayed.");
            }

            //to get further items of list view & check for the same.
            //app.ScrollDownTo(...);
        }
    }
}

