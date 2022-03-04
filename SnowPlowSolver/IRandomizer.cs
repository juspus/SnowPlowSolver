namespace SnowPlowSolver
{
    public interface IRandomizer
    {
        int GenerateBetween(int start, int end);
        double GeneratePercent();
    }
}