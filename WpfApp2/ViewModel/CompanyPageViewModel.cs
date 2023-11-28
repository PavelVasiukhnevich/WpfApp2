using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Model;

namespace WpfApp2.ViewModel
{
    public class CompanyPageViewModel : INotifyPropertyChanged
    {
        private MainWindowViewModel mainWindowViewModel;
        private CompanyDbContext dbContext;
        public ObservableCollection<Company> Companies
        {
            get { return new ObservableCollection<Company>(dbContext.Companys.ToList()); }
            set 
            {  
                OnPropertyChanged("Companies"); 
            }
        }
        private Company selectedCompany;
        public Company SelectedCompany
        {
            get { return selectedCompany; }
            set { selectedCompany = value; OnPropertyChanged("SelectedCompany"); }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Company company = SelectedCompany;
                      dbContext.Companys.Add(company);
                      dbContext.SaveChanges();
                      Companies = null;
                  }, obj=> SelectedCompany != null &&
                  SelectedCompany.Name != null && SelectedCompany.Name != ""));
            }
        }
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      dbContext.SaveChanges();
                      Companies = null;
                  }, obj=>SelectedCompany!=null && 
                  SelectedCompany.Name != null && SelectedCompany.Name!="" ));
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      dbContext.Companys.Remove(SelectedCompany);
                      dbContext.SaveChanges();
                      Companies = null;
                  }, obj=>SelectedCompany!=null&& Companies.Contains(SelectedCompany)));
            }
        }

        public CompanyPageViewModel(MainWindowViewModel mainWindowViewModel) 
        {
            dbContext = new CompanyDbContext();
            this.mainWindowViewModel = mainWindowViewModel;
            if (dbContext.Companys.Count() == 0)
                SelectedCompany = new Company();
            else
                SelectedCompany = Companies.FirstOrDefault();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
