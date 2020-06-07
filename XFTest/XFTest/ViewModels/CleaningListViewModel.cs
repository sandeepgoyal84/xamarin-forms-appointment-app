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

        public CleaningListViewModel(INavigationService navigationService, IPageDialogService pageDialogService, ICleanerListService cleanerListService)
: base(navigationService, pageDialogService)
        {
            _cleanerListService = cleanerListService;
            CleaningLists = new ObservableCollection<CleaningList>();
            CleaningDate = DateTime.Today;
            RefreshCommand = new Command(() => { RefreshViewModelTask(CleaningDate); });
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
                RefreshViewModelTask(CleaningDate);
            }
        }

        public ObservableCollection<CleaningList> CleaningLists { get; set; }

        public ICommand RefreshCommand { get; set; }

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
                    foreach (var cleaningList in cleaningListResponse.Result)
                    {
                        sourceLat = sourceLat == default(double) ? cleaningList.OwnerLatitude : sourceLat;
                        sourceLon = sourceLon == default(double) ? cleaningList.OwnerLongitude : sourceLon;
                        cleaningList.Distance = Calculator.Distance(sourceLat, sourceLon, cleaningList.OwnerLatitude, cleaningList.OwnerLongitude);
                        CleaningLists.Add(cleaningList);
                        sourceLat = cleaningList.OwnerLatitude;
                        sourceLon = cleaningList.OwnerLongitude;
                    }
                    //IsBusy = false;
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