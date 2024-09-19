namespace MedicalDevice.Services
{
    public class SessionService
    {
        private static readonly object CurrentUserLock = new { };
        private static Ulid CurrentUserId = Ulid.Empty;

        public void SetUserId(Ulid guid)
        {
            lock (CurrentUserLock)
            {
                CurrentUserId = guid;
            }
        }

        public Ulid GetUserId()
        {
            lock (CurrentUserLock)
            {
                if (CurrentUserId == Ulid.Empty) throw new InvalidOperationException("Current user id not set");
                return CurrentUserId;
            }
        }
    }
}