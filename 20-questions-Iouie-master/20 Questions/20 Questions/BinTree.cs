using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _20_Questions
{
    class BinTree
    {        // fields
        private Node root;
        StreamReader reader;
        StreamWriter writer;
        FileStream fs; // created file stream which can read, write, and create files

        public Node Root
        {
            get { return root; }
            set { root = value; }
        }
        public BinTree()
        {
            root = null;
        }


        // create hardwired method
        public void HardWire()
        {
            root = new Node("living");
            root.Yes = new Node("Bill Gates ");
            root.No = new Node("Chester Carlson ");
        }

        // add method
        public void Add(string newName, string newDiff, Node wrongNode)
        {
            Node yesPerson = new Node(wrongNode.Data);
            Node noPerson = new Node(newName);

            //	Change wrongNode data to newDiff
            wrongNode.Data = newDiff;
            //	Set wrongNode left/yes pointer to noPerson
            wrongNode.Yes = noPerson;
            //	Set wrongNode right/no pointer to yesPerson
            wrongNode.No = yesPerson;
        }


        // traverse method
        public void Traverse()
        {
            if (root != null)
            {
                TraverseR(root);
            }
            else
            {
                Console.WriteLine("Nothing.");
            }
        }
        // recursive method do preorder traversal
        public void TraverseR(Node n)
        {
            if (n.No == null)
            {
                Console.WriteLine("L" + n.Data);
            }
            else
            {
                Console.WriteLine("B" + n.Data);
                TraverseR(n.No);
                TraverseR(n.Yes);
            }
        }
        // create ReadTree method
        public void ReadTree()
        {
            fs = new FileStream("data.txt", FileMode.Open); // opens data file
            using (reader = new StreamReader(fs))
            {
                try
                {
                    root = BuildNodeFromFile();
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Empty file.");
                }
            }
        }

        // create tree from file
        Node BuildNodeFromFile()
        {
            Node newNode = null;
            string linefromFile = reader.ReadLine();
            char nodeType = linefromFile[0]; // prints out B
            linefromFile = linefromFile.Remove(0, 1); // prints out living

            newNode = new Node(linefromFile);  // make new node called "living"

            if (nodeType == 'B')
            {
                newNode.Yes = BuildNodeFromFile();
                newNode.No = BuildNodeFromFile();
            }
            return newNode;
        }

        // save tree to file
        public void SaveTheTree()
        {
            if (root != null)
            {
                // use try catch for streams
                try
                {
                    fs = new FileStream("data.txt", FileMode.Create); // creates data.txt file
                    using (writer = new StreamWriter(fs))
                    {
                        SaveTheTreeR(root);
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("IO Exception: " + e.Message);
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }
            else
            {
                Console.WriteLine("Nothing to remember.");
            }
        }
        // recursive method to save tree
        public void SaveTheTreeR(Node n)
        {
            if (n.No == null)
            {
                writer.WriteLine("L" + n.Data);   // leaf node put L in front
            }
            else
            {
                writer.WriteLine("B" + n.Data); // not a leaf node so add a B and keep going down
                SaveTheTreeR(n.Yes);
                SaveTheTreeR(n.No);

            }
        }
    }
}
