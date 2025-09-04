public class RemoteControlCar
{
    private int batteryPercentage = 100;
    private int distanceDrivenInMeters = 0;
    private string[] sponsors = new string[0];
    private int latestSerialNum = 0;

    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage -= 10;
            distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors)
    {
        this.sponsors = (string[])sponsors.Clone();
    }

    public string DisplaySponsor(int sponsorNum)
    {
        if (sponsorNum < 0 || sponsorNum >= sponsors.Length)
        {
            throw new IndexOutOfRangeException("Sponsor number is out of bounds.");
        }
        return sponsors[sponsorNum];
    }

    public bool GetTelemetryData(ref int serialNum, out int batteryPercentage, out int distanceDrivenInMeters)
    {
        if (serialNum < latestSerialNum)
        {
            // Invalid serial number: set output parameters to -1 and update serialNum to latest.
            batteryPercentage = -1;
            distanceDrivenInMeters = -1;
            serialNum = latestSerialNum; // Update serialNum to the highest previous value
            return false;
        }
        else
        {
            // Valid serial number: update latestSerialNum and set output parameters to current values.
            latestSerialNum = serialNum; // Update latestSerialNum to the current valid serialNum
            batteryPercentage = this.batteryPercentage;
            distanceDrivenInMeters = this.distanceDrivenInMeters;
            return true;
        }
    }

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }
}

public class TelemetryClient
{
    private RemoteControlCar car;

    public TelemetryClient(RemoteControlCar car)
    {
        this.car = car;
    }

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        int batteryPercentage;
        int distanceDrivenInMeters;
        // Call GetTelemetryData using the 'out' keyword for the output parameters.
        bool success = car.GetTelemetryData(ref serialNum, out batteryPercentage, out distanceDrivenInMeters);
        // Check if the call was successful and if the car has been driven.
        if (!success || distanceDrivenInMeters == 0)
        {
            return "no data";
        }
        else
        {
            // Calculate battery usage per meter: (100 - current battery percentage) / distance driven
            decimal usagePerMeter = (decimal)(100 - batteryPercentage) / distanceDrivenInMeters;
            // Format to an integer as per example "usage-per-meter=5"
            return $"usage-per-meter={(int)usagePerMeter}";
        }
    }
}
