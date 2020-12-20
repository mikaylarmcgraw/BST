using System;
using System.ComponentModel.Design.Serialization;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //no input error traping necessary

            //initalizing variables
            bool flag = true;
            BSTNode myNode = new BSTNode();

            BST myBSTFunctions = new BST();

            //intro message
            Console.WriteLine("Hello and welcome to the Binary Search Tree (BST) Simulator!");
            Console.WriteLine("The program is designed to help you build and understand trees.");
            Console.WriteLine();


            while (flag)
            {
                Console.WriteLine("Here are the following menu options: ");
                Console.WriteLine("1 - Add to BST");
                Console.WriteLine("2 - Display BST");
                Console.WriteLine("3 - Search BST");
                Console.WriteLine("4 - Remove node from BST");
                Console.WriteLine("5 - Display root of BST");
                Console.WriteLine("6 - Exit BST Simulator");
                Console.WriteLine();
                Console.WriteLine("Please enter your menu option: ");
               int menuOption = Convert.ToInt32(Console.ReadLine());

                switch (menuOption)
                {

                    case 1:
                        Console.WriteLine("You chose: Add to BST.");
                        Console.WriteLine("What number would you like to enter on your tree: ");                      
                        int numberForAdd = Convert.ToInt32(Console.ReadLine());
                        myNode = myBSTFunctions.root;
                        BSTNode addedNode = myBSTFunctions.addToBST(numberForAdd, myNode);
                        if (addedNode != null)
                        {
                            Console.WriteLine(addedNode.serialNumber + " was successfully added!");
                        }
                        break;

                    case 2:
                        Console.WriteLine("You chose: Display BST.");
                        myNode = myBSTFunctions.root;
                        myBSTFunctions.displayBST(myNode);
                        break;
                   
                    case 3:
                        Console.WriteLine("You chose: Search BST.");
                        Console.WriteLine("Please enter serial number of node you'd like to search for: ");
                        int numberForSearch = Convert.ToInt32(Console.ReadLine());   
                        myNode = myBSTFunctions.root;
                        BSTNode pointerNode = myNode;
                        myBSTFunctions.searchNode(numberForSearch, myNode, pointerNode);
                        break;
                    case 4:
                        Console.WriteLine("You chose: Remove node from BST.");
                        Console.WriteLine("Please enter serial number of node you'd like to remove: ");
                        int numberForRemove = Convert.ToInt32(Console.ReadLine());
                        myNode = myBSTFunctions.root;                   
                        BSTNode removedNode = myBSTFunctions.deleteNode(myNode, numberForRemove);
                        break;
                    case 5:
                        myBSTFunctions.displayRoot();
                        break;
                    case 6:
                        Console.WriteLine("Exiting program....");
                        Console.WriteLine("Thank you for playing with BST Simulator!");
                        flag = false;
                        break;

                    default:
                        Console.WriteLine("Please select menu options 1 - 3 to manipulate/interact BST or 4 to exit.");
                        break;

                }

            }
        }
    }
}
