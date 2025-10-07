// TODO implement the IRemoteControlCar interface
public interface IRemoteControlCar
{
    public void Drive();
    public int DistanceTravelled { get; }
}
public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }
    public int CompareTo(ProductionRemoteControlCar? other)
    {
        if (other == null)
            throw new ArgumentNullException();
        return NumberOfVictories == other.NumberOfVictories ? 0 : NumberOfVictories > other.NumberOfVictories ? 1 : -1;
    }
    public void Drive()
    {
        DistanceTravelled += 10;
    }
}
public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }
    public void Drive()
    {
        DistanceTravelled += 20;
    }
}
public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }
    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        var list = new List<ProductionRemoteControlCar> { prc1, prc2 };
        list.Sort();
        return list;
    }
}