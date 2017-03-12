using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            /*
             * Given a string and a non-negative int n, 
             * return a larger string that is n copies of the original string. 

  StringTimes("Hi", 2) -> "HiHi"
  StringTimes("Hi", 3) -> "HiHiHi"
  StringTimes("Hi", 1) -> "Hi"
             */

            var placeholder = "";
            for (int i = 0; i < n; i++)
            {
                placeholder += str;
            }
            return placeholder;

        }

        public string FrontTimes(string str, int n)
        {
            /*
             * Given a string and a non-negative int n, we'll say that the front of the string is the first 3 chars, 
             * or whatever is there if the string is less than length 3. Return n copies of the front; 

FrontTimes("Chocolate", 2) -> "ChoCho"
FrontTimes("Chocolate", 3) -> "ChoChoCho"
FrontTimes("Abc", 3) -> "AbcAbcAbc"
             */

            string holder = "";
            int x = 3;
            if(x > str.Length)
            {
                x = str.Length;
            }
            else
            {

            }
            string first = str.Substring(0, x);
            for (int i = 0; i < n; i++)
            {
                holder += first;
            }
            return holder;
        }

        public int CountXX(string str)
        {
            /*
             * Count the number of "xx" in the given string. 
             * We'll say that overlapping is allowed, so "xxx" contains 2 "xx". 

CountXX("abcxx") -> 1
CountXX("xxx") -> 2
CountXX("xxxx") -> 3
             */

            int count = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if(str.Substring(i,1) == "x" && str.Substring(i+1, 1) == "x")
                {
                    count += 1;
                }
            }
            return count;
        }

        public bool DoubleX(string str)
        {
            /*
             * Given a string, return true if the first instance of "x" in the string is immediately followed by another "x". 

 DoubleX("axxbb") -> true
 DoubleX("axaxxax") -> false
 DoubleX("xxxxx") -> true
             */
            //for (int i = 0; i <= str.Length; i++)
            //{
            //    if (str.Substring(i, 1) == "x" && str.Substring(i + 1, 1) == "x")
            //    {
            //        return true;
            //    }
            //    if (str.Substring(i, 1) == "x" && str.Substring(i + 1, 1) != "x")
            //    {
            //        return false;
            //    }

            //}return false;

            int count = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if(str[i] == 'x')
                {
                    count++;
                    if(str.Substring(i,2) == "xx" && count < 2)
                    {
                        return true;
                    }
                }               
            }
            return false;
        }

        public string EveryOther(string str)
        {
            /*
             * Given a string, return a new string made of every other char starting with the first, 
             * so "Hello" yields "Hlo". 

 EveryOther("Hello") -> "Hlo"
 EveryOther("Hi") -> "H"
 EveryOther("Heeololeo") -> "Hello"

             */
            string x = "";
            for (int i = 0; i < str.Length; i+=2)
            {
                x += str[i];
            }
            return x;
        }

        public string StringSplosion(string str)
        {
            /*
             * Given a non-empty string like "Code" return a string like "CCoCodCode".  
             * (first char, first two, first 3, etc)

StringSplosion("Code") -> "CCoCodCode"
StringSplosion("abc") -> "aababc"
StringSplosion("ab") -> "aab"
             */
            string x = "";
            for (int i = 0; i < str.Length; i++)
            {
                x += str.Substring(0, i+1 );
            }
            return x;
        }

        public int CountLast2(string str)
        {
            /*Given a string, return the count of the number of times that a substring length 2 
             * appears in the string and also as the last 2 chars of the string, 
             * so "hixxxhi" yields 1 (we won't count the end substring). 

CountLast2("hixxhi") -> 1
CountLast2("xaxxaxaxx") -> 1
CountLast2("axxxaaxx") -> 2
*/

            string x = str.Substring(str.Length - 2);
            int count = 0;

            for (int i = 0; i < str.Length - 2; i++)
            {
                if (str.Substring(i, 2) == x) count++;
            }
            return count;

        }

        public int Count9(int[] numbers)
        {
            /*
             * Given an array of ints, return the number of 9's in the array. 

Count9({1, 2, 9}) -> 1
Count9({1, 9, 9}) -> 2
Count9({1, 9, 9, 3, 9}) -> 3
             */
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] == 9)
                {
                    count++;
                }
            }
            return count;
        }

        public bool ArrayFront9(int[] numbers)
        {
            /*
             * Given an array of ints, return true if one of the first 4 elements in the array is a 9. 
             * The array length may be less than 4. 

ArrayFront9({1, 2, 9, 3, 4}) -> true
ArrayFront9({1, 2, 3, 4, 9}) -> false
ArrayFront9({1, 2, 3, 4, 5}) -> false

             */
            return numbers[0] == 9 || numbers[1] == 9 || numbers[2] == 9 || numbers[3] == 9;
            
        }

        public bool Array123(int[] numbers)
        {
            /*
             * Given an array of ints, return true if .. 1, 2, 3, .. appears in the array somewhere. 

Array123({1, 1, 2, 3, 1}) -> true
Array123({1, 1, 2, 4, 1}) -> false
Array123({1, 1, 2, 1, 2, 3}) -> true
             */

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if(numbers[i] == 1 && numbers[i+1] == 2 && numbers[i+2] == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public int SubStringMatch(string a, string b)
        {
            /*
             * Given 2 strings, a and b, return the number of the positions where they contain the same length 2 substring. 
             * So "xxcaazz" and "xxbaaz" yields 3, since the "xx", "aa", and "az" substrings appear in the same place in both strings. 

SubStringMatch("xxcaazz", "xxbaaz") -> 3
SubStringMatch("abc", "abc") -> 2
SubStringMatch("abc", "axc") -> 0
             */
            int count = 0;
            if (a.Length >= b.Length)
            {
                for (int i = 0; i < b.Length - 1; i++)
                {
                    if (a.Substring(i, 2) == b.Substring(i, 2))
                    {
                        count++;
                    }
                }
            }
            else if (b.Length >= a.Length)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a.Substring(i, 2) == b.Substring(i, 2))
                    {
                        count++;
                    }
                }
            }
            return count;

        }

        public string StringX(string str)
        {
            /*
             * Given a string, return a version where all the "x" have been removed.
             *  Except an "x" at the very start or end should not be removed. 

   StringX("xxHxix") -> "xHix"
   StringX("abxxxcd") -> "abcd"
   StringX("xabxxxcdx") -> "xabcdx"
             */

            string placeholder = "";
            for (int i = 1; i < str.Length - 1; i++)
            {
                if(str.Substring(i,1) != "x")
                {
                    placeholder += str.Substring(i, 1);
                }
            }
            return str.Substring(0, 1) + placeholder +
                str.Substring(str.Length - 1);
        }

        public string AltPairs(string str)
        {
            /*
             * Given a string, return a string made of the chars at indexes 0,1, 4,5, 8,9 ...
             *  so "kittens" yields "kien". 
 AltPairs("kitten") -> "kien"
 AltPairs("Chocolate") -> "Chole"
 AltPairs("CodingHorror") -> "Congrr"
             */
            string str1 = "";
            if(str.Length % 2 == 0)
            {
                for (int i = 0; i < str.Length; i+=4)
                {
                    str1 = str1 + str.Substring(i, 2);
                }
            }
            else
            {
                for (int i = 0; i < str.Length-1; i+=4)
                {
                    str1 = str1 + str.Substring(i, 2);
                }
                str1 = str1 + str.Substring(str.Length - 1, 1);
            }
            return str1;  
        }

        public string DoNotYak(string str)
        {
            /*
             * Suppose the string "yak" is unlucky. Given a string, 
             * return a version where all the "yak" are removed, but the "a" can be any char. 
             * The "yak" strings will not overlap. 
DoNotYak("yakpak") -> "pak"
DoNotYak("pakyak") -> "pak"
DoNotYak("yak123ya") -> "123ya"
             */

            string x = "";
            for (int i = 0; i < str.Length - 2; i++)
            {
                if (str.Substring(i, 3) == "yak")
                {
                    x = str.Remove(i, 3);
                }
            }
            return x;
        }

        public int Array667(int[] numbers)
        {
            /*Given an array of ints, return the number of times that two 6's are next to each other in the array. 
             * Also count instances where the second "6" is actually a 7.         
 Array667({6, 6, 2}) -> 1
 Array667({6, 6, 2, 6}) -> 1
 Array667({6, 7, 2, 6}) -> 1
             */
            int count = 0;
            for (int i = 0; i < numbers.Length-1; i++)
            {
                if((numbers[i]==6) && (numbers[i + 1] == 6))
                {
                    count++;
                }else if ((numbers[i] == 6) && (numbers[i + 1] == 7))
                {
                    count++;
                }
            }
            return count;
        }

        public bool NoTriples(int[] numbers)
        {
            /*Given an array of ints, we'll say that a triple is a value appearing 3 times in a row in the array.
             *  Return true if the array does not contain any triples. 

NoTriples({1, 1, 2, 2, 1}) -> true
NoTriples({1, 1, 2, 2, 2, 1}) -> false
NoTriples({1, 1, 1, 2, 2, 2, 1}) -> false
             */
            for (int i = 0; i < numbers.Length-3; i++)
            {
                if(numbers[i]==numbers[i+1] && (numbers[i] == numbers[i + 2]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool Pattern51(int[] numbers)
        {
            /*Given an array of ints, return true if it contains a 2, 7, 1 pattern -- a value, 
             * followed by the value plus 5, followed by the value minus 1.

Pattern51({1, 2, 7, 1}) -> true
Pattern51({1, 2, 8, 1}) -> false
Pattern51({2, 7, 1}) -> true
             */
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers.Length > 2 && numbers[i + 1] ==
                    numbers[i] + 5 && numbers[i + 2] ==
                    numbers[i] - 1)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
