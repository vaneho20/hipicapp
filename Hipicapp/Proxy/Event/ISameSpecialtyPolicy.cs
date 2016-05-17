using Hipicapp.Model.Event;

namespace Hipicapp.Proxy.Event
{
    public interface ISameSpecialtyPolicy
    {
        bool IsSatisfiedBy(Specialty left, Specialty right);

        void CheckSatisfiedBy(Specialty left, Specialty right);
    }
}