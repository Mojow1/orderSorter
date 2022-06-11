using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using orderSorter.Businesslogic.Business;
using orderSorter.Businesslogic.Interfaces;

// https://circle.visual-paradigm.com/simple-order-system/
namespace orderSorter
{
    public class Order : IOrder
    {
        private int _id;
        private DateTime _orderDate;
        private DateTime _allowedEndTime;
        private bool _priority;
        private bool _orderAccepted; 
        private int _orderWeight;
        private List<IProduct> _products;
        
        // constructor voor het aanmaken van een nieuwe order
        public Order(DateTime orderDate, DateTime allowedEndTime, bool priority, List<IProduct> products)
        {
            _orderDate = orderDate;
            _allowedEndTime = allowedEndTime;
            _priority = priority;
            _products = products;
            _orderWeight = products.Sum(x => x.Weight);
        }



        // Constructor voor het toekennen van een id
        public Order(int id, DateTime orderDate, DateTime allowedEndTime, bool priority, List<IProduct> products)
        {
            _id = id;
            _orderDate = orderDate;
            _allowedEndTime = allowedEndTime;
            _priority = priority;
            _products = products;
            _orderAccepted = false;
            _orderWeight = products.Sum(x => x.Weight);
        }
        
        public Order(int id, DateTime orderDate, DateTime allowedEndTime, bool priority, int orderWeight)
        {
            _id = id;
            _orderDate = orderDate;
            _allowedEndTime = allowedEndTime;
            _priority = priority;
            _orderAccepted = false;
            _orderWeight = orderWeight;
        }


        // Constructor inclusief boolean orderaccepted
        public Order(int id, DateTime orderDate, DateTime allowedEndTime, bool priority, bool orderAccepted, 
            int orderWeight, List<IProduct> products)
        {
            _id = id;
            _orderDate = orderDate;
            _allowedEndTime = allowedEndTime;
            _priority = priority;
            _orderAccepted = orderAccepted;
            _orderWeight = orderWeight;
            _products = products;
        }

   

        public int Id => _id;

        public DateTime OrderDate => _orderDate;

        public DateTime AllowedEndTime => _allowedEndTime;

        public bool Priority => _priority;

        public int OrderWeight => _orderWeight;

        public List<IProduct> Products => _products;

        public bool OrderAccepted
        {
            get => _orderAccepted;
            set => _orderAccepted = value;
        }
        
        
    }
}