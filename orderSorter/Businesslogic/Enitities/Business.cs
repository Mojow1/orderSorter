using System.Collections.Generic;
using orderSorter.Businesslogic.Algoritme;
using orderSorter.Businesslogic.Business;
using orderSorter.Businesslogic.Business.Staff;
using orderSorter.Businesslogic.Fleet;
using orderSorter.Businesslogic.Interfaces;
using Org.BouncyCastle.Asn1.Cms;

namespace orderSorter
{
    public class Business
    {
        
        private Stock _stock;
        private Fleet _fleet;
        private Staff _staff;
        private List<IOrder> _orders;
        private List<Timeslot> _timeslots;

        public Business(Stock stock, Fleet fleet, Staff staff, List<IOrder> orders, List<Timeslot> timeslots)
        {
            _stock = stock;
            _fleet = fleet;
           _staff = staff;
            _orders = orders;
            _timeslots = timeslots;
        }

        public Stock Stock => _stock;

        public Fleet Fleet => _fleet;

        public Staff Staff => _staff;

        public List<IOrder> Orders => _orders;

        public List<Timeslot> Timeslots => _timeslots;


        public void AssignOrdersToKitchenTimeSlots(List<IOrder> orders, List<Timeslot> timeSlots)
        {
            OrderAssigner orderAssigner = new OrderAssigner();
            IAssignStrategy kitchen = new AssignKitchenLimitStrategy();
            
            orderAssigner.SetStrategy(kitchen);
            orderAssigner.AssignOrders(orders,timeSlots);
            kitchen.GetCancelledOrders();
            
        }

        public List<IOrder> GetDeniedOrders(IAssignStrategy strategy)
        {
            AssignKitchenLimitStrategy kitchen = (AssignKitchenLimitStrategy) strategy;

           return kitchen.GetCancelledOrders();
        }

        public List<Timeslot> GetAssignedTimeSlots(IAssignStrategy strategy)
        {
            AssignKitchenLimitStrategy kitchen = (AssignKitchenLimitStrategy) strategy;
            
            return kitchen.GetTimeSlots();
        }
        
        
        
    }
}