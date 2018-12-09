using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_Questions
{
    class Node
    {
        // fields
        private Node yes;
        private Node no;
        private string data;


        // properties
        public Node Yes
        {
            get { return yes; }
            set { yes = value; }
        }
        public Node No
        {
            get { return no; }
            set { no = value; }
        }
        
        public String Data
        {
            get { return data; }
            set { data = value; }
        }

        // parameterized constructor
        public Node(string data)
        {
            this.data = data;
        }

        // display
        public void Display()
        {
            Console.WriteLine(data);
        }
    } 
}
