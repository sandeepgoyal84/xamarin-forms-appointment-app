using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;

namespace XFTest.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        private bool _refreshing;
        private string _title;
        private string _vmException;

        public ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            PageDialogService = pageDialogService;
        }

        public bool IsRefreshing
        {
            get => _refreshing;
            set
            {
                if (_refreshing != value)
                {
                    _refreshing = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string VmException
        {
            get => _vmException;
            set
            {
                if (value != null)
                {
                    _vmException = value;
                }
                //TODO logging to local files/webshare for debugging later
            }
        }

        protected INavigationService NavigationService { get; private set; }
        protected IPageDialogService PageDialogService { get; private set; }

        public virtual void Destroy()
        {
        }

        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        protected async Task ShowErrorDialog(string errMessage)
        {
            errMessage = string.IsNullOrEmpty(errMessage) ? "Error Occured. Please check your net connection." : errMessage;
            await PageDialogService.DisplayAlertAsync("Error",
                    errMessage,
                    "OK");
        }

        protected async Task<bool> HasExceptionfound(Exception ex)
        {
            if (ex == null) return false;

            VmException = ex.Message;
            await ShowErrorDialog(ex.Message);

            return true;
        }
    }
}