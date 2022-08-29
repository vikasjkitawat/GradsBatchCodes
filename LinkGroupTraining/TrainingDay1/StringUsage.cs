using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingDay1
{
  
    internal class StringUsage
    {
        static void Main1(string[] args)
        {
            Console.Write("Enter a Sentence : ");
            string input=Console.ReadLine();
            Strings strings=new Strings();
            strings.Count(input);
            Console.WriteLine("Word Count : "+strings.wordCount);
            Console.WriteLine("Vowel Count : " + strings.vowelCount);
            Console.WriteLine("Consonant Count : " + strings.consonantCount);
        }

    
    }
}
