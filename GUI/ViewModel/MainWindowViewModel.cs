using API.Model.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using GUI.Model;
using System.Collections.ObjectModel;

namespace GUI.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Members

        private SomethingViewModel _selected;
        private ObservableCollection<SomethingViewModel> _something;
        private SomethingAPIClient _api;

        #endregion

        public MainWindowViewModel(SomethingAPIClient api)
        {
            LoadDataCommand = new RelayCommand(async () => await LoadData());
            AddDataCommand = new RelayCommand(async () => await AddSomething());
            DeleteSomethingCommand = new RelayCommand<SomethingViewModel>(async (something) => await DeleteSomething(something));

            _api = api;
        }

        public SomethingViewModel Selected
        {
            get => _selected;
            set => Set(ref _selected, value);
        }

        public ObservableCollection<SomethingViewModel> Something 
        { 
            get => _something;
            set => Set(ref _something, value); 
        }

        public RelayCommand LoadDataCommand { get; }
        public RelayCommand AddDataCommand { get; }
        public RelayCommand<SomethingViewModel> DeleteSomethingCommand { get; }

        private async Task LoadData()
        {
            var data = await _api.GetSomething();
            Something = new ObservableCollection<SomethingViewModel>(data.Select(s => new SomethingViewModel(s)));
        }

        private async Task AddSomething()
        {
            var newObject = SomethingGenerator.Generate();
            var something = await _api.PostSomething(newObject);

            Something.Add(new SomethingViewModel(something));
        }

        private async Task DeleteSomething(SomethingViewModel something)
        {
            await _api.DeleteSomething(something.Source);
            Something.Remove(something);
        }
    }
}