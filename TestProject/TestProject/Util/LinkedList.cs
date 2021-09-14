using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Util
{
    public class LinkedListNode<T>
    {
        public T Data { get; set; }

        private LinkedListNode<T> Next;

        public LinkedListNode<T> Add(T value) 
        { 
            this.Next = new LinkedListNode<T>
            {
                Data = value,
                Next = null
            };
            
            return this.Next;
        }

        public void Add(LinkedListNode<T> node) 
        { 
            this.Next = node;
        }

        public LinkedListNode<T> GetNext() => this.Next;
    }

    public static class LinkedListHelper
    {
        /// <summary>
        /// Initialize a new list and returns its initial node
        /// </summary>
        /// <param name="values"></param>
        /// <param name="loopNode">If valid value, last node will point for the node in this index </param>
        /// <returns></returns>
        public static LinkedListNode<T> InitializeList<T>(T[] values, int loopIndex = -1)
        {
            if(values.Length == 0) throw new ArgumentException();
            
            var initialNode = new LinkedListNode<T>();
            initialNode.Data = values[0];

            var listBuilder = initialNode;

            // Build list
            for (int i = 1; i < values.Length; i++)
            {
                listBuilder = listBuilder.Add(values[i]);
            }

            // Insert a loop on last node
            if(loopIndex >= 0 && loopIndex < values.Length)
            {
                var loopNode = initialNode;

                for(int i = 0; i < loopIndex; i++)
                {
                    loopNode = loopNode.GetNext();
                }

                listBuilder.Add(loopNode);
            }

            return initialNode;
        }
    }

}
