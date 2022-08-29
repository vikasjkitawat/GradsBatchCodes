using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingDay1
{
    delegate int Del(int num1, int num2);
    internal class DelExample
    {
        static int Add(int num1, int num2)
        {
            return(num1 + num2);
        }
        static int Sub(int num1, int num2)
        {
            return (num1 - num2);
        }
        static int Mul(int num1, int num2)
        {
            return (num1 * num2);
        }
        static int Div(int num1, int num2)
        {
            return (num1 / num2);
        }
        static int Sqr(int num1)
        {
            return (num1 * num1);
        }
        static void Main(string[] args)
        {
            Del del = new Del(Add);
            Console.WriteLine(del(5, 6));
            del=new Del(Mul);
            Console.WriteLine(del(10,5));
        }
    }
}
