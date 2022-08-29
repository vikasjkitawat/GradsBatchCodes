using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingDay1
{
    interface IString
    {
        public int vowelCount();
        public int wordCount();
    }
    internal class Example : IString
    {
        public int vowelCount()
        {
            return 10;
        }

        public int wordCount()
        {
            return 20;
        }
        
    }
    class EG
    {
        static void Main1(string[] args)
        {
            Example example = new Example();
            Console.WriteLine(example.wordCount());
        }
    }
}
