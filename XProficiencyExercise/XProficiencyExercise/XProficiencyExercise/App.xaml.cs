using Xamarin.Forms;

namespace XProficiencyExercise
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            //for now assume this MainPage is common to both Android & iOS so kept in .NET Standard component.
			MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

	}
}
