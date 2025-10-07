public class Player
{
    public int RollDie()
    {
        Random random = new Random();
        int number = random.Next(1, 19);

        return number;
    }

    public double GenerateSpellStrength()
    {
        Random random = new Random();
        double number = random.Next(1, 100);

        return number;
    }
}
