#region KotikoBlog Header License

// // Solution: Curriculum
// // Project: Curriculum.Repository
// //
// // This file is included in the Curriculum solution.
// //
// // File created on 16/01/2016   23:12
// //
// // File Modified on 16/01/2016/   23:12
// 
// // Permission is hereby granted, free of charge, to any person obtaining a copy
// // of this software and associated documentation files (the "Software"), to deal
// // in the Software without restriction, including without limitation the rights
// // to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// // copies of the Software, and to permit persons to whom the Software is
// // furnished to do so, subject to the following conditions:
// //
// // The above copyright notice and this permission notice shall be included in all
// // copies or substantial portions of the Software.
// //
// // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// // IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// // FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// // AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// // LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// // OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// // SOFTWARE.

#endregion

#region

using System.Collections.Generic;
using System.Linq;
using Curriculum.CoreUtils.Pager;

#endregion

namespace Curriculum.Repository.Abstract
{
    /// <summary>
    ///     Generic NHibernate Dao
    /// </summary>
    /// <typeparam name="TEntity">Queriable entity type</typeparam>
    /// <typeparam name="TId">Entity's identifier type</typeparam>
    public interface IDao<TEntity, TId>
    {
        /// <summary>
        ///     Retrieves a single entity by its ID
        /// </summary>
        /// <param name="id">must not be <c>null</c></param>
        /// <returns>entity whose id matches id</returns>
        TEntity Get(TId id);

        /// <summary>
        ///     Returns every entity in the database
        /// </summary>
        /// <returns>list with entities</returns>
        IList<TEntity> GetAll();

        /// <summary>
        ///     Returns every entity in the database, paginating the result
        /// </summary>
        /// <param name="pageRequest">must not be null</param>
        /// <returns>requested page number</returns>
        Page<TEntity> Paginated(PageRequest pageRequest);
    }

    /// <summary>
    ///     Dao with support for generic query operations
    /// </summary>
    /// <typeparam name="TEntity">Queriable entity parent type</typeparam>
    /// <typeparam name="TId">Entity's identifier type</typeparam>
    public interface IDaoParent<TEntity, TId> : IDao<TEntity, TId>
    {
        /// <summary>
        ///     Returns single entity with given identifier value
        /// </summary>
        /// <typeparam name="T">the type of the entity</typeparam>
        /// <param name="id">must not be <c>null</c></param>
        /// <returns>the entity if it exists</returns>
        T Get<T>(TId id) where T : TEntity;

        /// <summary>
        ///     Returns every entity in the database with matching type
        /// </summary>
        /// <typeparam name="T">requested type</typeparam>
        /// <returns>the list</returns>
        IList<T> GetAll<T>() where T : TEntity;
    }

    /// <summary>
    ///     Dao with Save / Update support
    /// </summary>
    /// <typeparam name="TEntity">Queriable entity type</typeparam>
    /// <typeparam name="TId">Entity's identifier type</typeparam>
    public interface ISupportsSave<TEntity, TId>
    {
        /// <summary>
        ///     Saves the entity
        /// </summary>
        /// <param name="entity">to be saved</param>
        /// <returns>assigned identifier</returns>
        TId Save(TEntity entity);

        /// <summary>
        ///     Saves a entity list
        /// </summary>
        /// <param name="entity">entities to be saved</param>
        void Save(IList<TEntity> entity);

        /// <summary>
        ///     Updates an entity
        /// </summary>
        /// <param name="entity">to be updated</param>
        void Update(TEntity entity);
    }

    /// <summary>
    ///     Dao with generic dao support for save and update query operations
    /// </summary>
    /// <typeparam name="TEntity">Queriable entity supertype</typeparam>
    /// <typeparam name="TId">Entity's identifier type</typeparam>
    public interface ISupportsSaveParent<TEntity, TId> : ISupportsSave<TEntity, TId>
    {
        /// <summary>
        ///     Saves an entity
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <param name="entity">to be saved</param>
        void Save<T>(IList<T> entity) where T : TEntity;
    }

    /// <summary>
    ///     Dao with delete support
    /// </summary>
    /// <typeparam name="TEntity">Queriable entity type</typeparam>
    public interface ISupportsDelete<TEntity>
    {
        /// <summary>
        ///     Deletes an entity
        /// </summary>
        /// <param name="entity">to be deleted</param>
        void Delete(TEntity entity);
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="Tentity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public interface IQueryableDao<Tentity, TId>
    {
        IQueryable<Tentity> GetAllQueryable();
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="Tentity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    /// <typeparam name="TSearch"></typeparam>
    public interface ISearchableDao<Tentity, TId, TSearch>
    {
        Page<Tentity> Paginated(FindRequestImpl<TSearch> filter);
    }
}