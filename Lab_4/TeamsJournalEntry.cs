namespace Lab_1
{
    public class TeamsJournalEntry
    {
        private string CollectionName { get; set; }
        private Revision EventType { get; set; }
        private string PropertyName { get; set; }
        private int RegNumber { get; set; }

        public TeamsJournalEntry(string colName, Revision eventType, string propName, int regN)
        {
            CollectionName = colName;
            EventType = eventType;
            PropertyName = propName;
            RegNumber = regN;
        }

        public override string ToString()
        {
            return "Collection name: " + CollectionName + "\nEvent type: " + EventType + "\nProperty name changed: " +
                   PropertyName + "\nRegistration number: " + RegNumber;
        }
    }
}