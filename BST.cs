using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BinarySearchTree
{
    public class BST
    {
        public BSTNode root = null;
        public int numberEntered = 0;
        BSTNode parentNode = null;

        public BST()
        {

        }

        public BSTNode addToBST(int numberForBST, BSTNode currentNode)
        {

            BSTNode nodeObject = new BSTNode
            {
                serialNumber = numberForBST
            };

            if (root == null)
            {
                root = nodeObject;

            }
            else
            {

                if (nodeObject.serialNumber > currentNode.serialNumber)
                {
                    if (currentNode.right != null)
                    {
                        currentNode = currentNode.right;
                        addToBST(nodeObject.serialNumber, currentNode);
                    }
                    else
                    {
                        currentNode.right = nodeObject;
                    }

                }
                else if (nodeObject.serialNumber < currentNode.serialNumber)
                {
                    if (currentNode.left != null)
                    {
                        currentNode = currentNode.left;
                        addToBST(nodeObject.serialNumber, currentNode);
                    }
                    else
                    {
                        currentNode.left = nodeObject;
                    }
                }
                else
                {
                    Console.WriteLine("Unable to add node to binary search tree, serial number already exists.");
                    return null;
                }

            }

            return nodeObject;
        }

        public void displayBST(BSTNode currentNode)
        {
            if (root == null)
            {
                Console.WriteLine("Unable to display BST, currently empty.");

            }
            else
            {
                if (currentNode != null)
                {
                    displayBST(currentNode.left);
                    Console.WriteLine(currentNode.serialNumber);
                    displayBST(currentNode.right);
                }
            }
        }

        public void searchNode(int serialToSearch, BSTNode currentNode, BSTNode pointer)
        {
            if (root == null)
            {
                Console.WriteLine("Binary search tree is empty, search function is disabled.");
            }
            else
            {
                if (root.serialNumber == serialToSearch) // root is node we're searching for
                {
                    Console.WriteLine("Serial number you searched for was found at the root.");
                    if (currentNode.right != null)
                    {
                        Console.WriteLine(serialToSearch + "'s right is : " + currentNode.right.serialNumber);
                    }
                    if (currentNode.left != null)
                    {
                        Console.WriteLine(serialToSearch + "'s left is : " + currentNode.left.serialNumber);
                    }
                }
                else if (serialToSearch < currentNode.serialNumber) // traverse to find the node
                {
                    if (currentNode.left != null)
                    {
                        pointer = currentNode;
                        searchNode(serialToSearch, currentNode.left, pointer);
                    }
                    else
                    {
                        Console.WriteLine("Serial number searched for not found.");
                    }

                }
                else if (serialToSearch > currentNode.serialNumber)
                {
                    if (currentNode.right != null)
                    {
                        pointer = currentNode;
                        searchNode(serialToSearch, currentNode.right, pointer);
                    }
                    else
                    {
                        Console.WriteLine("Serial number searched for not found.");
                    }

                }
                else // node found
                {
                    Console.WriteLine("Serial number: " + serialToSearch + " was found.");
                    Console.WriteLine("Node: " + pointer.serialNumber + " points to Node: " + serialToSearch + ".");
                    if (currentNode.right != null)
                    {
                        Console.WriteLine(serialToSearch + "'s right is : " + currentNode.right.serialNumber);
                    }
                    if (currentNode.left != null)
                    {
                        Console.WriteLine(serialToSearch + "'s left is : " + currentNode.left.serialNumber);
                    }
                }
            }
        }
        public void displayRoot()
        {
            if (root == null)
            {
                Console.WriteLine("Unable to display root BST is empty");
            }
            else
            {
                Console.WriteLine("The root of BST is: " + root.serialNumber + ".");
            }
        }


        public BSTNode deleteNode(BSTNode currentNode, int key)
        {
            if (currentNode == null)//key is not found in bst
            {
                Console.WriteLine("Node not found in the BST");
                return null;
            }
            else if (key < currentNode.serialNumber)// if given key is less than the current node, go to left subtree
            {
                parentNode = currentNode; // update parent node as current node
                currentNode = currentNode.left;
                deleteNode(currentNode, key);
            }
            else if (key > currentNode.serialNumber)// else go to right subtree
            {
                parentNode = currentNode;  // update parent node as current node
                currentNode = currentNode.right;
                deleteNode(currentNode, key);
            }
            else if (key == root.serialNumber)//key found in BST currentNode.serialNumber == key
            {
               

                if (root.left == null && root.right == null)//key to remove has no children and is the root
                {
                    root = null;
                    
                }
                else //removed node has 1 or 2 children
                {

                    if (currentNode.left != null) // root has a left
                    {
                        currentNode = currentNode.left;//going left once 
                        parentNode = currentNode;
                        while (currentNode.right != null)//finding the rightmost left
                        {
                            parentNode = currentNode;
                            currentNode = currentNode.right;
                            
                        }

                        if (currentNode.left != null)//if rightmost left has a left needs to be assigned to parent's right
                        {
                            parentNode.right = currentNode.left;
                        }
                        else
                        {
                            parentNode.right = null;
                        }
                        if(root.left != currentNode)
                        {
                            currentNode.left = root.left;//assigning currentNode's left and right to root's. only if left isn't self
                        }                       
                        currentNode.right = root.right;
                        root = currentNode;//reassigning root.

                    }
                    else //root only has a right no left to go first
                    {
                        parentNode = currentNode; //shift right first
                        currentNode = currentNode.right;
                        while (currentNode.left != null) //find leftmost right
                        {
                            parentNode = currentNode;
                            currentNode = currentNode.left;
                        }

                        if (currentNode.right != null) //reassigning current node's child if it has one
                        {
                            parentNode.left = currentNode.right;
                        }
                        else // if not reassigning parent's pointer to null so it doesn't point to the new root
                        {
                            parentNode.left = null;
                        }

                        if (root.right!= currentNode) //assigning right to new root as long as it's not itself
                        {
                            currentNode.right = root.right;

                        }
                        currentNode.left = root.left; //assigning new root's left
                        root = currentNode;//reassigning the root to the new value
                    }                   
                }
                Console.WriteLine("Node serial number: " + key + " has been removed.");
            }
            else// removing node in the middle of the tree 
            {
                if (currentNode.right == null && currentNode.left == null) //currentNode to replace has no child
                {
                    if (parentNode.right == currentNode)//reassigning parentNodes right or left to null after replacing currentNode
                    {
                        parentNode.right = null;
                    }
                    else
                    {
                        parentNode.left = null;
                    }
                }
                else //node to remove has one or more children
                {
                    if (currentNode.left != null) //if node to remove has left child
                    {
                       BSTNode replacingNode = currentNode.left;
                        BSTNode replacingNodeParent = null;
                        while (replacingNode.right != null)
                        {
                          replacingNodeParent = replacingNode;
                          replacingNode = replacingNode.right;
                        }
                        if (parentNode.left == currentNode) //reassigning parentNode to Node to replace currentNode
                        {
                            parentNode.left = replacingNode;
                        }
                        else
                        {
                            parentNode.right = replacingNode;
                        }
                                
                        if (currentNode.right != null) //checking if currentNode has right children
                        {
                            replacingNode.right = currentNode.right; //reassigning if they do
                        }

                        if (replacingNodeParent != null)
                        {
                            if (replacingNode.left != null)
                            {
                                replacingNodeParent.right = replacingNode.left;
                            }
                            else
                            {
                                replacingNodeParent.right = null;
                            }

                        }

                        if (currentNode.left != replacingNode)
                        {
                            replacingNode.left = currentNode.left;
                        }
                         
                        
                    }
                    else // no left so reassign to currentNode's first right
                    {
                        if (parentNode.left == currentNode)
                        {
                          parentNode.left = currentNode.right;
                        }
                        else
                        {
                          parentNode.right = currentNode.right;
                        }
                                
                       currentNode.left = null;
                       currentNode.right = null;
                    } 
             
                }

                Console.WriteLine("Node serial number: " + key + " has been removed.");
            }
            return currentNode;           
        }
    }
}
