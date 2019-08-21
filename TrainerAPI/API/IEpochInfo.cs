namespace TrainerAPI
{
    public interface IEpochInfo
    {
        int Id { get; }

        /// <summary>
        /// The loss of the epoch
        /// 
        /// Expected to be positive
        /// </summary>
        double Loss { get; }
    }
}
