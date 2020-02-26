using GalaSoft.MvvmLight;
using GUI.Model;

namespace GUI.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(SomethingAPIClient api)
        {
            SomethingList = new SomethingListViewModel(api);
        }

        public SomethingListViewModel SomethingList { get; }
    }
}