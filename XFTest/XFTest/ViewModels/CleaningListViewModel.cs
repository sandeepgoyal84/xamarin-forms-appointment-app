using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XFTest.Infrastructure.Contracts;
using XFTest.Models;

namespace XFTest.ViewModels
{
    public class CleaningListViewModel : ViewModelBase
    {
        private readonly ICleanerListService _cleanerListService;
        public ObservableCollection<CleaningList> CleaningLists { get; set; }

        public CleaningListViewModel(INavigationService navigationService, IPageDialogService pageDialogService, ICleanerListService cleanerListService)
            : base(navigationService, pageDialogService)
        {
            _cleanerListService = cleanerListService;
            Title = "I Dag";

            IsBusy = true;
            _cleanerListService = cleanerListService;
            CleaningLists = new ObservableCollection<CleaningList>();

            Task.Run((Action)RefreshViewModelTask);
        }

        private async void RefreshViewModelTask()
        {
            try
            {
                if (!IsDataRefreshing)
                {
                    IsDataRefreshing = true;
                    var cleaningListResponse = await _cleanerListService.GetDailyTasks();
                    if (await HasExceptionfound(cleaningListResponse.Exception)) return;
                    if (cleaningListResponse.Exception != null)
                    {
                        IsBusy = false;
                        IsDataRefreshing = false;
                        VmException = cleaningListResponse.Exception.Message;
                        await ShowNetworkErrorDialog().ConfigureAwait(false);
                        return;
                    }
                    CleaningLists.Clear();
                    foreach (var cleaningList in cleaningListResponse.Result)
                    {
                        CleaningLists.Add(cleaningList);
                    }
                    IsBusy = false;
                    IsDataRefreshing = false;
                }
            }
            catch (Exception ex) {
                var dd = ex;
            }
            finally
            {
                IsBusy = false;
                IsDataRefreshing = false;
            }
        }
    }
}