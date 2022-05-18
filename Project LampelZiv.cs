using System;
using System.Linq;

namespace LampelZiv
{
    public static class Extensions
    {
        public static bool find<T>(this List<T> list, T target)
        {
            return list.Contains(target);
        }
    }
    internal class Program
    {
        static List<string> letters = new List<string>();
        static List<string> encoded = new List<string>();
        static void fillarr(string x)
        {
            string y = "";
            int j = 0;
            for (int i = 0; i < x.Length;)
            {
                if (!letters.find(y))
                {
                    letters.Add(y);
                    y = "";
                }
                y += x[i++];
                if (i == x.Length)letters.Add(y);
            }
            encodearr();
        }
        static void encodearr()
        {
            string l,l1="";
            bool f = false;
            for(int i = letters.Count-1;i>=0;i--)
            {
                f = false;
                for(int j = letters[i].Length-1;j>=0;j--)
                {
                    l = letters[i].Substring(0, j);
                    if(letters.find(l))
                    {
                        for(int k = 0; k < letters.Count;k++)
                        {
                            if (letters[k]==l)
                            {
                                l1 = k.ToString() + letters[i].Remove(0, j);
                                encoded.Add(l1);
                                f = true;
                                break;
                            }
                        }
                    }
                    if (f) break;
                }
            }
            showencarr();
        }
        static void showarr()
        {
            foreach (string s in letters) Console.WriteLine(s);
        }
        static void showencarr()
        {
            encoded.Reverse();
            foreach (string s in encoded) Console.Write(s+"  ");
            Console.WriteLine();
            encoded.Clear();
            letters.Clear();
        }
        static void Main(string[] args)
        {
            fillarr("aaababbbaaabaaaaaaabaabb");
            fillarr("aaa");
            fillarr("aaaaaaaaaaaaaaa");
            fillarr("ab");
            fillarr("zzzzzzzzzzzzzzzzzzzzz");
            fillarr("aaabbcbcdddeab");
            fillarr("I AM SAM. SAM I AM");
        }
    }
}
