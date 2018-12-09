/* Play20Q class - Plays a single game.
 * Handles situations where tree is null and where tree is a single (leaf) node.
 * These situations are not required for the student projects, but I left them in.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_Questions
{
    class Play20Q
    {
        // Play a complete round of the game, starting at the root of the tree
        // and working down to a leaf node.  If the program correctly guessed
        // the name, it wins.  If it didn't get the name correct, it learns
        // the name the player had in mind and grows the tree to include the
        // new name, the old name, and a new phrase that delineates them.
        public static void PlayOneRound(BinTree tree)
        {
           // tree.HardCode();
            PlayR(tree, tree.Root);
        }

        static void PlayR(BinTree tree, Node n)
        {
            if(n != null)  // checks if root is null
            {
                n = tree.Root;  // if not set current node to root
                while(n.Yes != null && n.No != null) // if n.yes and n.no is not null which is true
                {
                    Console.WriteLine("Is this person " + n.Data + "? ");
                    string userInput = Console.ReadLine().ToLower();
                    if (userInput == "y")
                    {
                        n = n.Yes; // if he is alive current node equal to n.Yes
                    }
                    else
                    {
                        n = n.No; // if not alive current node equal to n.No
                    }
                }
                // computer guesses the answer
                Console.WriteLine("Is it " + n.Data + "? ");
                string ans = Console.ReadLine().ToLower();
                if(ans == "y")
                {
                    Console.WriteLine("I win noob."); // if user guesses right
                }
                else
                {
                    Console.Write("Who is it then? ");
                    string newPerson = Console.ReadLine();
                    Console.WriteLine("What is " + newPerson + " that " + n.Data + " isn't?");
                    string newQuestion = Console.ReadLine();
                    Console.WriteLine("I learn more everyday!");
                    tree.Add(newPerson, newQuestion, n); // adds new person and new question
                }
                    
            }       
        }
    }
}
