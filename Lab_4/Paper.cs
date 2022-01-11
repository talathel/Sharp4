using System;
using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace Lab_1
{
    public class Paper: IComparable, System.Collections.Generic.IComparer<Paper>
    {
        public string title;
        public Person author;
        public DateTime publication_date;

        public Paper(string c_title, Person c_author, DateTime с_pd)
        {
            title = c_title;
            author = c_author;
            publication_date = с_pd;
        }

        public Paper()
        {
            title = "Default publication";
            author = new Person("Ivanov", "Ivanov", new DateTime(1000, 01, 01));
            publication_date = new DateTime(1000, 01, 01);
        }

        public override string ToString()
        {
            return "Title: " + title + "\nAuthor: \n" + author + "\nPublication date: " + publication_date;
        }

        public int CompareTo(object? obj)
        {
            Paper compare_paper = obj as Paper;
            if (compare_paper != null)
            {
                if (this.publication_date < compare_paper.publication_date)
                {
                    return -1;
                }

                if (this.publication_date == compare_paper.publication_date)
                {
                    return 0;
                }

                return 1;
            }
            else
            {
                throw new InvalidCastException("Can't convert comparable oject to type Paper");
            }
            
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Paper new_paper = (Paper) obj;
            return (title.Equals(new_paper.title) && author.Equals(new_paper.author) &&
                    publication_date.Equals(new_paper.publication_date));
        }

        public static bool operator ==(Paper p1, Paper p2)
        {
            if (p1 == null || p2 == null)
            {
                return false;
            }

            return (p1.title.Equals(p2.title) && p1.author.Equals(p2.author) &&
                    p1.publication_date.Equals(p2.publication_date));
        }

        public static bool operator !=(Paper p1, Paper p2)
        {
            return !(p1 == p2);
        }

        public object DeepCopy()
        {
            DateTime new_date = new DateTime(this.publication_date.Year, this.publication_date.Month,
                this.publication_date.Day);
            return new Paper(this.title, this.author, new_date);
        }

        public int Compare(Paper x, Paper y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) throw new ArgumentException("Null argument");
            if (ReferenceEquals(null, x)) throw new ArgumentException("Null argument");
            var titleComparison = string.Compare(x.title, y.title, StringComparison.Ordinal);
            return titleComparison;
        }
        
    }
}