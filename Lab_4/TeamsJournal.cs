using System;
using System.Collections.Generic;

namespace Lab_1
{
    public class TeamsJournal
    {
        private List<TeamsJournalEntry> ChangesList = new List<TeamsJournalEntry>();

        public void EventHandler(object obj, EventArgs e)
        {
            var it = e as ResearchTeamsChangedEventArgs<string>;
            ChangesList.Add(new TeamsJournalEntry(it.CollectionName, it.ChangeType, it.PropertyName, it.RegN));
        }

        public override string ToString()
        {
            string list_of_changes = "";
            int k = 1;
            
            if (ChangesList == null)
            {
                return "NO CHANGES";
            }
            
            foreach (var change in ChangesList)
            {
                list_of_changes += "\n-----" + k + " CHANGE-----\n" + change;
                k++;
            }

            return list_of_changes;
        }
    }
}