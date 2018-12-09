/* 20 Questions Game
 * Implements classic 20 questions binary decision tree with learning.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_Questions
{
    class Program
    {
        static void Main(string[] args)
        {
            BinTree tqTree = new BinTree();
         // tqTree.HardWire();			    // Used before ReadTree() worked
            tqTree.ReadTree();
          //  tqTree.Traverse();			// Uncomment for debug

            string answer;
            Console.WriteLine("Welcome to 20 questions!  I'll try to guess your person.");

            do
            {
                Console.WriteLine();

                Play20Q.PlayOneRound(tqTree);

                Console.Write("\nHow about another game? y,n ");
                answer = Console.ReadLine().ToLower();

            } while (answer.Equals("y"));

            tqTree.SaveTheTree();
           // tqTree.Traverse();            // Uncomment for debug
            Console.WriteLine("Bye Bye!");
        }
    }
}
