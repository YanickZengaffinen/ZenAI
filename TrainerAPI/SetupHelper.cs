using TrainerAPI.Services;

namespace TrainerAPI
{
    public static class SetupHelper
    {
        public static void Setup()
        {
            ServiceRegistry.Instance.Register(new TrainerRegistry());
        }
    }
}
