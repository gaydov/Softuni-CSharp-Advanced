public class Pump
{
    public Pump(int amountGas, int distanceToNextPump, int index)
    {
        this.AmountGas = amountGas;
        this.DistanceToNextPump = distanceToNextPump;
        this.Index = index;
    }

    public int AmountGas { get; set; }

    public int DistanceToNextPump { get; set; }

    public int Index { get; set; }
}