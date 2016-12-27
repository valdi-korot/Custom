using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Model;

namespace WpfApplication1.Commands
{
    enum PersonCommandType
    {
        AddPerson,
        EditPerson
    }
    public class PersonsCommands
    {
        private static CustomModel db;
        public static CustomModel DbContext
        {
            set
            {
                db = value;
            }
        }
        public static void AddPerson(Persons
            person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
        }
        public static void RemovePerson(Persons person){
            db.Persons.Remove(person);
            db.SaveChanges();
    }
        public static void SaveChanges(Persons person)
        {
            db.Entry(person).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
