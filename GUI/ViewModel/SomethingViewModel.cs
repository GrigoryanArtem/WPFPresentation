using API.Model.Data;
using GalaSoft.MvvmLight;
using System;

namespace GUI.ViewModel
{
    public class SomethingViewModel : ViewModelBase
    {
        public SomethingViewModel(Something something)
        {
            Source = something;
        }

        public Something Source { get; }

        public DateTime CreatedDate => Source.CreatedDateUTC.ToLocalTime();

        public string Name 
        {
            get => Source.Name; 
            set
            {
                Source.Name = value;
                RaisePropertyChanged();
            } 
        }


        public string Description
        {
            get => Source.Description;
            set
            {
                Source.Description = value;
                RaisePropertyChanged();
            }
        }

        public string StringField
        {
            get => Source.StringField;
            set
            {
                Source.StringField = value;
                RaisePropertyChanged();
            }
        }

        public int IntField
        {
            get => Source.IntField;
            set
            {
                Source.IntField = value;
                RaisePropertyChanged();
            }
        }

        public double DoubleField
        {
            get => Source.DoubleField;
            set
            {
                Source.DoubleField = value;
                RaisePropertyChanged();
            }
        }

        public Gender Gender
        {
            get => Source.Gender;
            set
            {
                Source.Gender = value;
                RaisePropertyChanged();
            }
        }
    }
}
