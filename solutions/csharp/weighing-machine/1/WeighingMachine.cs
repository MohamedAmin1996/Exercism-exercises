class WeighingMachine
{
    public int Precision { get; init; }
    private double _weight;

    // TODO: define the 'Precision' property
    public WeighingMachine(int precision)
    {
        this.Precision = precision;
    }

    // TODO: define the 'Weight' property
    public double Weight
    {
        get { return _weight; }
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException();
            _weight = value;
        }
    }

    // TODO: define the 'DisplayWeight' property
    public string DisplayWeight
    {
        get { return $"{(Weight - TareAdjustment).ToString($"F{Precision}")} kg"; }
    }

    // TODO: define the 'TareAdjustment' property
    public double TareAdjustment { get; set; } = 5.0;
}
