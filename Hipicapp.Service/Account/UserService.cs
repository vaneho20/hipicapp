using Hipicapp.Model.Account;
using Hipicapp.Model.Authentication;
using Hipicapp.Repository.Account;
using Hipicapp.Utils.Helper;
using Hipicapp.Utils.Pager;
using Hipicapp.Utils.Security;
using Spring.Objects.Factory.Attributes;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using System.Collections.Generic;

namespace Hipicapp.Service.Account
{
    [Service]
    public class UserService : IUserService
    {
        [Autowired]
        private IUserRepository UserRepository { get; set; }

        [Transaction(ReadOnly = true)]
        public Page<User> Paginated(UserFindFilter filter, PageRequest pageRequest)
        {
            return UserRepository.Paginated(UserPredicates.ValueOf(filter, this.UserRepository.GetAllQueryable()), pageRequest);
        }

        [Transaction(ReadOnly = true)]
        public User Get(long? id)
        {
            return this.UserRepository.Get(id);
        }

        [Transaction(ReadOnly = true)]
        public User GetByUserName(string username)
        {
            return this.UserRepository.GetByUserName(username);
        }

        [Transaction]
        public User Save(User user)
        {
            user.Id = null;
            this.SetDefaultSpringSecurityUserDetailsState(user);
            user.Password = HelperMethods.GetHash(user.NewPassword);
            user.Id = UserRepository.Save(user);
            return user;
        }

        [Transaction]
        public void Save(IList<User> users)
        {
            UserRepository.Save(users);
        }

        [Transaction]
        public User SignIn(User user)
        {
            // Encriptamos el password y salvamos el usuario
            user.Password = CryptographyUtil.Encrypted(user.Password);
            this.UserRepository.Save(user);
            return user;
        }

        [Transaction]
        public User ToggleEnable(User user, bool enable)
        {
            User model = this.UserRepository.Get(user.Id);
            model.Enabled = enable;
            UserRepository.Update(model);
            return model;
        }

        [Transaction]
        public User Delete(User user)
        {
            UserRepository.Delete(this.UserRepository.Get(user.Id));
            return user;
        }

        private void SetDefaultSpringSecurityUserDetailsState(User user)
        {
            user.Enabled = true;
            user.AccountNonExpired = true;
            user.AccountNonLocked = true;
            user.CredentialsNonExpired = true;
        }
    }
}