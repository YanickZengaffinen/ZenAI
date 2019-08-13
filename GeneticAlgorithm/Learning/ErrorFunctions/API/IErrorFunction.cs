namespace GeneticAlgorithm.Learning.ErrorFunctions
{
    public interface IErrorFunction<T>
    {
        double CalculateError(T entity);
    }
}
