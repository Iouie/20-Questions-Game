# 20_Questions

For this project, you will implement a 20 questions game as described in class.  Your program will read a data file to build the 20 questions binary tree, play one or more games, each of which might grow the tree to include more names and phrases, and, after the user decides not to play another game, write the tree to the same data file it initially read from to remember what it has learned.  The next time the game is played with that data file, then, it will still remember all the names it has seen in the past.

This program will give you experience with binary trees, binary search, recursion (both for writing the tree to the data file and for building the tree from the data file), and, last but not least, dealing with pointers (references).  The actual amount of code you’ll write is not huge, but there are some conceptual hurdles you’ll have to clear.

Your application architecture should have a BinTree class to implement the binary tree, a Node class to implement a node in a binary tree, and a Play20Q class to play a single game.  We’ll talk about the design of these classes in class, and I’ll drop some hints.  To enforce this architecture, I’m giving you the Main() method you should use for your final version, which calls stuff in the BinTree and Play20Q classes. You’ll need to implement those classes to fit the interface implied by these calls.  That code is in MainClass.txt.

The format for the data file is important to understand since your program will have to write it and read it correctly.  Each line of the data file will contain the information for a single node in the tree.  The first character of each line will be either ‘I’ or ‘L’ where ‘I’ stands for an Interior node (a node with children) and ‘L’ stands for a Leaf node (a node with no children).  The rest of each line is the string that should be stored in the node, which can include blanks.  You should implement this as a text file so that you can look at its contents easily with your favorite text editor.

You may assume a few things that will make the program easier to write.  First, you don’t have to actually get to 20 questions or even count the number of questions (we don’t want to work with trees that are anywhere near that big).  Second, the data file will be correct, that is, it has been created by a correct WriteTree() method (one of the methods you’ll implement in your BinTree class).  Third, the data file will have at least one interior node and two leaf nodes.  Specifically, the following is a legal data file:

> Bliving  
> LBill Gates  
> LChester Carlson  

Assume that this file is read to build the BinTree object and that the following conversation occurs while running the program:

> Welcome to 20 questions!  I'll try to guess your person.
> 
> Is this person living? y  
> Is it Bill Gates? y  
> Hurray!  I win!  
> 
> How about another game? y
> 
> Is this person living? n  
> Is it Chester Carlson? y  
> Hurray!  I win!
> 
> How about another game? y
> 
> Is this person living? y  
> Is it Bill Gates? n  
> I give up.  Who is it? Bob Dylan  
> What is Bob Dylan that Bill Gates isn't? a Nobel laureate  
> I love to learn new people!
> 
> How about another game? y  
> 
> Is this person living? y  
> Is this person a Nobel laureate? y  
> Is it Bob Dylan? y  
> Hurray!  I win!  
> 
> How about another game? y
> 
> Is this person living? y  
> Is this person a a Nobel laureate? n  
> Is it Bill Gates? y  
> Hurray!  I win!
> 
> How about another game? n  
> Bye Bye!

After this program finishes execution, the data file will contain:

> Bliving  
> Ba Nobel laureate  
> LBob Dylan  
> LBill Gates  
> LChester Carlson  

The next time the program is executed, it will start with the modified data file, so it will remember Bob Dylan.  We’ll explore the relationship between the data file and the binary tree in class by drawing lots of pictures.

As you write this program, I recommend that the last method you write be the method in the BinTree class that reads the data file and (re)creates the tree by doing a preorder traversal of the tree that it’s building as it builds it.  If that sounds confusing, that’s why you should write that method last!  To test your program before that, build a method that hardwires an initial tree with a few nodes, and call that after you create the BinTree object so that you can have a legal tree to work with.  To expand on this, the order in which you should implement stuff is:

1. Set up a hardwired tree
1. Play a single game without learning new names: answer yes to the name question (a leaf node)
1. Play multiple games
1. Learn a new name (answer no to a name question) by adding new nodes to a former leaf node
1. Write the tree to the data file using a preorder traversal
1. Read the data file to set up the tree using a preorder traversal (disconnect your hardwired setup)

Obviously, when you add a new step, make sure the old steps still work.
