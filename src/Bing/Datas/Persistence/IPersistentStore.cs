﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bing.Domains.Repositories;

namespace Bing.Datas.Persistence
{
    /// <summary>
    /// 持久化存储
    /// </summary>
    /// <typeparam name="TPo">持久化对象类型</typeparam>
    public interface IPersistentStore<TPo> : IPersistentStore<TPo, Guid> where TPo : class, IPersistentObject<Guid>
    {
    }

    /// <summary>
    /// 持久化存储
    /// </summary>
    /// <typeparam name="TPo">持久化对象类型</typeparam>
    /// <typeparam name="TKey">持久化对象标识类型</typeparam>
    public interface IPersistentStore<TPo, in TKey> where TPo : class, IPersistentObject<TKey>
    {
        /// <summary>
        /// 获取未跟踪的持久化对象集合
        /// </summary>
        /// <returns></returns>
        IQueryable<TPo> FindAsNoTracking();

        /// <summary>
        /// 获取持久化对象集合
        /// </summary>
        /// <returns></returns>
        IQueryable<TPo> Find();

        /// <summary>
        /// 查找持久化对象集合
        /// </summary>
        /// <param name="criteria">条件</param>
        /// <returns></returns>
        IQueryable<TPo> Find(ICriteria<TPo> criteria);

        /// <summary>
        /// 查找持久化对象
        /// </summary>
        /// <param name="id">持久化对象标识</param>
        /// <returns></returns>
        TPo Find(object id);

        /// <summary>
        /// 查找持久化对象
        /// </summary>
        /// <param name="id">持久化对象标识</param>
        /// <returns></returns>
        Task<TPo> FindAsync(object id);

        /// <summary>
        /// 查找持久化对象集合
        /// </summary>
        /// <param name="ids">持久化对象标识集合</param>
        /// <returns></returns>
        List<TPo> FindByIds(params TKey[] ids);

        /// <summary>
        /// 查找持久化对象集合
        /// </summary>
        /// <param name="ids">持久化对象标识集合</param>
        /// <returns></returns>
        List<TPo> FindByIds(IEnumerable<TKey> ids);

        /// <summary>
        /// 查找持久化对象集合
        /// </summary>
        /// <param name="ids">持久化对象标识集合</param>
        /// <returns></returns>
        Task<List<TPo>> FindByIdsAsync(params TKey[] ids);

        /// <summary>
        /// 查找持久化对象集合
        /// </summary>
        /// <param name="ids">持久化对象标识集合</param>
        /// <returns></returns>
        Task<List<TPo>> FindByIdsAsync(IEnumerable<TKey> ids);

        /// <summary>
        /// 获取单个持久化对象
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        TPo Single(Expression<Func<TPo, bool>> predicate);

        /// <summary>
        /// 获取单个持久化对象
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        Task<TPo> SingleAsync(Expression<Func<TPo, bool>> predicate);

        /// <summary>
        /// 判断持久化对象是否存在
        /// </summary>
        /// <param name="ids">持久化对象标识集合</param>
        /// <returns></returns>
        bool Exists(params TKey[] ids);

        /// <summary>
        /// 判断持久化对象是否存在
        /// </summary>
        /// <param name="ids">持久化对象标识集合</param>
        /// <returns></returns>
        Task<bool> ExistsAsync(params TKey[] ids);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns></returns>
        List<TPo> Query(IQueryBase<TPo> query);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns></returns>
        Task<List<TPo>> QueryAsync(IQueryBase<TPo> query);

        /// <summary>
        /// 查找 - 返回未跟踪的持久化对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns></returns>
        List<TPo> QueryAsNoTracking(IQueryBase<TPo> query);

        /// <summary>
        /// 查找 - 返回未跟踪的持久化对象
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns></returns>
        Task<List<TPo>> QueryAsNoTrackingAsync(IQueryBase<TPo> query);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns></returns>
        PagerList<TPo> PagerQuery(IQueryBase<TPo> query);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns></returns>
        Task<PagerList<TPo>> PagerQueryAsync(IQueryBase<TPo> query);

        /// <summary>
        /// 分页查询 - 返回未跟踪的持久化对象集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns></returns>
        PagerList<TPo> PagerQueryAsNoTracking(IQueryBase<TPo> query);

        /// <summary>
        /// 分页查询 - 返回未跟踪的持久化对象集合
        /// </summary>
        /// <param name="query">查询对象</param>
        /// <returns></returns>
        Task<PagerList<TPo>> PagerQueryAsNoTrackingAsync(IQueryBase<TPo> query);

        /// <summary>
        /// 添加持久化对象
        /// </summary>
        /// <param name="po">持久化对象</param>
        void Add(TPo po);

        /// <summary>
        /// 添加持久化对象集合
        /// </summary>
        /// <param name="pos">持久化对象集合</param>
        void Add(IEnumerable<TPo> pos);

        /// <summary>
        /// 添加持久化对象
        /// </summary>
        /// <param name="po">持久化对象</param>
        /// <returns></returns>
        Task AddAsync(TPo po);

        /// <summary>
        /// 添加持久化对象集合
        /// </summary>
        /// <param name="pos">持久化对象集合</param>
        /// <returns></returns>
        Task AddAsync(IEnumerable<TPo> pos);

        /// <summary>
        /// 修改持久化对象
        /// </summary>
        /// <param name="po">持久化对象</param>
        void Update(TPo po);

        /// <summary>
        /// 修改持久化对象
        /// </summary>
        /// <param name="po">持久化对象</param>
        /// <returns></returns>
        Task UpdateAsync(TPo po);

        /// <summary>
        /// 移除持久化对象
        /// </summary>
        /// <param name="id">持久化对象标识</param>
        void Remove(TKey id);

        /// <summary>
        /// 移除持久化对象
        /// </summary>
        /// <param name="id">持久化对象标识</param>
        /// <returns></returns>
        Task RemoveAsync(TKey id);

        /// <summary>
        /// 移除持久化对象
        /// </summary>
        /// <param name="po">持久化对象</param>
        void Remove(TPo po);

        /// <summary>
        /// 移除持久化对象
        /// </summary>
        /// <param name="po">持久化对象</param>
        Task RemoveAsync(TPo po);

        /// <summary>
        /// 移除持久化对象集合
        /// </summary>
        /// <param name="ids">持久化对象编号集合</param>
        void Remove(IEnumerable<TKey> ids);

        /// <summary>
        /// 移除持久化对象集合
        /// </summary>
        /// <param name="ids">持久化对象编号集合</param>
        Task RemoveAsync(IEnumerable<TKey> ids);

        /// <summary>
        /// 移除持久化对象集合
        /// </summary>
        /// <param name="pos">持久化对象集合</param>
        void Remove(IEnumerable<TPo> pos);

        /// <summary>
        /// 移除持久化对象集合
        /// </summary>
        /// <param name="pos">持久化对象集合</param>
        Task RemoveAsync(IEnumerable<TPo> pos);
    }
}
