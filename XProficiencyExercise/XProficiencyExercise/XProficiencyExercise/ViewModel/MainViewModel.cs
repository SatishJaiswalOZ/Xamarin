using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XProficiencyExercise.ViewModel
{
    class MainViewModel:INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Title = "About Canada";
            ChangeTextCommand = new Command(() =>
            {
                Title = "Satish";
            });

            for(int i=0;i<6;i++)
            {
                Fact f = new Fact() {
                    Description = "Hello dasdsadsadsadsadasdsadadssxczcasdsaxz " + i.ToString(),
                    ImageUrl = "http://3.bp.blogspot.com/__mokxbTmuJM/RnWuJ6cE9cI/AAAAAAAAATw/6z3m3w9JDiU/s400/019843_31.jpg",
                    Title = "Canada xzcsarefczdcsefdczxcsdgrefascxzcsderewdczxc sdgewfedsacxsefewfeczxcxzcgvrgfeasczcsdgfewf" + i.ToString() };
                Facts.Add(f);
            }
        }

        private string title = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisedPropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisedPropertyChanged();
            }
        }

        public ICommand ChangeTextCommand
        {
            get;
        }

        public ObservableCollection<Fact> Facts { get; set; } = new ObservableCollection<Fact>();
    }
}
