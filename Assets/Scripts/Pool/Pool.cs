using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T>
{
    private List<PoolObject<T>> _poolList; 
    public delegate T CallbackFactory();

    private int _stock;
    private bool _dinamic = false;
    private PoolObject<T>.PoolCallback _init; 
    private PoolObject<T>.PoolCallback _finalize;
    private CallbackFactory _factory;

    public Pool(int initialStock, CallbackFactory factory, PoolObject<T>.PoolCallback initialize, PoolObject<T>.PoolCallback finalize, bool isDinamic)
    {
        _poolList = new List<PoolObject<T>>(); 

        _factory = factory;
        _dinamic = isDinamic;
        _stock = initialStock;
        _init = initialize;
        _finalize = finalize;

        for (int i = 0; i < _stock; i++)
        {
            _poolList.Add(new PoolObject<T>(_factory(), _init, _finalize));
        }
    }

    public PoolObject<T> GetPoolObject()
    {
        for (int i = 0; i < _stock; i++)
        {
            if (!_poolList[i].isActive)
            {
                _poolList[i].isActive = true;
                return _poolList[i];
            }
        }
        if (_dinamic)
        {
            PoolObject<T> po = new PoolObject<T>(_factory(), _init, _finalize);
            po.isActive = true;
            _poolList.Add(po);
            _stock++;
            return po;
        }
        return null;
    }

    public T GetObject()
    {

        for (int i = 0; i < _stock; i++)
        {
            if (!_poolList[i].isActive)
            {
                _poolList[i].isActive = true;               
                return _poolList[i].GetObj; 
            }
        }
        if (_dinamic)
        {
            PoolObject<T> po = new PoolObject<T>(_factory(), _init, _finalize);
            po.isActive = true;
            _poolList.Add(po);
            _stock++;
            return po.GetObj;
        }
        return default(T);
    }

    public void Disable(T obj)
    {
        foreach (PoolObject<T> poolObj in _poolList)
        {
            if (poolObj.GetObj.Equals(obj))
            {
                poolObj.isActive = false;
                return;
            }
        }
    }
}
