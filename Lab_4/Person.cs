using System;

namespace Lab_1
{
    public class Person: Team
    {
        private string name;
        private string surname;
        private System.DateTime birth_date;

        public Person(string c_name, string c_surname, System.DateTime c_bd)
        {
            name = c_name;
            surname = c_surname;
            birth_date = c_bd;
        }

        public Person():this("Ivanov", "Ivanov", new DateTime(1000,01,01))
        {
            
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Surname
        {
            get => surname;
            set => surname = value;
        }

        public System.DateTime BirthDate
        {
            get => birth_date;
            set
            {
                birth_date = value;
            }
        }

        public int Year
        {
            get => birth_date.Year;
            set => birth_date = new DateTime(value, birth_date.Month, birth_date.Day);
        }

        public override string ToString()
        {
            return "Name: " + name + "\nSurname: " + surname + "\nBirth date: "+ birth_date;
        }

        public virtual string ToShortString()
        {
            return "Name: " + name + "\nSurname: " + surname;
        }

        protected static bool EqualsHelper(Person first, Person second)
        {
            return (first.Name == second.Name && first.Surname == second.Surname &&
                    first.BirthDate == second.birth_date);
        }

        public override bool Equals(object? obj)
        {
            if ((object)this == obj)
            {
                return true;
            }
            var new_person = obj as Person;
            if ((object) new_person == null)
            {
                return false;
            }
            return EqualsHelper(this, new_person);

        }
        
        public static bool operator ==(Person p1, Person p2)
        {
            if (ReferenceEquals(p1,p2))
            {
                return true;
            }
            
            if ((object)p1 == null || (object)p2 == null)
            {
                return false;
            }
            return EqualsHelper(p1,p2);
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() ^ surname.GetHashCode() ^ birth_date.GetHashCode();
        }

        public object DeepCopy()
        {
            DateTime timeCopy = new DateTime(this.BirthDate.Year, this.BirthDate.Month, this.BirthDate.Day);
            return new Person(this.Name, this.Surname, timeCopy);
        }
        
    }
}