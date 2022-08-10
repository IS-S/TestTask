// Метод, который на основе параметров количества топлива и заданного расстояния вычисляет за сколько автомобиль его преодолеет. - тут
// скорее всего имеется ввиду на основе параметров средней скорости и заданного расстояния. Сделал так, видимо, очепятка в задании.

namespace TestTask
{
    public class Auto
    {
        protected float averageConsumption { get; set; }
        protected int fTankVolume { get; set; }
        protected int? fuelLeft { get; set; }
        protected int avSpeed { get; set; }
        protected readonly string type;

        protected Auto(int avSpeed, int fTankVolume, float averageConsumption, int? fuelLeft, string type)
        {
            if (fTankVolume < fuelLeft)
            {
                throw new Exception("\'Fuel left\' volume can not be higher than \'Full tank volume\'");
            }

            this.averageConsumption = averageConsumption;
            this.fTankVolume = fTankVolume;
            this.avSpeed = avSpeed;
            this.fuelLeft = fuelLeft;
            this.type = type;
        }
        public virtual float Range()
        {
            return (fuelLeft == null ? fTankVolume : (int)fuelLeft) / (averageConsumption / 100); 
        }
        public string timeEstimated(int range)
        {
            return "Range: " + range + ". Estimated time: " + ((float)range / avSpeed).ToString() + " hours.";
        }
    }
    public class Sportcar : Auto
    {
        public Sportcar(int avSpeed, float averageConsumption, int? fuelLeft) : base(avSpeed,80,averageConsumption,fuelLeft, "Sportcar")
        {
        }

        public override float Range()
        {
            return base.Range();
        }
    }
    public class CargoBob : Auto
    {
        public int capacity { get; set; }
        public CargoBob(int avSpeed, float averageConsumption, int? fuelLeft, int capacity) : base(avSpeed, 400, averageConsumption, fuelLeft, "Cargo")
        {
            if (capacity >= 20000)
            {
                throw new Exception("Maximum capacity is 20 tons (20k kgs)");
            }

            this.capacity = capacity;
        }

        public override float Range()
        {
            return base.Range() / 100 * (100 - (4*(capacity/200)));
        }
    }
    public class PassengerCar : Auto
    {
        public int passNumber { get; set; }
        public PassengerCar(int avSpeed, float averageConsumption, int? fuelLeft, int passNumber) : base(avSpeed, 70, averageConsumption, fuelLeft, "Passenger Car")
        {
            if(passNumber >= 5)
            {
                throw new Exception("Maximum passenger number is 4");
            }

            this.passNumber = passNumber;
        }
        public override float Range()
        {
            return base.Range() / 100 * (100 - (6 * passNumber));
        }
    }
}
