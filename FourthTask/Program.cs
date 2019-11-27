using System;
using System.Collections.Generic;

namespace FourthTask
{
    abstract class Ship {
        private int timeInPort;
        protected int timeInService;
        private int amountOfDock;
        abstract protected void defineTimeOfService();
    }
    
    class SmallShip: Ship {
        static int minTimeInPort;
        static int maxTimeInPort;

        protected override void  defineTimeOfService() {
            this.timeInService = maxTimeInPort - minTimeInPort;
        }
    }

    class MiddleShip: Ship {
        static int minTimeInPort;
        static int maxTimeInPort;
        protected override void defineTimeOfService() {
            this.timeInService = maxTimeInPort - minTimeInPort;
        }
    }

    class BigShip: Ship {
        static int minTimeInPort;
        static int maxTimeInPort;
        protected override void defineTimeOfService() {
            this.timeInService = maxTimeInPort - minTimeInPort;
        }
    }
    
    class Harbor {
        private int capacity;
        private int currentCapacity;
        private List<Ship> shipQueue;
        public void addShip() {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<SmallShip> smallShipList = new List<SmallShip>();
            List<MiddleShip> middleShipList = new List<MiddleShip>();
            List<BigShip> BigShipList = new List<BigShip>();
            
        }
    }
}
