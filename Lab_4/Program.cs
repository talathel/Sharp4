using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            KeySelector<String> selector = team => team.GetHashCode().ToString();
            
            #region Task 1
            
            ResearchTeamCollection<string> firstCollection = new ResearchTeamCollection<string>(selector);   
            ResearchTeamCollection<string> secondCollection = new ResearchTeamCollection<string>(selector);
            firstCollection.CollectionName = "FirstC";
            secondCollection.CollectionName = "SecondC";
            
            #endregion

            #region Task 2

            TeamsJournal tj = new TeamsJournal();
            firstCollection.ResearchTeamsChanged += tj.EventHandler;
            secondCollection.ResearchTeamsChanged += tj.EventHandler;

            #endregion

            #region Task 3

            Random rnd = new Random();
            ResearchTeam rt1 = new ResearchTeam("Topic 1", "Organisation 1", rnd.Next(), TimeFrame.Long);
            ResearchTeam rt2 = new ResearchTeam("Topic 2", "Organisation 2", rnd.Next(), TimeFrame.Long);
            ResearchTeam rt3 = new ResearchTeam("Topic 3", "Organisation 3", rnd.Next(), TimeFrame.Year);
            ResearchTeam rt4 = new ResearchTeam("Topic 4", "Organisation 4", rnd.Next(), TimeFrame.Year);
            
            ResearchTeam rt5 = new ResearchTeam("Topic 5", "Organisation 5", rnd.Next(), TimeFrame.TwoYears);
            
            firstCollection.AddResearchTeams(rt1, rt2);
            secondCollection.AddResearchTeams(rt3, rt4);

            rt1.DurationInf = TimeFrame.TwoYears;
            rt3.Topic = "Topic 33";

            firstCollection.Remove(rt1);
            secondCollection.Remove(rt4);

            rt1.Topic = "Topic 11";
            rt4.Topic = "Topic 44";

            firstCollection.Replace(rt2, rt5);
            secondCollection.Replace(rt3, rt5);

            rt2.DurationInf = TimeFrame.Long;
            rt3.DurationInf = TimeFrame.Long;

            #endregion

            #region Task 4

            Console.WriteLine(tj);

            #endregion
        }
    }
}
