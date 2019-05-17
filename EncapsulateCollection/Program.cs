using System;
using System.Collections.Generic;

namespace EncapsulateCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
           
        }
    }
    public class Order
    {
        private List<OrderLine> _orderLines;
        private int _orderTotal;

        public IEnumerable<OrderLine> OrderLines{get { return _orderLines; }}
        
        public void AddOrderLine(OrderLine orderLine)
        {
            _orderTotal += orderLine.Total;
            _orderLines.Add(orderLine);
        }
        
        public void RemoveOrderLine(OrderLine orderLine)
        {
            orderLine = _orderLines.Find(o => o == orderLine);
            if (orderLine == null) return;

                _orderTotal -= orderLine.Total;
                _orderLines.Remove(orderLine);
        }

       
    }
    public class OrderLine
    {
        public int Total { get; internal set; }
    }

}

//In certain scenarios it is beneficial to not expose a full collection to consumers of a class. Some of these
//circumstances is when there is additional logic associated with adding/removing items from a collection.
//Because of this reason, it is a good idea to only expose the collection as something you can iterate over
//without modifying the collection.Let’s take a look at some code.

//As you can see, we have encapsulated the collection as to not expose the Add/Remove methods to
//consumers of this class. There is some other types in the.Net framework that will produce different
//behavior for encapsulating a collection such as ReadOnlyCollection but they do have different caveats with
//each.This is a very straightforward refactoring and one worth noting.Using this can ensure that consumers
//do not mis-use your collection and introduce bugs into the code.


