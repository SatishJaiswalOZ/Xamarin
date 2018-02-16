using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XProficiencyExercise.Model;

namespace XProficiencyExercise.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        #region Attributes
        private FactsData model = new FactsData();
        private string title = string.Empty;
        #endregion

        #region Constructor
        public MainViewModel()
        {
            Facts mdata = model.GetFacts(true);
            Title = mdata.title;

            ChangeTextCommand = new Command(() =>
            {
                //Just for testing. Actual code will come.
                Title = "Satish";
            });

            foreach (var fact in mdata.rows)
            {
                if (!string.IsNullOrEmpty(fact.title))
                {
                    if (!string.IsNullOrEmpty(fact.description) && !string.IsNullOrEmpty(fact.imageHref))
                    {
                        Fact f = new Fact()
                        {
                            description = fact.description,
                            imageHref = fact.imageHref,
                            title = fact.title
                        };
                        Facts.Add(f);
                    }
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get data about facts
        /// </summary>
        public ObservableCollection<Fact> Facts { get; private set; } = new ObservableCollection<Fact>();

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

        #region Others
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisedPropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }

        public ICommand ChangeTextCommand
        {
            get;
        } 
        #endregion
    }
}
