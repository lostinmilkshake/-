using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FourthTask
{

    abstract class Ship {
        public static float statTimeInService = 0;
        public int timeInService;
        public int timeOut;
        //public static int amountOfDock;
        abstract protected void defineTimeOfService();
        public int defineShipType()
        {
            if (this is SmallShip)
            {
                return 1;
            }
            else if (this is MiddleShip)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }
    
    class SmallShip: Ship {
        public static int minTimeInPort;
        public static int maxTimeInPort;
        public static int amountOfDock;
        //Random random;

        public SmallShip() {
            defineTimeOfService();
        }
        protected override void  defineTimeOfService() {
            Random newRand = new Random();
            this.timeInService = newRand.Next(minTimeInPort, maxTimeInPort);
        }
    }

    class MiddleShip: Ship {
        public static int minTimeInPort;
        public static int maxTimeInPort;
        public static int amountOfDock;
        public MiddleShip() {
            defineTimeOfService();
        }
        protected override void defineTimeOfService() {
            Random newRand = new Random();
            this.timeInService = newRand.Next(minTimeInPort, maxTimeInPort);
        }
    }

    class BigShip: Ship {
        public static int minTimeInPort;
        public static int maxTimeInPort;
        public static int amountOfDock;
        public BigShip() {
            defineTimeOfService();
        }
        protected override void defineTimeOfService() {
            Random newRand = new Random();
            this.timeInService = newRand.Next(minTimeInPort, maxTimeInPort);
        }
    }

    class Harbor
    {
        delegate void HarborEvent(string message);
        event HarborEvent NotifyAll;
        event HarborEvent NotifyOrder;

        private int currentCapacity;
        public int counter;
        public int timeInOperation;
        public int currentTime;
        private Queue<Ship> shipQueue;
        private List<Ship> shipService;
        public Harbor()
        {
            timeInOperation = 0;
            currentCapacity = 4;
            counter = 0;
            shipQueue = new Queue<Ship>();
            shipService = new List<Ship>();
        }
        public void addShip(Ship newShip)
        {
            int n;
            n = newShip.defineShipType();
            if (n > currentCapacity)
            {
                if ((shipQueue.Count == 0) || (newShip != shipQueue.Peek()))
                {
                    NotifyOrder?.Invoke("Корабль добавлен в очередь");
                    shipQueue.Enqueue(newShip);
                }
            }
            else
            {
                if ((shipQueue.Count > 0) && (newShip == shipQueue.Peek()))
                {
                    shipQueue.Dequeue();
                    if (newShip is SmallShip)
                    {
                        NotifyOrder?.Invoke("Малый корабль вышел из очереди и поступил на обслуживание");
                    }
                    else if (newShip is MiddleShip)
                    {
                        NotifyOrder?.Invoke("Средний корабль вышел из очереди и поступил на обслуживание");
                    }
                    else
                    {
                        NotifyOrder?.Invoke("Большой корабль вышел из очереди и поступил на обслуживание");
                    }
                }

                currentCapacity -= n;
                if (newShip is SmallShip)
                {
                    NotifyAll?.Invoke("Малый корабль поступил на обслуживание");
                }
                else if (newShip is MiddleShip)
                {
                    NotifyAll?.Invoke("Средний корабль поступил на обслуживание");
                }
                else
                {
                    NotifyAll?.Invoke("Большой корабль поступил на обслуживание");
                }
                NotifyAll?.Invoke($"Время обслуживания {newShip.timeInService} часов");
                newShip.timeOut = currentTime + newShip.timeInService;
                shipService.Add(newShip);
            }
        }

        public void lookForNew()

        {
            int i = 0;
            while (i < shipService.Count)
            {
                if (currentTime == shipService[i].timeOut)
                {
                    currentCapacity += shipService[i].defineShipType();
                    shipService.RemoveAt(i);
                    Console.WriteLine("Корабль обслужен");
                    counter++;
                }
                else
                {
                    i++;
                }
            }

            if (shipQueue.Count > 0)
            {
                for (int j = 0; j < shipQueue.Count; j++)
                    addShip(shipQueue.Peek());
            }
        }
        public void Simulate()
        {
            NotifyAll += DisplayMessage;
            NotifyOrder += DisplayMessage;
            currentTime = 0;
            Random random = new Random();

            Queue<SmallShip> smallShipList = new Queue<SmallShip>();
            Queue<MiddleShip> middleShipList = new Queue<MiddleShip>();
            Queue<BigShip> bigShipList = new Queue<BigShip>();


            SmallShip.minTimeInPort = 1;
            SmallShip.maxTimeInPort = 3;
            SmallShip.amountOfDock = 1;


            MiddleShip.minTimeInPort = 4;
            MiddleShip.maxTimeInPort = 6;
            MiddleShip.amountOfDock = 2;

            BigShip.minTimeInPort = 6;
            BigShip.maxTimeInPort = 10;
            BigShip.amountOfDock = 3;

            for (int i = 0; i < 6; i++)
            {
                SmallShip newShip = new SmallShip();
                smallShipList.Enqueue(newShip);
            }

            for (int i = 0; i < 4; i++)
            {
                MiddleShip newShip = new MiddleShip();
                middleShipList.Enqueue(newShip);
            }

            for (int i = 0; i < 1; i++)
            {
                BigShip newShip = new BigShip();
                bigShipList.Enqueue(newShip);
            }

            int randMin = 1;
            int randMax = 2;

            do
            {
                if (currentTime % 2 == 0)
                {
                    //System.Threading.Thread.Sleep();
                    switch (random.Next(1, 4))
                    {
                        case 1:
                            if (smallShipList.Count > 0)
                            {
                                NotifyAll?.Invoke($"Поступил новый малый корабль в {currentTime} часов");
                                this.addShip(smallShipList.Dequeue());
                            }
                            break;
                        case 2:
                            if (middleShipList.Count > 0)
                            {
                                NotifyAll?.Invoke($"Поступил новый средний корабль в {currentTime} часов");
                                this.addShip(middleShipList.Dequeue());
                            }
                            break;
                        case 3:
                            if (bigShipList.Count > 0)
                            {
                                NotifyAll?.Invoke($"Поступил новый большой корабль в {currentTime} часов");
                                this.addShip(bigShipList.Dequeue());
                            }
                            break;
                        default:
                            break;
                    }
                    randMin += currentTime;
                    randMax += currentTime;
                }
                this.lookForNew();
                currentTime++;
            } while (this.counter < 10);
            NotifyAll -= DisplayMessage;
            NotifyOrder -= DisplayMessage;
            Thread.Sleep(50);
        }

        public virtual void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    class FourthTask
    {
        // A = 1, B = 2, C = 3, D = 1, E = 6, F = 4, G = 10, H = 6        
        static void Main(string[] args)
        {
            Harbor harbor = new Harbor();
            harbor.Simulate();
        }

    }
}
