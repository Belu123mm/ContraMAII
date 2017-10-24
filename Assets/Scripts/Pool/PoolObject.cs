using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject<T>
{
    private bool active;
    private T _obj;
    public delegate void PoolCallback(T obj);
    private PoolCallback _initi;
    private PoolCallback _finalization;

    public PoolObject(T obj, PoolCallback initialization, PoolCallback finalization)
    {
        _obj = obj; 
        _initi = initialization;
        _finalization = finalization; 
        isActive = false;
    }

    public T GetObj
    {
        get { return _obj; }
    }

    public bool isActive
    {
        get { return active; }

        set 
        {
            active = value;
            if (active)
            {
                if (_initi != null) 
                    _initi(_obj); 
            }
            else
            {
                if (_finalization != null) 
                    _finalization(_obj);
            }
        }
    }
}
