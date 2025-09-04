public class RemoteControlCar
{
    public string? CurrentSponsor { get; private set; }
    private Speed currentSpeed;
    public ITelemetry Telemetry { get; }

    public RemoteControlCar()
    {
        Telemetry = new RemoteControlCarTelemetry(this);
    }

    public interface ITelemetry
    {
        public void Calibrate();
        public bool SelfTest();
        public void ShowSponsor(string sponsorName);
        public void SetSpeed(decimal amount, string unitsString);
    }

    private class RemoteControlCarTelemetry(RemoteControlCar parent) : ITelemetry
    {
        private readonly RemoteControlCar parent = parent;

        public void Calibrate() { }

        public bool SelfTest() => true;

        public void ShowSponsor(string sponsorName)
        {
            parent.SetSponsor(sponsorName);
        }

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }

            parent.SetSpeed(new Speed(amount, speedUnits));
        }
    }

    public string GetSpeed()
    {
        return currentSpeed.ToString();
    }

    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;
    }

    private void SetSpeed(Speed speed)
    {
        currentSpeed = speed;
    }

    private enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    private readonly struct Speed(decimal amount, SpeedUnits speedUnits)
    {
        public decimal Amount { get; } = amount;
        public SpeedUnits SpeedUnits { get; } = speedUnits;

        public override readonly string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return Amount + " " + unitsString;
        }
    }
}