using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab_1
{
    public class ResearchTeamEnumerator: System.Collections.IEnumerator
            {
                private int position;
                private System.Collections.Generic.List<Person> participant_list;
                private System.Collections.Generic.List<Paper> publication_list;
                
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
    
                public ResearchTeamEnumerator(List<Person> participants, List<Paper> publications)
                {
                    position = -1;
                    this.participant_list = participants;
                    this.publication_list = publications;
                }
                
                public bool MoveNext()
                {
                    while (position < participant_list.Count)
                    {
                        position++;
                        if (position >= participant_list.Count)
                        {
                            return false;
                        }
                        Person participant = participant_list[position] as Person;
                        if (Convert.ToBoolean(HasPublication(participant)))
                        {
                            return true;
                        }
                        
                    }
                    return false;
                }
    
                public void Reset()
                {
                    position = -1;
                }
    
                public object? Current 
                {
                    get
                    {
                        if (position == -1 || position >= participant_list.Count)
                        {
                            throw new InvalidOperationException();
                        }
                        return participant_list[position];
                    }
                }
            }
}