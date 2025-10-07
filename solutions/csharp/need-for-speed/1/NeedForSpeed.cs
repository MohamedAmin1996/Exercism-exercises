class RemoteControlCar
{
    // TODO: define the constructor for the 'RemoteControlCar' class

    private int speed;
    private int batteryDrain;

    private int distanceDriven;
    private int currentbattery;

    public RemoteControlCar(int speed, int batteryDrain) 
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
        distanceDriven = 0;
        currentbattery = 100;
}

    public bool BatteryDrained()
    {
        return currentbattery < batteryDrain;
    }

    public int DistanceDriven()
    {
        return distanceDriven;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            distanceDriven += speed;
        }

        currentbattery -= batteryDrain;
    }

    public static RemoteControlCar Nitro()
    {
        RemoteControlCar car = new RemoteControlCar(50, 4);
        return car;

    }
}

class RaceTrack
{
    // TODO: define the constructor for the 'RaceTrack' class
    private int distance;

    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained())
        {
            car.Drive();
        }
        return car.DistanceDriven() >= distance;
    }
}
