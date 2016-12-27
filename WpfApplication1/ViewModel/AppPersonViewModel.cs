using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Model;
using WpfApplication1.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApplication1.Commands;

namespace WpfApplication1.ViewModel
{
    class AppPersonViewModel:INotifyPropertyChanged
    {
        private CustomModel _db;
        public ObservableCollection<PersonViewModel> Persons {get;set;}
        private PersonViewModel selectedPerson=null;
        private PersonCommandType personCommandType;
        public PersonViewModel SelectedPerson
        {
            get
            {
                return selectedPerson;
            }
            set
            {
                selectedPerson = value;
                personCommandType = PersonCommandType.EditPerson;
                OnPropertyChanged("SelectedPerson");
            }
        }
        private RelayCommand addPerson;
        public RelayCommand AddPerson
        {
            get
            {
                return addPerson??(addPerson=new RelayCommand(obj=>{
                PersonViewModel person=new PersonViewModel(new Persons());
                    Persons.Add(person);
                    SelectedPerson=person;
                    personCommandType = PersonCommandType.AddPerson;
                }));
            }
        }
        private RelayCommand removePerson;
        public RelayCommand RemovePerson
        {
            get
            {
                return removePerson ?? (removePerson = new RelayCommand(obj =>
                {
                    PersonViewModel person = obj as PersonViewModel;
                    Persons.Remove(person);
                    PersonsCommands.RemovePerson(person.Person);
                },(obj)=>Persons.Any()));
            }
        }
        public RelayCommand savePerson;
        public RelayCommand SavePerson
        {
            get
            {
                return savePerson ?? (savePerson = new RelayCommand(obj =>
                {
                     PersonViewModel person = (PersonViewModel)obj;
                    switch(personCommandType)
                    {
                        case PersonCommandType.AddPerson:                           
                            PersonsCommands.AddPerson(person.Person);
                            break;
                        case PersonCommandType.EditPerson:
                            PersonsCommands.SaveChanges(person.Person);
                            break;
                    }
                    
                },obj=>selectedPerson!=null));
            }
        }

        public AppPersonViewModel()
        {
            _db = new CustomModel();
            PersonsCommands.DbContext = _db;
            Persons = new ObservableCollection<PersonViewModel>();
            foreach (var row in _db.Persons)
            {
                Persons.Add(new PersonViewModel(row));
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
