using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpTable<T1, T2>
{
    //en algun momento lo vamos a usar... creo *inserte aqui carita pensando* 

    public delegate T2 FactoryMethod(T1 n);

    private Dictionary<T1, T2> _table = new Dictionary<T1, T2>();
    private FactoryMethod _factory;

    public LookUpTable(FactoryMethod factoryM)
    {
        _factory = factoryM;
    }

    public T2 GetValue(T1 key)
    {
        if (_table.ContainsKey(key))
            return _table[key];
        else
        {
            var value = _factory(key);
            _table[key] = value;
            return value;
        }
    }
}
