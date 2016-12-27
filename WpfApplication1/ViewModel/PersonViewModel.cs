using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Model;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace WpfApplication1.ViewModel
{
   public  class PersonViewModel:INotifyPropertyChanged
    {
       private Persons person;
       public PersonViewModel(Persons person)
       {
           this.person = person;
       }

        public string LName
        {
            set
            {
                person.LName = value;
                OnPropertyChanged("LName");
            }
            get
            {
                return person.LName;
            }
        }
        public string FName
        {
            set
            {
                person.FName = value;
                OnPropertyChanged("FName");
            }
            get
            {
                return person.FName;
            }
        }
        //public string MName
        //{
        //    set
        //    {
        //        person. = value;
        //        OnPropertyChanged("MName");
        //    }
        //    get
        //    {
        //        return mName;
        //    }
        //}
        public string Passport
        {
            set
            {
                person.Passport = value;
                OnPropertyChanged("Passport");
            }
            get
            {
                return person.Passport;
            }
        }
        public Persons Person
        {
            get
            {
                return this.person;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
