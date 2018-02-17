using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XProficiencyExercise.ViewModel;

namespace XProficiencyExercise
{
	public partial class MainPage : ContentPage
	{
        MainViewModel vm;

		public MainPage()
		{
			InitializeComponent();
            vm = new MainViewModel();
            BindingContext = vm;
        }
    } 
}
