using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
    public class Company : INotifyPropertyChanged
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
            set { name=value; OnPropertyChanged("Name"); }
        }
        private DateTime dateCreate;
        public DateTime DateCreate
        {
            get { return dateCreate; }
            set { dateCreate = value; OnPropertyChanged("DateCreate"); }
        }

        private ICollection<Worker> workers;
        public ICollection<Worker> Workers
        {
            get { return workers; }
            set { workers = value; OnPropertyChanged("Workers"); }
        }

        public string WorkersCount => Workers!=null? Workers.Count().ToString():"0";
        public Company()
        {
            Workers = new List<Worker>();
            DateCreate = DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
