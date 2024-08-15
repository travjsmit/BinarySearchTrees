using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Trees
{
    public class BinarySearchTrees
    {
        private Node<int>? Root;
        private int Count = 0;

        public void DeleteNode(int valueToDelete)
        {
            (var valueExists, var node, var priorNode) = DoesValueExist(valueToDelete);
            if (!valueExists) return;

            // We need to run some delete logic
            if (node.Left != null)
            {
                // head down the left hand side - grab the largest value
                var secondlargestNode = node.Left;
                
                if(secondlargestNode.Right == null)
                {
                    // if there are no right hand nodes than we know we reached the largest node
                }
            
            while (secondlargestNode.Right.Right != null)
            {
                    secondlargestNode = secondlargestNode.Right;
            }

            node.Data = secondlargestNode.Right.Data;
            secondlargestNode.Right = null;
            
        }
        
        public (bool valueExists, Node<int>? node) DoesValueExist(int valueToFind)
        {
            Node<int>? currentNode = Root;

            while (currentNode != null)
            {
                if (currentNode.Data == valueToFind)
                    return (true, currentNode);
                else if (valueToFind <= currentNode.Data)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }

            return (false, null);
        }

        public bool DoesValueExist(int valueToFind)
        {
            Node<int>? currentNode = Root;

            while (currentNode != null)
            {
                if (currentNode.Data == valueToFind)
                    return true;
                else if (valueToFind <= currentNode.Data)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }

            return false;
        }

        public void Insert(int data)
        {
            Node<int> newNode = new Node<int>(data);
            if (Root == null)
            {
                Root = newNode;
                Count++;
            }
            else
            {
                InsertHelper(newNode, Root);
            }
        }

        // Helper function
        private void InsertHelper(Node<int> newNode, Node<int> currentNode)
        {
            if (currentNode == null)
            {
                throw new ArgumentNullException(nameof(currentNode), "currentNode cannot be null.");
            }

            // Go left
            if (newNode.Data <= currentNode.Data)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                    Count++;
                }
                else
                {
                    InsertHelper(newNode, currentNode.Left);
                }
            }
            // Go right
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = newNode;
                    Count++;
                }
                else
                {
                    InsertHelper(newNode, currentNode.Right);
                }
            }
        }
    }
}
