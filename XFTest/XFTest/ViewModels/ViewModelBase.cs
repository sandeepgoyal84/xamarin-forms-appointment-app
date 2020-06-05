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
                _refreshing = value;
                RaisePropertyChanged();
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
                //TODO openup
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

        protected async Task ShowNetworkErrorDialog()
        {
            await PageDialogService.DisplayAlertAsync("Error",
                    "Netwrok error. Please check your net connection",
                    "OK");
        }

        protected async Task<bool> HasExceptionfound(Exception ex)
        {
            if (ex == null) return false;

            VmException = ex.Message;
            await ShowNetworkErrorDialog();

            return true;
        }
    }
}