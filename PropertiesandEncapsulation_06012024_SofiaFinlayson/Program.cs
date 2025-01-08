using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesandEncapsulation_06012024_SofiaFinlayson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character buddy = new Character("Buddy");
            Inventory pocket = new Inventory(); // Capacity 20
            PowerUp speedBoost = new PowerUp("Speed Boost");

            // TESTING LOGIC

            buddy.Health = 100;  // Should work
            buddy.Health = -50;  // Should be prevented
            Console.WriteLine(buddy.IsAlive);

            pocket.AddItem();  // Create "AddItem" method in inventory class
            pocket.AddItem();  // Create "AddItem" method in inventory class
            Console.WriteLine($"Item count: {pocket.ItemCount}, Is full: {pocket.IsFull}");

            Console.WriteLine($"Is {speedBoost.Name} active? {speedBoost.IsActive}");
            speedBoost.UsePowerUp();
            Console.WriteLine($"Power-up duration: {speedBoost.Duration}");
        }
    }


    public class Character
    {
        public string Name { get; private set; }
        private int health;

        public int Health
        {
            get { return health; }
            set
            {
                // Make sure health does not surpass 100 or go below 0
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("Health must be between 0 - 100");
                }
                else
                {
                    health = value;
                }
            }
        }

        public bool IsAlive
        {
            // If player has more than 0 health, player is alive
            get { return health > 0; }
        }

        // Constructor
        public Character (string name = "Buddy")
        {
            Name = name;
            health = 100;
        }
    }

    public class Inventory
    {
        private int itemCount;
        private const int Capacity = 20;

        public int Gold { get; set; }

        public int ItemCount
        {
            get { return ItemCount; }
            private set
            {
                if (value > Capacity)
                {
                    Console.WriteLine("Inventory is full.");
                }
                else
                {
                    itemCount = value;
                }
            }
        }

        // If itemCount > inventory capacity, no more holding items
        public int IsFull
        {
            get { return itemCount >= Capacity; }
            set
            {

            }
        }

        public Inventory ()
        {
            itemCount = 0;
        }


        public void AddItem()
        {
            itemCount++;
        }

        //Read-only inventory property, add a constructor (?) and default to 20
        // int ItemCount... Cannot exceed capacity

    }

    public class PowerUp
    {
        public string Name { get; private set; }
        public float Duration { get; private set; }

        private bool isActive;

        // IsActive bool, if powerup is being used = true if not = false
        public bool IsActive
        {
            get { return Duration > 0; }
        }

        public PowerUp(string name)
        {
            Name = name;
            Duration = 6.0f;
            isActive = true;
        }

        public void UsePowerUp()
        {
            if (IsActive)
            {
                Duration -= 1.0f; // Decrease duration when power-up is used
            }
        }
    }
}