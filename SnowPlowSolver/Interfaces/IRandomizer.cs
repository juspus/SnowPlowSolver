namespace SnowPlowSolver.Interfaces
{
    internal interface IRandomizer
    {
        int GenerateBetween(int start, int end);
        double GeneratePercent();
    }
}