using GalaSoft.MvvmLight;

namespace XFTest.Models
{
    public class DayCell : ObservableObject
    {
        private string _date;
        private string _day;
        private bool _isSelected;
        private bool _isVisible;

        public string Date
        {
            get => _date;
            set
            {
                _date = value;
                RaisePropertyChanged();
            }
        }

        public string Day
        {
            get => _day;
            set
            {
                _day = value;
                RaisePropertyChanged();
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                RaisePropertyChanged();
            }
        }

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                RaisePropertyChanged();
            }
        }
    }
}