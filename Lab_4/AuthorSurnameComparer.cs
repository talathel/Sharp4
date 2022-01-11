using System;

namespace Lab_1
{
    public class AuthorSurnameComparer:System.Collections.Generic.IComparer<Paper>
    {
        public int Compare(Paper x, Paper y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) throw new ArgumentException("Null argument");
            if (ReferenceEquals(null, x)) throw new ArgumentException("Null argument");
            var titleComparison = string.Compare(x.author.Surname, y.author.Surname, StringComparison.Ordinal);
            return titleComparison;
        }
    }
}