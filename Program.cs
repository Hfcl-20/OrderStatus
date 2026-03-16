using System;
using System.Collections.Generic;

namespace LADERAS
{
    internal class Program
    {
        class Order
        {
            public int Id { get; set; }
            public string Item { get; set; }
            public DateTime DateOrdered { get; set; }
            public string Status
            {
                get
                {
                    int days = (DateTime.Now - DateOrdered).Days;
                    if (days == 0) return "Pending...";
                    else if (days == 1) return "Processing";
                    else if (days == 2) return "Shipped";
                    else return "Delivered";
                }
            }
        }

        static List<Order> orders = new List<Order>();
        static int nextId = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("ACCOUNT MANAGEMENT SYSTEM");

            string username = "onlybaddie";
            string password = "1738679";

            Console.Write("Enter username: ");
            string usernameInput = Console.ReadLine();
            Console.Write("Enter password: ");
            string passwordInput = Console.ReadLine();

            if (usernameInput == username && passwordInput == password)
            {
                Console.WriteLine("Login successful.");

                bool running = true;
                while (running)
                {
                    Console.WriteLine("\n--- Order System ---");
                    Console.WriteLine("1. Create Order");
                    Console.WriteLine("2. View Orders");
                    Console.WriteLine("3. Exit");
                    Console.Write("Choose: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1": CreateOrder(); break;
                        case "2": ViewOrders(); break;
                        case "3": running = false; break;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid login. Please try again.");
            }
        }

        static void CreateOrder()
        {
            Console.Write("Enter item name: ");
            string item = Console.ReadLine();

            orders.Add(new Order
            {
                Id = nextId++,
                Item = item,
                DateOrdered = DateTime.Now
            });

            Console.WriteLine("Order created!");
        }

        static void ViewOrders()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders yet.");
                return;
            }

            Console.WriteLine("\n--- Orders ---");
            foreach (var order in orders)
            {
                Console.WriteLine($"ID: {order.Id}, Item: {order.Item}, Ordered: {order.DateOrdered}, Status: {order.Status}");
            }
        }
    }
}
