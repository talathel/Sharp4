using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Lab_1
{
    public class ResearchTeam: Team, IEnumerable, System.ComponentModel.INotifyPropertyChanged
    {
        private string topic;
        private TimeFrame duration_info;
        private System.Collections.Generic.List<Person> participant_list;
        private System.Collections.Generic.List<Paper> publication_list;
        public event PropertyChangedEventHandler PropertyChanged;


        public ResearchTeam(string c_topic, string c_org_n, int c_reg_n, TimeFrame c_duration_i)
        {
            topic = c_topic;
            org_name = c_org_n;
            reg_number = c_reg_n;
            duration_info = c_duration_i;
            publication_list = new List<Paper>();
            participant_list = new List<Person>();
        }
        public ResearchTeam()
        {
            topic = "Default topic";
            org_name = "Default organisation";
            reg_number = 1;
            duration_info = TimeFrame.Long;
            publication_list = new List<Paper>();
            participant_list = new List<Person>();
        }
        public System.Collections.Generic.List<Paper> PublicationsList
        {
            get => publication_list;
            set
            {
                publication_list = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Publication list"));
            }
        }
        
        public System.Collections.Generic.List<Person> ParticipationsList
        {
            get => participant_list;
            set
            {
                participant_list = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Participants list"));
            }
        }
        public string Topic
        {
            get => topic;
            set
            {
                topic = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Topic"));
            } 
        }
        public int RegN
        {
            get => reg_number;
            set
            {
                reg_number = value;
            }
        }
        public TimeFrame DurationInf
        {
            get => duration_info;
            set
            {
                duration_info = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Duration information"));
            }
        }
        
        private string Name
        {
            get => org_name;
            set
            {
                org_name = value;
            }
        }
        
        
        public Paper FindRecent(System.Collections.Generic.List<Paper> p_list)
        {
            if (p_list.Count > 0)
            {
                Paper recent_p = p_list[0] as Paper;
                int max = 0;
                
                for (int i = 1; i < p_list.Count; i++)
                {
                    Paper current = p_list[i] as Paper;
                    if (current.publication_date > recent_p.publication_date)
                    {
                         recent_p = current;
                    }
                }

                ref Paper reference = ref recent_p;
                
                return reference;
            }
            else
            {
                return null;
            }
        }

        public Paper RecentPublication
        {
            get
            {
                Paper reference =  FindRecent(publication_list);
                return reference;
            }
        }

        public bool this[TimeFrame frame]
        {
            get => duration_info == frame;
        }

        public void AddPapers(params Paper[] papers)
        {
            for (int i = 0; i < papers.Length; i++)
            {
                publication_list.Add(papers[i]);
            }
        }
        
        public void AddParticipants(params Person[] pers)
        {
            for (int i = 0; i < pers.Length; i++)
            {
                participant_list.Add(pers[i]);
            }
        }

        public override string ToString()
        {
            string d_i;
            switch (duration_info)
            {
                case TimeFrame.Year: d_i = "Year";
                    break;
                case TimeFrame.TwoYears: d_i = "Two years";
                    break;
                default: d_i = "Long";
                    break;
            }

            if (publication_list[0] != null)
            {
                string list_of_pub = "\n--1 PUBLICATION--\n" + publication_list[0];
                for (int i = 1; i < publication_list.Count; i++)
                {
                    if (publication_list[i] != null)
                    {
                        int k = i + 1;
                        list_of_pub += "\n--" + k + " PUBLICATION--\n" + publication_list[i];
                    }
                    else
                    {
                        list_of_pub += "\n--EMPTY PUBLICATION--\n";
                    }
                }

                return "Topic: " + topic + "\nOrganisation name: " + org_name + "\nRegistration number: " +
                       reg_number + "\nDuration info: " + d_i + "\nList of publications: " + list_of_pub;
            }
            else
            {
                return "Topic: " + topic + "\nOrganisation name: " + org_name + "\nRegistration number: " +
                       reg_number + "\nDuration info: " + d_i + "\nNO PUBLICATIONS";
            }
        }
        public string ToShortString()
        {
            string d_i;
            switch (duration_info)
            {
                case TimeFrame.Year: d_i = "Year";
                    break;
                case TimeFrame.TwoYears: d_i = "Two years";
                    break;
                default: d_i = "Long";
                    break;
            }
            
            return "Topic: " + topic + "\nOrganisation name: " + org_name + "\nRegistration number: " +
                   reg_number + "\nDuration info: " + d_i;
        }
        
        public virtual object DeepCopy()
        {
            ResearchTeam new_team = new ResearchTeam(this.Topic, this.OrgName, this.RegN, this.DurationInf);
            new_team.participant_list.InsertRange(0, this.participant_list);
            new_team.publication_list.InsertRange(0, publication_list);
            return new_team;
        }

        public Team TeamObject
        {
            get
            {
                Team new_team = new Team(this.org_name, this.reg_number);
                return new_team;
            }
            set
            {
                org_name = value.OrgName;
                reg_number = value.RegNumber;
            }
        }

        public int HasPublication(Person pers)
        {
            int count = 0;
            for (int i = 0; i < publication_list.Count; i++)
            {
                Paper publication = publication_list[i] as Paper;
                if (pers == publication.author)
                {
                    count++;
                }
            }
            return count;
        }

        public IEnumerable GetAuthorsWithNoPublications()
        {
            for (int i = 0; i < participant_list.Count; i++)
            {
                Person pers = participant_list[i] as Person;
                if (!Convert.ToBoolean(HasPublication(pers)))
                {
                    yield return pers;
                }
            }
        }

        public IEnumerable LastNYearsPublications(int n)
        {
            for (int i = 0; i < publication_list.Count; i++)
            {
                Paper publication = publication_list[i] as Paper;
                if (DateTime.Now.Year - publication.publication_date.Year <= n)
                {
                    yield return publication;
                }
            }
        }
        
        public IEnumerator GetEnumerator()
        {
            return new ResearchTeamEnumerator(participant_list, publication_list);
        }
        
        public IEnumerable GetAuthorsWithMoreThanNPublications(int n)
        {
            for (int i = 0; i < participant_list.Count; i++)
            {
                Person pers = participant_list[i] as Person;
                if (HasPublication(pers) > n)
                {
                    yield return pers;
                }
            }
        }

        public IEnumerable GetPublicationsForLastYear()
        {
            return this.LastNYearsPublications(1);
        }

        static void Swap(ref Paper el1, ref Paper el2)
        {
            var temp = el2;
            el2 = el1;
            el1 = el2;

        }

        void SortByPublicationDate(List<Paper> list)
        {
            list.Sort();
        }
        
        void SortByPublicationTitle(List<Paper> list)
        {
            list.Sort(new Paper());
        }
        
        void SortByPublicationAuthorSurname(List<Paper> list)
        {
            list.Sort(new AuthorSurnameComparer());
        }

        public static bool operator==(ResearchTeam rt1, ResearchTeam rt2)
        {
            return rt1.Name == rt2.Name && rt1.Topic == rt2.Topic && rt1.DurationInf == rt2.DurationInf;
        }

        public static bool operator !=(ResearchTeam rt1, ResearchTeam rt2)
        {
            return !(rt1 == rt2);
        }
    }
}