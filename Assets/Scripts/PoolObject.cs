using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject<T>
{
    public bool _active;
    public T _obj;
    public delegate void PoolCallBack(T obj);
    public PoolCallBack _initPool;
    public PoolCallBack _finalizationPool;

    public PoolObject(T obj, PoolCallBack initialization, PoolCallBack finalization)
    {
        _obj = obj;
        _initPool = initialization;
        _finalizationPool = finalization;
        _active = false;
    }

    public T GetObj
    {
        get { return _obj; }
    }

    public bool IsActive
    {
        get { return _active; }

        set
        {
            _active = value;
            if (_active)
            {
                if (_initPool != null)
                    _initPool(_obj);              
            }
            else
            {
                if (_finalizationPool != null)
                    _finalizationPool(_obj);
            }
        }
    }
}
