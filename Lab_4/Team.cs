using System;

namespace Lab_1
{
    public class Team: INameAndCopy
    {
        protected string org_name;
        protected int reg_number;

        public Team(string name, int number)
        {
            org_name = name;
            reg_number = number;
        }
        
        public Team():this("Default organization", 1234)
        {
            
        }

        public string OrgName
        {
            get => org_name;
            set => org_name = value;
        }

        public int RegNumber
        {
            get => reg_number;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Registration number can't be less than or equal to 0");
                }
                else
                {
                    reg_number = value;
                }
            }
        }

        public string Name
        {
            get=>org_name; 
            set=>org_name = value;
        }

        public virtual object DeepCopy()
        {
            return new Team(this.org_name, this.reg_number);
        }

        protected static bool EqualsHelper(Team first, Team second)
        {
            return (first.org_name == second.org_name && first.reg_number == second.reg_number);
        }
        public override bool Equals(object? obj)
        {
            if ((object) this == obj)
            {
                return true;
            }

            var new_team = obj as Team;
            if ((object) new_team == null)
            {
                return false;
            }

            return EqualsHelper(this, new_team);
        }

        public static bool operator ==(Team t1, Team t2)
        {
            if (t1 == t2)
            {
                return true;
            }
            if (t1 == null || t2 == null)
            {
                return false;
            }

            return EqualsHelper(t1, t2);
        }
        
        public static bool operator !=(Team t1, Team t2)
        {
            return !(t1 == t2);
        }

        public override int GetHashCode()
        {
            return (this.org_name.GetHashCode() ^ this.reg_number.GetHashCode());
        }

        public override string ToString()
        {
            return "Organisation name: " + org_name + "\nRegistrarion number: " + reg_number;
        }
    }
}