using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using XFTest.Common;
using XFTest.Infrastructure.Contracts;
using XFTest.Models;

namespace XFTest.ViewModels
{
    public class CleaningListViewModel : ViewModelBase
    {
        private readonly ICleanerListService _cleanerListService;
        private DateTime _cleaningDate = DateTime.Now;
        private bool _isCalendarVisible = false;
        private ObservableCollection<CleaningList> _cleaningLists;

        public CleaningListViewModel(INavigationService navigationService, IPageDialogService pageDialogService
            , ICleanerListService cleanerListService) : base(navigationService, pageDialogService)
        {
            _cleanerListService = cleanerListService;
            CleaningLists = new ObservableCollection<CleaningList>();
            CleaningDate = DateTime.Today;
            RefreshCommand = new Command(() => { RefreshViewModelTask(CleaningDate); });
            ShowHideCalendarCommand = new Command((visiblityStatus) => { IsCalendarVisible = (bool)visiblityStatus; });
            RefreshViewModelTask(CleaningDate);
        }

        public DateTime CleaningDate
        {
            get => _cleaningDate;
            set
            {
                _cleaningDate = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(SubTitle));
                RefreshViewModelTask(_cleaningDate);
            }
        }

        public ObservableCollection<CleaningList> CleaningLists
        {
            get => _cleaningLists; set
            {
                _cleaningLists = value;
                RaisePropertyChanged(nameof(HaveAnyTask));
            }
        }

        public ICommand RefreshCommand { get; set; }
        public ICommand ShowHideCalendarCommand { get; set; }
        public bool HaveAnyTask { get=> CleaningLists.Count>0;}
        public bool IsCalendarVisible
        {
            get => _isCalendarVisible; set
            {
                _isCalendarVisible = value;
                RaisePropertyChanged();
            }
        }

        public string SubTitle
        {
            get { return CleaningDate.ToShortDateString() == DateTime.Today.ToShortDateString() ? "I Dag" : CleaningDate.ToString("dd MMM yyyy"); }
            //set { /*SetProperty(*/ref _title, value); }
        }
        private async void RefreshViewModelTask(DateTime cleanListDate)
        {
            try
            {
                if (!IsRefreshing)
                {
                    IsRefreshing = true;
                    var cleaningListResponse = await _cleanerListService.GetDailyTasks(cleanListDate);
                    if (await HasExceptionfound(cleaningListResponse.Exception)) return;
                    if (cleaningListResponse.Exception != null)
                    {
                        //IsBusy = false;
                        IsRefreshing = false;
                        VmException = cleaningListResponse.Exception.Message;
                        await ShowNetworkErrorDialog().ConfigureAwait(false);
                        return;
                    }
                    CleaningLists.Clear();
                    double sourceLat = default;
                    double sourceLon = default;
                    int i = 0;
                    foreach (var cleaningList in cleaningListResponse.Result)
                    {
                        sourceLat = sourceLat == default(double) ? cleaningList.OwnerLatitude : sourceLat;
                        sourceLon = sourceLon == default(double) ? cleaningList.OwnerLongitude : sourceLon;
                        cleaningList.Distance = Calculator.Distance(sourceLat, sourceLon, cleaningList.OwnerLatitude, cleaningList.OwnerLongitude);
                        i++;
                        if (i < 9) CleaningLists.Add(cleaningList);
                        sourceLat = cleaningList.OwnerLatitude;
                        sourceLon = cleaningList.OwnerLongitude;
                    }
                    //IsBusy = false;
                    RaisePropertyChanged(nameof(HaveAnyTask));
                    IsRefreshing = false;

                }
            }
            catch (Exception ex)
            {
                await ShowNetworkErrorDialog();
            }
            finally
            {
                //IsBusy = false;
                IsRefreshing = false;
            }
        }
    }
}