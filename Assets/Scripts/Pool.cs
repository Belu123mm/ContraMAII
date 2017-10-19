using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T>
{
    private int _stock;
    private bool dinamic = false;

    private List<PoolObject<T>> _poolList;
    public delegate T CallbackFactory();
    private PoolObject<T>.PoolCallBack _init;
    private PoolObject<T>.PoolCallBack _finalize; 
    private CallbackFactory _factory;

    #region pool
    public Pool(int initialStock, CallbackFactory factory, PoolObject<T>.PoolCallBack initialize, PoolObject<T>.PoolCallBack finalize, bool isDinamic)
    {
        _poolList = new List<PoolObject<T>>(); 

        _factory = factory;
        dinamic = isDinamic;
        _stock = initialStock;
        _init = initialize;
        _finalize = finalize;

        for (int i = 0; i < _stock; i++)
        {
            _poolList.Add(new PoolObject<T>(_factory(), _init, _finalize));
        }
    }
    #endregion

    #region get pool
    public PoolObject<T> GetPool()
    {
        for (int i = 0; i < _stock; i++)
        {
            if (!_poolList[i].IsActive)
            {
                _poolList[i].IsActive = true;
                return _poolList[i];
            }
        }

        if (dinamic)
        {
            PoolObject<T> po = new PoolObject<T>(_factory(), _init, _finalize);

            po.IsActive = true;
            _poolList.Add(po);
            _stock++;
            return po;
        }

        return null;
    }
    #endregion

    #region Get obj
    public T GetObj()
    {
        for (int i = 0; i < _stock; i++)
        {
            if (!_poolList[i].IsActive)
            {
                _poolList[i].IsActive = true;
                return _poolList[i].GetObj;
            }
        }

        if (dinamic)
        {
            PoolObject<T> po = new PoolObject<T>(_factory(), _init, _finalize);
            po.IsActive = true;
            _poolList.Add(po);
            _stock++;
            return po.GetObj;
        }
        return default(T);
    }
    #endregion

    #region disable
    public void DisablePool(T obj)
    {
        foreach (PoolObject<T> po in _poolList)
        {
            if (po.GetObj.Equals(obj))
            {
                po.IsActive = false;
                return;
            }
        }
    }
    #endregion
}
