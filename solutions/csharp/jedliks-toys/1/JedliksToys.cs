class RemoteControlCar
{
    private int _meters = 0;
    private int _percentage = 100;

    public static RemoteControlCar Buy()
    {
        RemoteControlCar car = new RemoteControlCar();
        return car;
    }

    public string DistanceDisplay()
    {
        return $"Driven {_meters} meters";
    }

    public string BatteryDisplay()
    {
        if (_percentage == 0)
        {
            return "Battery empty";
        }
        else
        {
            return $"Battery at {_percentage}%";
        }
    }

    public void Drive()
    {
        if(_percentage != 0)
        {
            _meters += 20;
            _percentage -= 1;
        }
    }
}
