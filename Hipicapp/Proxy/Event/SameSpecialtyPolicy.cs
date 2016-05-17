using Hipicapp.Model.Event;
using Hipicapp.Service.Exceptions;
using Spring.Stereotype;

namespace Hipicapp.Proxy.Event
{
    [Component]
    public class SameSpecialtyPolicy : ISameSpecialtyPolicy
    {
        public bool IsSatisfiedBy(Specialty left, Specialty right)
        {
            return left != null && right != null && left.Id == right.Id;
        }

        public void CheckSatisfiedBy(Specialty left, Specialty right)
        {
            if (!this.IsSatisfiedBy(left, right))
            {
                throw new NoSameSpecialtyException();
            }
        }
    }
}