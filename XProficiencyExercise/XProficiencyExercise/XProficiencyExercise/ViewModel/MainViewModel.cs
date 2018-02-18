using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using XProficiencyExercise.Model;
using System.Collections.Generic;

namespace XProficiencyExercise.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Attributes
        private FactsData model = new FactsData();
        private string title = string.Empty;
        private Facts mdata;
        private bool isAscending;
        private ObservableCollection<Fact> dataItems;
        #endregion

        #region Constructor
        public MainViewModel()
        {
            mdata = FactsData.GetFacts(true);
            Title = mdata.title;

            RefreshCommand = new Command(() =>
            {
                refresh();
            });

            SortCommand = new Command(() =>
            {
                sort();
            });
            Facts = new ObservableCollection<Fact>(mdata.rows);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get data about facts
        /// </summary>
        public ObservableCollection<Fact> Facts
        {
            get { return dataItems ?? (dataItems = new ObservableCollection<Fact>()); }
            set { dataItems = value; RaisedPropertyChanged(); }
        }

        /// <summary>
        /// Get title
        /// </summary>
        //Setter infact is not required for now
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisedPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get;
        }

        public ICommand SortCommand
        {
            get;
        }
        #endregion

        #region Others
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisedPropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }

        private void sort()
        {
            List<Fact> sortedData;
            if (!isAscending)
            {
                isAscending = true;
                sortedData = mdata.rows.OrderBy(item => item.title).ToList<Fact>();
            }
            else
            {
                isAscending = false;
                sortedData = mdata.rows.OrderByDescending(item => item.title).ToList<Fact>();
            }

            Facts.Clear();
            Facts = new ObservableCollection<Fact>(sortedData);
        }

        private void refresh()
        {
            var freshData = FactsData.GetFacts(true);
            Title = freshData.title;

            //initialize at the launch
            Facts = new ObservableCollection<Fact>(freshData.rows);
        }
        #endregion
    }
}
