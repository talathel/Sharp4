namespace Lab_1
{
    public class ResearchTeamsChangedEventArgs<TKey>:System.EventArgs
    {
        public string CollectionName { get; set; }
        public Revision ChangeType { get; set; }
        public string PropertyName { get; set; }
        public int RegN { get; set; }

        public ResearchTeamsChangedEventArgs(string collName, Revision chType, string propName, int regN)
        {
            CollectionName = collName;
            ChangeType = chType;
            PropertyName = propName;
            RegN = regN;
        }

        public override string ToString()
        {
            return "Collection name: " + CollectionName + "\nChange type: " + ChangeType + "\nProperty name: " +
                   PropertyName + "\nRegistration number: " + RegN;
        }
    }
}