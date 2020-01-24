using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FourthTask
{

    abstract class Ship {
        public static float statTimeInService = 0; //Time in service of all ships
        public int timeInService; //Time in service of current ship
        public int timeOut;//Time, when service of the ship will be done
        abstract protected void defineTimeOfService(); //Defining time in service of current ship
        public int defineShipType() //Deifning type of ship
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
        public static int minTimeInPort { get; set; } //Minimum time in port of current ship 
        public static int maxTimeInPort { get; set; } //Maximum time in port of current ship
        private static int amountOfDock = 1; //Amount of dock, that ship needs for service

        public SmallShip() {
            defineTimeOfService();
        }
        protected override void  defineTimeOfService() {
            Random newRand = new Random();
            this.timeInService = newRand.Next(minTimeInPort, maxTimeInPort);
        }
    }

    class MiddleShip : Ship {
        public static int minTimeInPort { get; set; } //Minimum time in port of current ship 
        public static int maxTimeInPort {get; set;}//Maximum time in port of current ship
        private static int amountOfDock = 2; //Amount of dock, that ship needs for service
        public MiddleShip() {
            defineTimeOfService();
        }
        protected override void defineTimeOfService() {
            Random newRand = new Random();
            this.timeInService = newRand.Next(minTimeInPort, maxTimeInPort);
        }
    }

    class BigShip: Ship {
        public static int minTimeInPort { get; set; } //Minimum time in port of current ship 
        public static int maxTimeInPort { get; set; } //Maximum time in port of current ship
        private static int amountOfDock = 3; //Amount of dock, that ship needs for service
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
        //All events
        delegate void HarborEvent(string message);
        event HarborEvent NotifyAll;
        event HarborEvent NotifyOrder;
        event HarborEvent NotifyCurrentStat;
        event HarborEvent NotifyStat;

        private int currentCapacity; //Current free capacity of harbor
        private int capacity; //Capacity of harbor
        private int shipCounter; //Counter of how many ship passed service
        private int currentTime; //Current time in harbor
        private Queue<Ship> shipQueue; //Queue of ships, that waiting for service
        private List<Ship> shipService; //List of ships that are on service
        public Harbor()
        {
            currentCapacity = 4;
            capacity = 4;
            shipCounter = 0;
            shipQueue = new Queue<Ship>();
            shipService = new List<Ship>();
        }
        private void addShip(Ship newShip)
        {
            int n;
            n = newShip.defineShipType();
            //If current ship amount of docks is higher, than current harbor capacity
            if (n > currentCapacity) 
            {
                //Add to queue, if it isn't already ship from the queue
                if ((shipQueue.Count == 0) || (newShip != shipQueue.Peek()))
                {
                    NotifyOrder?.Invoke("Корабль добавлен в очередь");
                    shipQueue.Enqueue(newShip);
                }
            }
            else
            {
                //If it is ship from the queue, than remove it from the queue
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
                //Reducing current harbor capacity
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
                //Defining time out of current ship
                newShip.timeOut = currentTime + newShip.timeInService;
                //Adding current ship to service list
                shipService.Add(newShip);
            }
        }

        private void lookForNew()
        {
            int i = 0;
            //Looking through ships on service
            while (i < shipService.Count)
            {
                //If current ship finished service, than remove it from service
                if (currentTime == shipService[i].timeOut)
                {
                    currentCapacity += shipService[i].defineShipType();
                    Ship.statTimeInService += shipService[i].timeInService;
                    shipService.RemoveAt(i);
                    NotifyAll?.Invoke("Корабль обслужен");
                    shipCounter++;
                }
                else
                {
                    i++;
                }
            }
            //Checking if we can add on service ship from queue
            if (shipQueue.Count > 0)
            {
                for (int j = 0; j < shipQueue.Count; j++)
                    addShip(shipQueue.Peek());
            }
        }
        public void Simulate(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            //Defing event hadelers
            NotifyAll += DisplayAllMessage;
            NotifyOrder += DisplayQueueMessage;
            NotifyCurrentStat += DisplayCurrentStatMessage;
            NotifyStat += DisplayStatMessage;
            currentTime = 0;
            Random random = new Random();
            //Creating queue for all types of ships
            Queue<SmallShip> smallShipList = new Queue<SmallShip>();
            Queue<MiddleShip> middleShipList = new Queue<MiddleShip>();
            Queue<BigShip> bigShipList = new Queue<BigShip>();

            //Filling queue for all types of ships
            for (int i = 0; i < 30; i++)
            {
                SmallShip newShip = new SmallShip();
                smallShipList.Enqueue(newShip);
            }

            for (int i = 0; i < 15; i++)
            {
                MiddleShip newShip = new MiddleShip();
                middleShipList.Enqueue(newShip);
            }

            for (int i = 0; i < 5; i++)
            {
                BigShip newShip = new BigShip();
                bigShipList.Enqueue(newShip);
            }
            //Defing time intervals for all types of ships
            SmallShip.minTimeInPort = C;
            SmallShip.maxTimeInPort = D;
            MiddleShip.minTimeInPort = E;
            MiddleShip.maxTimeInPort = F;
            BigShip.minTimeInPort = G;
            BigShip.maxTimeInPort = H;
            //Defing time intervals for ship arrival
            int randMin = A;
            int randMax = B;
            //Finding time of arrival of first ship
            int timeOfNextShip = random.Next(randMin, randMax);
            do
            {
                //Checking if current time is time of arrival of new ship
                if (currentTime == timeOfNextShip)
                {
                    //Defining which type of ship has arrived
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
                    //Changing arrive intervals
                    randMin = currentTime + 1;
                    randMax = currentTime + 2;
                    //Finding time of arrival of next ship
                    timeOfNextShip = random.Next(randMin, randMax);
                }
                this.lookForNew();
                //Increasing current time
                currentTime++;
                //Displaing current statistics
                DisplayCurrentStatus();
                //Thread.Sleep(10);
            } while (this.shipCounter < 50);
            //Displaying all of statistics 
            DisplayStatistics();
            NotifyAll -= DisplayAllMessage;
            NotifyOrder -= DisplayQueueMessage;
            NotifyCurrentStat -= DisplayCurrentStatMessage;
            NotifyStat -= DisplayStatMessage;
        }

        public void DisplayCurrentStatus()
        {
            NotifyCurrentStat?.Invoke($"Текущее время {currentTime}");
            NotifyCurrentStat?.Invoke($"Длинна очереди {shipQueue.Count}");
            NotifyCurrentStat?.Invoke($"Загруженность порта {((float)(capacity -currentCapacity)/ (float)capacity)*100}%");
        }

        public void DisplayStatistics()
        {
            NotifyStat?.Invoke($"Пропускная способность {((float)(currentTime) / (float)shipCounter)}");
            NotifyStat?.Invoke($"Среднее время обслуживания {((float)(Ship.statTimeInService) / (float)shipCounter)}");
        }

        public virtual void DisplayAllMessage(string message)
        {
            Console.WriteLine(message);
        }
        public virtual void DisplayQueueMessage(string message)
        {
            Console.WriteLine(message);
        }

        public virtual void DisplayCurrentStatMessage(string message)
        {
            Console.WriteLine(message);
        }

        public virtual void DisplayStatMessage(string message)
        {
            Console.WriteLine(message);
        }

    }
    class FourthTask
    {
        // A = 1, B = 2, C = 3, D = 1, E = 6, F = 4, G = 10, H = 6        


    }
}
