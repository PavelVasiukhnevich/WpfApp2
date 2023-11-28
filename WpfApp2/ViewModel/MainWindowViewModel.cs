using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp2.Model;
using WpfApp2.View;

namespace WpfApp2.ViewModel
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
        private CompanyDbContext dbContext;

        private CompanyPageViewModel companyPageViewModel;
        private Page companyPage;
        private PositionPageViewModel positionPageViewModel;
        private Page positionPage;
        private WorkerPageViewModel workerPageViewModel;
        private Page workerPage;

        private Page currentPage;
        public Page CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; OnPropertyChanged("CurrentPage"); }
        }

        public MainWindowViewModel()
        {
            dbContext = new CompanyDbContext();
            LoadPages();
        }

        private RelayCommand companyPageCommand;
        public RelayCommand CompanyPageCommand
        {
            get
            {
                return companyPageCommand ??
                  (companyPageCommand = new RelayCommand(obj =>
                  {
                      CompanyPage();
                  }));
            }
        }

        private RelayCommand workerPageCommand;
        public RelayCommand WorkerPageCommand
        {
            get
            {
                return workerPageCommand ??
                  (workerPageCommand = new RelayCommand(obj =>
                  {
                      WorkerPage();
                  }));
            }
        }
        private RelayCommand positionPageCommand;
        public RelayCommand PositionPageCommand
        {
            get
            {
                return positionPageCommand ??
                  (positionPageCommand = new RelayCommand(obj =>
                  {
                      PositionPage();
                  }));
            }
        }

        public void LoadPages()
        {
            companyPageViewModel = new CompanyPageViewModel(this);
            companyPage = new CompanyPage() { DataContext = companyPageViewModel };
            positionPageViewModel = new PositionPageViewModel(this);
            positionPage = new PositionPage() { DataContext = positionPageViewModel };
            workerPageViewModel = new WorkerPageViewModel(this);
            workerPage = new WorkerPage() { DataContext = workerPageViewModel };
        }

        public void CompanyPage()
        {
            CurrentPage = companyPage;
        }
        public void WorkerPage()
        {
            CurrentPage = workerPage;
        }
        public void PositionPage()
        {
            CurrentPage = positionPage;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
