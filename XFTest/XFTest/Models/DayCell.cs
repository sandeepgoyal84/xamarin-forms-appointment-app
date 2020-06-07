using GalaSoft.MvvmLight;

namespace XFTest.Models
{
    public class DayCell : ObservableObject
    {
        private int _date;
        private string _day;
        private bool _isSelected;
        private bool _isVisible;

        public int Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Day
        {
            get => _day;
            set
            {
                if (_day != value)
                {
                    _day = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                if (_isVisible != value)
                {
                    _isVisible = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}