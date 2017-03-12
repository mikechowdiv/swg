using System; 

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            /*We have two children, a and b, and the parameters aSmile and bSmile indicate if each is smiling. 
             * We are in trouble if they are both smiling or if neither of them is smiling. Return true if we are in trouble. 

AreWeInTrouble(true, true) -> true
AreWeInTrouble(false, false) -> true
AreWeInTrouble(true, false) -> false
             */
            bool result = false;
            if (aSmile == bSmile)
            {
                result = true;
            }
            return result;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            /*The parameter weekday is true if it is a weekday, and the parameter vacation is true if we are on vacation. 
             * We sleep in if it is not a weekday or we're on vacation. Return true if we sleep in. 

sleepIn(false, false) -> true
sleepIn(true, false) -> false
sleepIn(false, true) -> true
             */
            if (!isWeekday || isVacation)
            {
                return true;
            }
            return false;
        }

        public int SumDouble(int a, int b)
        {
            /*Given two int values, return their sum. However, if the two values are the same, then return double their sum. 
SumDouble(1, 2) -> 3
SumDouble(3, 2) -> 5
SumDouble(2, 2) -> 8
             */
            int sum = a + b;
            if (a == b)
            {
                sum *= 2;
            }
            return sum;
        }
        
        public int Diff21(int n)
        {
            /*Given an int n, return the absolute value of the difference between n and 21, 
             * except return double the absolute value of the difference if n is over 21. 

Diff21(23) -> 4
Diff21(10) -> 11
Diff21(21) -> 0
             */
            int diff = Math.Abs( 21 - n);
            if(n > 21)
            {
                diff = diff * 2;
            }
            return diff;

        }
        
        public bool ParrotTrouble(bool isTalking, int hour)
        {
            /*We have a loud talking parrot. The "hour" parameter is the current hour time in the range 0..23.
             *  We are in trouble if the parrot is talking and the hour is before 7 or after 20.
             *   Return true if we are in trouble. 

ParrotTrouble(true, 6) -> true
ParrotTrouble(true, 7) -> false
ParrotTrouble(false, 6) -> false
             */
            if (isTalking && (hour  < 7 || hour > 21))
            {
                return true;
            }else
            {
                return false;
            }
        }
        
        public bool Makes10(int a, int b)
        {
            /*Given two ints, a and b, return true if one if them is 10 or if their sum is 10. 

Makes10(9, 10) -> true
Makes10(9, 9) -> false
Makes10(1, 9) -> true
             */
            if (a == 10 || b == 10)
            {
                return true;
            }
            else if(a + b == 10)
            {
                return true;
            }else
            {
                return false;
            }
        }
        
        public bool NearHundred(int n)
        {
            /*Given an int n, return true if it is within 10 of 100 or 200.
Hint: Check out the C# Math class for absolute value

NearHundred(103) -> true
NearHundred(90) -> true
NearHundred(89) -> false
             */
            if (n >= 90 && n <= 110)
            {
                return true;
            }else if(n >= 190 && n <= 210)
            {
                return true;
            }else
            {
                return false;
            }
        }
        
        public bool PosNeg(int a, int b, bool negative)
        {
            //Given two int values, return true if one is negative and one is positive. 
            //Except if the parameter "negative" is true, then return true only if both are negative. 

            if(negative == true && a < 0 && b < 0)
            {
                return true;
            }
            else if(negative == false && a < 0 && b > 0)
            {
                return true;
            }
            else if(negative == false && a > 0 && b < 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public string NotString(string s)
        {
            //Given a string, return a new string where "not " has been added to the front. 
            // However, if the string already begins with "not", return the string unchanged.

            /*
             Hint: Look up how to use "SubString" in c#

            NotString("candy") -> "not candy"
            NotString("x") -> "not x"
            NotString("not bad") -> "not bad"
             */

            if (s.StartsWith("not"))
            {
                return s;
            }else
            {
                return "not " + s;
            }
        }

        public string MissingChar(string str, int n)
        {
            /*
             Given a non-empty string and an int n, return a new string where the char at index n has been removed. 
            The value of n will be a valid index of a char in the original string (Don't check for bad index). 

 MissingChar("kitten", 1) -> "ktten"
 MissingChar("kitten", 0) -> "itten"
 MissingChar("kitten", 4) -> "kittn"
             */

            return str.Substring(0, n) + str.Substring(n + 1);

        }

        public string FrontBack(string str)
        {
            /*
             Given a string, return a new string where the first and last chars have been exchanged. 

FrontBack("code") -> "eodc"
FrontBack("a") -> "a"
FrontBack("ab") -> "ba"
             */

            if(str.Length < 2)
            {
                return str;
            }else
            {
                string first = str.Substring(0, 1);
                string last = str.Substring(str.Length - 1);
                string mid = str.Substring(1, str.Length - 2);
                return last + mid + first;
            }
        }

        public string Front3(string str)
        {
            /*
             Given a string, we'll say that the front is the first 3 chars of the string. 
             If the string length is less than 3, the front is whatever is there. Return a new string which is 3 copies of the front. 

Front3("Microsoft") -> "MicMicMic"
Front3("Chocolate") -> "ChoChoCho"
Front3("at") -> "atatat"
             */
            string x;
            if(str.Length <= 3)
            {
                x = str;
            }
           else
            {
                x = str.Substring(0, 3);
            }
            return x + x + x;
        }

        public string BackAround(string str)
        {
            /*
             Given a string, take the last char and return a new string with the last char added at the front and back,
             so "cat" yields "tcatt". The original string will be length 1 or more. 

BackAround("cat") -> "tcatt"
BackAround("Hello") -> "oHelloo"
BackAround("a") -> "aaa"
             */
            string last = str.Substring(str.Length - 1);
            if(str.Length == 1)
            {
                return str + str + str;
            }else
            {
                return last + str + last;
            }

        }

        public bool Multiple3or5(int number)
        {
            /*
             Return true if the given non-negative number is a multiple of 3 or a multiple of 5. Use the % "mod" operator

Multiple3or5(3) -> true
Multiple3or5(10) -> true
Multiple3or5(8) -> false
             */

            if(number % 3 == 0 || number % 5 == 0)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public bool StartHi(string str)
        {
            /*
             Given a string, return true if the string starts with "hi" and false otherwise. 

 StartHi("hi there") -> true
 StartHi("hi") -> true
 StartHi("high up") -> false
             */
            //if (str.Contains("hi"))
            //{
            //    return true;
            //}else
            //{
            //    return false;
            //}

            if(str.Length < 2)
            {
                return false;
            }
            if(str.Length == 2 && str == "hi")
            {
                return true;
            }
            else if (char.IsLetter(str[2]))
            {
                return false;
            }
            else
            {
                return true;
                     
            }
        }

        public bool IcyHot(int temp1, int temp2)
        {
            /*
             Given two temperatures, return true if one is less than 0 and the other is greater than 100. 

IcyHot(120, -1) -> true
IcyHot(-1, 120) -> true
IcyHot(2, 120) -> false
             */
             if(temp1 >=100 && temp2 <= 0)
            {
                return true;
            }else if(temp1 <= 0 && temp2 >= 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Between10and20(int a, int b)
        {
            /*
             Given 2 int values, return true if either of them is in the range 10..20 inclusive. 

Between10and20(12, 99) -> true
Between10and20(21, 12) -> true
Between10and20(8, 99) -> false

             */

            if((a >= 10 && a <= 20) || (b >= 10 && b <= 20))
            {
                return true;
            }
            return false;
        }

        public bool HasTeen(int a, int b, int c)
        {
            /*
             We'll say that a number is "teen" if it is in the range 13..19 inclusive. 
             Given 3 int values, return true if 1 or more of them are teen. 

HasTeen(13, 20, 10) -> true
HasTeen(20, 19, 10) -> true
HasTeen(20, 10, 12) -> false 
             */
             if((a >= 13 && a <= 19) || (b >= 13 && b <= 19) || (c >= 13 && c <= 19))
            {
                return true;
            }
            return false;
        }

        public bool SoAlone(int a, int b)
        {
            /*
             We'll say that a number is "teen" if it is in the range 13..19 inclusive. 
             Given 2 int values, return true if one or the other is teen, but not both. 

SoAlone(13, 99) -> true
SoAlone(21, 19) -> true
SoAlone(13, 13) -> false
             */
            if ((a >= 13 && a <= 19) && (b >= 13 && b <= 19))
            {
                return false;
            }else if((a >= 13 && a <= 19) || (b >= 13 && b <= 19))
            {
                return true;
            }else
            {
                return false;
            }
            
        }

        public string RemoveDel(string str)
        {
            /*
             Given a string, if the string "del" appears starting at index 1, 
             return a string where that "del" has been deleted. Otherwise, return the string unchanged. 

RemoveDel("adelbc") -> "abc"
RemoveDel("adelHello") -> "aHello"
RemoveDel("adedbc") -> "adedbc"
             */
             if(str.Substring(1,3) == "del")
            {
                return (str.Substring(0, 1) + str.Substring(4));
            }
            else
            {
                return (str);
            }

        }

        public bool IxStart(string str)
        {
            /*
             Return true if the given string begins with "*ix", the '*' can be anything, so "pix", "9ix" .. all count. 

IxStart("mix snacks") -> true
IxStart("pix snacks") -> true
IxStart("piz snacks") -> false

             */
            if (str.Contains("ix"))
            {
                return true;
            }
            return false;
        }

        public string StartOz(string str)
        {
            /*
             Given a string, return a string made of the first 2 chars (if present), 
             however include first char only if it is 'o' and include the second 
             only if it is 'z', so "ozymandias" yields "oz". 

StartOz("ozymandias") -> "oz"
StartOz("bzoo") -> "z"
StartOz("oxx") -> "o"
             */

            if(str.Length > 2)
            {
                if (str.StartsWith("o"))
                {
                    if (str.Substring(1, 1) == "z")
                    {
                        return (str.Substring(0, 2));
                    }
                    else
                    {
                        return (str.Substring(0, 1));
                    }
                }
                else
                {
                    if(str.Substring(1,1) == "z")
                    {
                        return (str.Substring(1, 1));
                    }
                    else
                    {
                        return ("");
                    }
                }
            }
            else
            {
                return ("");
            }
        }
        

        public int Max(int a, int b, int c)
        {
            /*
             * Given three int values, a b c, return the largest. 

 Max(1, 2, 3) -> 3
 Max(1, 3, 2) -> 3
 Max(3, 2, 1) -> 3
             */
            int x = Math.Max(Math.Max(a, b), c);
            {
                return x;
            }
        }

        public int Closer(int a, int b)
        {
            /*
             * Given 2 int values, return whichever value is nearest to the value 10, or return 0 in the event of a tie. 

 Closer(8, 13) -> 8
 Closer(13, 8) -> 8
 Closer(13, 7) -> 0
             */
            int value1 = Math.Abs(10 - a);
            int value2 = Math.Abs(10 - b);
            if(value1 < value2)
            {
                return a;
            }else if(value2 < value1)
            {
                return b;
            }
            return 0;
        }

        public bool GotE(string str)
        {
            /*
             * Return true if the given string contains between 1 and 3 'e' chars. 

GotE("Hello") -> true
GotE("Heelle") -> true
GotE("Heelele") -> false
             */
            int count = 0;
            for (int i = 0; i <= str.Length-1; i++)
            {
                if (str.Substring(i, 1) == "e")
                {
                    count++;
                }
            }
            if(count >= 1 && count < 4)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public string EndUp(string str)
        {
            /*
             * Given a string, return a new string where the last 3 chars are now in upper case.
             *  If the string has less than 3 chars, uppercase whatever is there. 

EndUp("Hello") -> "HeLLO"
EndUp("hi there") -> "hi thERE"
EndUp("hi") -> "HI"
             */

            if(str.Length < 3)
            {
                return str.ToUpper();
            }else
            {
                string restOfString = (str.Substring(str.Length - 3));
                return (str.Substring(0, str.Length - 3) + restOfString.ToUpper());
            }
        }

        public string EveryNth(string str, int n)
        {
            /*
             * Given a non-empty string and an int N, return the string made starting with char 0, 
             * and then every Nth char of the string. So if N is 3, use char 0, 3, 6, ... and so on. N is 1 or more. 

EveryNth("Miracle", 2) -> "Mrce"
EveryNth("abcdefg", 2) -> "aceg"
EveryNth("abcdefg", 3) -> "adg"
             */
            string newStr = "";
            for (int i = 0; i < str.Length; i = i + n)
            {
                newStr = newStr + str.Substring(i, 1);
            }
            return newStr;
        }
    }
}
