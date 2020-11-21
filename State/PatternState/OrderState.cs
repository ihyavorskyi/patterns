using System;
using static System.Console;

namespace PatternState
{
    internal abstract class OrderState
    {
        public String NameState { get; set; }

        public abstract void NextState(Order order);
    }

    internal class WaytingForPaiment : OrderState
    {
        public WaytingForPaiment()
        {
            NameState = "Wayting for paiment";
            WriteLine(NameState);
        }

        public override void NextState(Order order)
        {
            order.orderState = new Shipping();
        }
    }

    internal class Shipping : OrderState
    {
        public Shipping()
        {
            NameState = "Shipping";
            WriteLine(NameState);
        }

        public override void NextState(Order order)
        {
            order.orderState = new Delivered();
        }
    }

    internal class Delivered : OrderState
    {
        public Delivered()
        {
            NameState = "Delivered";
            WriteLine(NameState);
        }

        public override void NextState(Order order)
        {
            order.orderState = new Delivered();
        }
    }

    internal class Canceled : OrderState
    {
        public Canceled()
        {
            NameState = "Order is canceled";
            WriteLine(NameState);
        }

        public override void NextState(Order order)
        {
            order.orderState = new Canceled();
        }
    }

    internal class Order
    {
        public OrderState orderState { get; set; }

        public Order()
        {
            orderState = new WaytingForPaiment();
        }

        public void Next()
        {
            orderState.NextState(this);
        }

        public void CancelOrder()
        {
            if (orderState.NameState == "Wayting for paiment")
            {
                orderState = new Canceled();
            }
            else
            {
                WriteLine("Order can`t be canceled");
            }
        }
    }
}