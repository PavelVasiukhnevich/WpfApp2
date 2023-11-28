using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
    public class Worker : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }
        private DateTime dateBirth;
        public DateTime ВateBirth
        {
            get { return dateBirth; }
            set { dateBirth = value; OnPropertyChanged("ВateBirth"); }
        }
        private Company company;
        public Company Company
        {
            get { return company; }
            set { company = value; OnPropertyChanged("Company"); }
        }
        private Position position;
        public Position Position
        {   get { return position; }
            set { position=value; OnPropertyChanged("Position"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
