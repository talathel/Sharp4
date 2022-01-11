using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab_1
{
    public delegate System.Collections.Generic.KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    
    public class TestCollections<TKey, TValue>
    {
        private static int elementsCount = 10;
        private System.Collections.Generic.List<TKey> tKeyList;
        private System.Collections.Generic.List<string> stringList;
        private System.Collections.Generic.Dictionary<TKey, TValue> tKeyDictionary;
        private System.Collections.Generic.Dictionary<string, TValue> stringDictionary;
        private GenerateElement<TKey, TValue> generateElement;

        public TestCollections(int count, GenerateElement<TKey, TValue> generate)
        {
            if (count <= 0) throw new ArgumentException("Count of collection's elements can't be less or equal 0");
            generateElement = generate;
            tKeyList = new List<TKey>();
            stringList = new List<string>();
            tKeyDictionary = new Dictionary<TKey, TValue>();
            stringDictionary = new Dictionary<string, TValue>();
            for (int i = 0; i < count; i++)
            {
                KeyValuePair<TKey, TValue> el = generateElement(i);
                tKeyList.Add(el.Key);
                stringList.Add(el.Key.ToString());
                tKeyDictionary.Add(el.Key, el.Value);
                stringDictionary.Add(el.Key.ToString(), el.Value);
            }
        }

        public KeyValuePair<TKey,TValue> GenerateEl(int i)
        {
            return generateElement(i);
        }

        public void Search_Element_In_TKey_List()
        {
            Stopwatch watch = new Stopwatch();
            
            var first = tKeyList[0];
            var mid = tKeyList[tKeyList.Count / 2];
            var last = tKeyList[tKeyList.Count - 1];
            var nonexistent = GenerateEl(tKeyList.Count+1).Key;
            
            tKeyList.Contains(first);
            watch.Stop();
            Console.WriteLine("For the first element in TKey List: " + watch.Elapsed.Milliseconds);
            
            watch.Restart();
            tKeyList.Contains(mid);
            watch.Stop();
            Console.WriteLine("\nFor the middle element in TKey List: " + watch.Elapsed.Milliseconds);
            
            watch.Restart();
            tKeyList.Contains(last);
            watch.Stop();
            Console.WriteLine("\nFor the last element in TKey List: " + watch.Elapsed.Milliseconds);
            
            watch.Restart();
            tKeyList.Contains(nonexistent);
            watch.Stop();
            Console.WriteLine("\nFor the non-existent element in TKey List: " + watch.Elapsed.Milliseconds + "\n");
        }
        
        public void Search_Element_In_String_List()
        {
            Stopwatch watch = new Stopwatch();
            
            var first = stringList[0];
            var mid = stringList[stringList.Count / 2];
            var last = stringList[stringList.Count - 1];
            var nonexistent = GenerateEl(stringList.Count+1).Key.ToString();
            
            stringList.Contains(first);
            watch.Stop();
            Console.WriteLine("For the first element in String List: " + watch.Elapsed.Milliseconds);
            
            watch.Restart();
            stringList.Contains(mid);
            watch.Stop();
            Console.WriteLine("\nFor the middle element in String List: " + watch.Elapsed.Milliseconds);
            
            watch.Restart();
            stringList.Contains(last);
            watch.Stop();
            Console.WriteLine("\nFor the last element in String List: " + watch.Elapsed.Milliseconds);
            
            watch.Restart();
            stringList.Contains(nonexistent);
            watch.Stop();
            Console.WriteLine("\nFor the non-existent element in String List: " + watch.Elapsed.Milliseconds + "\n");
        }
        
        public void Search_Element_by_Key_In_TKey_Dict()
        {
            Stopwatch watch = new Stopwatch();
            
            var first = Enumerable.ElementAt(tKeyDictionary, 0).Key;
            var mid = Enumerable.ElementAt(tKeyDictionary, tKeyDictionary.Count / 2).Key;
            var last = Enumerable.ElementAt(tKeyDictionary, tKeyDictionary.Count - 1).Key;
            var nonexistent = Enumerable.ElementAt(tKeyDictionary, tKeyDictionary.Count + 1).Key;

            tKeyDictionary.ContainsKey(first);
            watch.Stop();
            Console.WriteLine("For the first key in TKey Dictionary: " + watch.Elapsed.Milliseconds);
            
            watch.Restart();
            tKeyDictionary.ContainsKey(mid);
            watch.Stop();
            Console.WriteLine("\nFor the middle key in TKey Dictionary: " + watch.Elapsed.Milliseconds);
            
            watch.Restart();
            tKeyDictionary.ContainsKey(last);
            watch.Stop();
            Console.WriteLine("\nFor the last key in TKey Dictionary: " + watch.Elapsed.Milliseconds);
            
            watch.Restart();
            tKeyDictionary.ContainsKey(nonexistent);
            watch.Stop();
            Console.WriteLine("\nFor the non-existent key in TKey Dictionary: " + watch.Elapsed.Milliseconds + "\n");
        }
        
        public void Search_Element_by_Key_In_String_Dict()
        {
            Stopwatch watch = new Stopwatch();
            
            var first = Enumerable.ElementAt(stringDictionary, 0).Key;
            var mid = Enumerable.ElementAt(stringDictionary, stringDictionary.Count / 2).Key;
            var last = Enumerable.ElementAt(stringDictionary, stringDictionary.Count - 1).Key;
            var nonexistent = Enumerable.ElementAt(stringDictionary, stringDictionary.Count + 1).Key;

            stringDictionary.ContainsKey(first);
            watch.Stop();
            Console.WriteLine("For the first key in String Dictionary: " + watch.Elapsed.Milliseconds);
            
            watch.Restart();
            stringDictionary.ContainsKey(mid);
            watch.Stop();
            Console.WriteLine("\nFor the middle key in String Dictionary: " + watch.Elapsed.Milliseconds);
            
            watch.Restart();
            stringDictionary.ContainsKey(last);
            watch.Stop();
            Console.WriteLine("\nFor the last key in String Dictionary: " + watch.Elapsed.Milliseconds);
            
            watch.Restart();
            stringDictionary.ContainsKey(nonexistent);
            watch.Stop();
            Console.WriteLine("\nFor the non-existent key in String Dictionary: " + watch.Elapsed.Milliseconds + "\n");
        }
        
        public void Search_Element_by_Value_In_TKey_Dict()
        {
            Stopwatch watch = new Stopwatch();
            
            var first = Enumerable.ElementAt(tKeyDictionary, 0).Value;
            var mid = Enumerable.ElementAt(tKeyDictionary, tKeyDictionary.Count / 2).Value;
            var last = Enumerable.ElementAt(tKeyDictionary, tKeyDictionary.Count - 1).Value;
            var nonexistent = Enumerable.ElementAt(tKeyDictionary, tKeyDictionary.Count + 1).Value;

            tKeyDictionary.ContainsValue(first);
            watch.Stop();
            Console.WriteLine("For the first value in TKey Dictionary: " + watch.Elapsed.Milliseconds);
            
            watch.Restart();
            tKeyDictionary.ContainsValue(mid);
            watch.Stop();
            Console.WriteLine("\nFor the middle value in TKey Dictionary: " + watch.Elapsed.Milliseconds);
            
            watch.Restart();
            tKeyDictionary.ContainsValue(last);
            watch.Stop();
            Console.WriteLine("\nFor the last value in TKey Dictionary: " + watch.Elapsed.Milliseconds);
            
            watch.Restart();
            tKeyDictionary.ContainsValue(nonexistent);
            watch.Stop();
            Console.WriteLine("\nFor the non-existent value in TKey Dictionary: " + watch.Elapsed.Milliseconds + "\n");
        }
    }
}