using Common.Services;

namespace StorageEngine
{
    public static class SetupHelper
    {
        public static void Setup()
        {
            ServiceRegistry.Instance.Register(new StorageEngineRegistry());
        }
    }
}
