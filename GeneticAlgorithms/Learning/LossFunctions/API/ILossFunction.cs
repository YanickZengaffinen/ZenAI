namespace GeneticAlgorithm.Learning.ErrorFunctions
{
    public interface ILossFunction<T>
    {
        double CalculateLoss(T entity);
    }
}
