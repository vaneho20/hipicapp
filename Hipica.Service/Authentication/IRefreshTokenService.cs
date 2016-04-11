using Hipica.Model.Authentication;
using Hipica.Utils.Pager;
using System.Collections.Generic;

namespace Hipica.Service.Authentication
{
    public interface IRefreshTokenService
    {
        /// <summary>
        /// Retrieves a single entity by its ID
        /// </summary>
        /// <param name="id">must not be <c>null</c></param>
        /// <returns>entity whose id matches id</returns>
        RefreshToken Get(string id);

        /// <summary>
        /// Returns every entity in the database
        /// </summary>
        /// <returns>list with entities</returns>
        IList<RefreshToken> GetAll();

        /// <summary>
        /// Returns every entity in the database, paginating the result
        /// </summary>
        /// <param name="pageRequest">must not be null</param>
        /// <returns>requested page number</returns>
        Page<RefreshToken> Paginated(PageRequest pageRequest);

        /// <summary>
        /// Saves the entity
        /// </summary>
        /// <param name="entity">to be saved</param>
        /// <returns>assigned identifier</returns>
        string Save(RefreshToken entity);

        /// <summary>
        /// Saves a entity list
        /// </summary>
        /// <param name="entity">entities to be saved</param>
        void Save(IList<RefreshToken> entity);

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity">to be updated</param>
        void Update(RefreshToken entity);

        void Delete(RefreshToken entity);
    }
}