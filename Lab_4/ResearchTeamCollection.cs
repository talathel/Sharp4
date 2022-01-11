using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Lab_1
{
    public delegate TKey KeySelector<TKey>( ResearchTeam rt);
    
    public class ResearchTeamCollection<TKey>
    {
        private System.Collections.Generic.Dictionary<TKey, ResearchTeam> r_t_collection = new();
        private KeySelector<TKey> keySelector;
        public string CollectionName { get; set; }

        public ResearchTeamCollection(KeySelector<TKey> calculate_key)
        {
            keySelector = calculate_key;
        }

        public DateTime LastPublication
        {
            get
            {
                if (r_t_collection.Count == 0) return new DateTime();
                DateTime[] arr = new DateTime[]{};
                foreach (var team in r_t_collection)
                {
                    foreach (var publication in team.Value.PublicationsList)
                    {
                        arr.Append(publication.publication_date);
                    }
                }

                return Enumerable.Max(arr);
            }
        }

        public TKey CalculateKey(ResearchTeam el)
        {
            return keySelector(el);
        } 

        public void AddDefaults()
        {
            ResearchTeam rt = new ResearchTeam();
            r_t_collection.Add(keySelector(rt), rt);
        }

        public void AddResearchTeams(params ResearchTeam[] r_t_array)
        {
            foreach (var arr_element in r_t_array)
            {
                r_t_collection.Add(keySelector(arr_element), arr_element);
                arr_element.PropertyChanged += HandleEvent;
            }
        }

        public override string ToString()
        {
            string list_of_teams = "";
            int k = 1;
            
            if (r_t_collection == null)
            {
                return "NO RESEARCH TEAMS";
            }
            
            foreach (var team in r_t_collection)
            {
                list_of_teams += "\n-----" + k + " RESEARCH TEAM-----\n" + team.Value;
                k++;
            }

            return list_of_teams;
        }

        public string ToShortString()
        {
            string list_of_teams = "";
            int k = 1;
            
            if (r_t_collection == null)
            {
                return "NO RESEARCH TEAMS";
            }
            
            foreach (var team in r_t_collection)
            {
                list_of_teams += "\n-----" + k + " RESEARCH TEAM-----\n" + team.Value.ToShortString();
                k++;
            }

            return list_of_teams;
        }

        IEnumerable<KeyValuePair<TKey, ResearchTeam>> TimeFrameGroup(TimeFrame value)
        {
            return r_t_collection.Where(team => team.Value.DurationInf == value);
        }

        IEnumerable<IGrouping<TimeFrame, KeyValuePair<TKey, ResearchTeam>>> GroupElements(
            Dictionary<TKey, ResearchTeam> collection)
        {
            return r_t_collection.GroupBy(element => element.Value.DurationInf);
        }

        public bool Remove(ResearchTeam rt)
        {
            var key = r_t_collection.FirstOrDefault(team => team.Value == rt).Key;
            if (key == null) return false;
            TeamPropertyChanged(Revision.Remove, "Not Property", rt.RegN);
            rt.PropertyChanged -= HandleEvent;
            r_t_collection.Remove(key);
            return true;
        }

        public bool Replace(ResearchTeam rtold, ResearchTeam rtnew)
        {
            var key = r_t_collection.FirstOrDefault(team => team.Value == rtold).Key;
            if (key == null) return false;
            TeamPropertyChanged(Revision.Replace, "Not Property", rtold.RegN);
            rtold.PropertyChanged -= HandleEvent;
            rtnew.PropertyChanged += HandleEvent;
            r_t_collection[key] = rtnew;
            return true;
        }

        public event ResearchTeamsChangedHandler<TKey> ResearchTeamsChanged;

        private void HandleEvent(object obj, EventArgs e)
        {
            var it = (PropertyChangedEventArgs) e;
            var team = (ResearchTeam) obj;
            TeamPropertyChanged(Revision.Property, it.PropertyName, team.RegN);
        }

        private void TeamPropertyChanged(Revision chType, string propName, int regN)
        {
            ResearchTeamsChanged?.Invoke(this, new ResearchTeamsChangedEventArgs<TKey>(CollectionName, chType, propName, regN));
        }
        
    }
}