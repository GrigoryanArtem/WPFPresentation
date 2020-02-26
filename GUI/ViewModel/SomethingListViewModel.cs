using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GUI.Messages;
using GUI.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace GUI.ViewModel
{
    public class SomethingListViewModel : ViewModelBase
    {
        private SomethingAPIClient _api;

        private SomethingViewModel _selected;
        private ObservableCollection<SomethingViewModel> _something;

        public SomethingListViewModel(SomethingAPIClient api)
        {
            _api = api;

            LoadDataCommand = new RelayCommand(LoadData);
            AddDataCommand = new RelayCommand(AddSomething);
            DeleteSomethingCommand = new RelayCommand<SomethingViewModel>(DeleteSomething);

            Messenger.Default.Register<UpdateSomethingMessage>(this, UpdateData);
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

        private async void LoadData()
        {
            var data = await _api.GetSomething();
            Something = new ObservableCollection<SomethingViewModel>(data.Select(s => new SomethingViewModel(s)));
        }

        private async void AddSomething()
        {
            var newObject = SomethingGenerator.Generate();
            var something = await _api.PostSomething(newObject);

            Something.Add(new SomethingViewModel(something));
        }

        private async void DeleteSomething(SomethingViewModel something)
        {
            await _api.DeleteSomething(something.Source);
            Something.Remove(something);
        }

        private async void UpdateData(UpdateSomethingMessage message)
        {
            await _api.UpdateSomething(message.Something);
        }
    }
}
