using EnumExercises;
using System;

OrderStatus myPizzaOrder = OrderStatus.Ordered;

while (myPizzaOrder != OrderStatus.Delivered)
{
    switch (myPizzaOrder)
    {
        case OrderStatus.Ordered:
            Console.WriteLine("Is the pizza ready?");
            string readyResponse = Console.ReadLine(); 
            if (readyResponse == "y")
            {
                myPizzaOrder = OrderStatus.Ready;
            }
            break;
        case OrderStatus.Ready:
            Console.WriteLine("Is the pizza delivered?");
            string deliveredResponse = Console.ReadLine();
            if (deliveredResponse == "y")
            {
                myPizzaOrder = OrderStatus.Delivered;
            }
            break;
        case OrderStatus.Delivered:
            break;
    }
}
