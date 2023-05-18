using System.Collections.Generic;
using System.Linq;



public class GremlinDictionaryRepository
{
    private readonly Dictionary<int, Gremlin> _gremlinDb = new Dictionary<int, Gremlin>();
    private int _count = 0;

    //C.R.U.D

    //Create
    public bool AddGremlin(Gremlin gremlin)
    {
        if (gremlin is null)
        {
            return false;
        }
        else
        {
            _count++;
            gremlin.ID = _count;
            _gremlinDb.Add(gremlin.ID, gremlin);
            return true;
        }
    }

    //Read All
    public Dictionary<int, Gremlin> GetGremlins()
    {
        return _gremlinDb;
    }

    //Read by Id
    public Gremlin GetGremlinByKey(int key)
    {
        foreach (KeyValuePair<int, Gremlin> gremlin in _gremlinDb)
        {
            if (gremlin.Key == key)
            {
                return gremlin.Value;
            }
        }
        return null;
    }

    //Update
    public bool UpdateGremlin(int key, Gremlin newGremlinData)
    {
        Gremlin oldGremlinData = GetGremlinByKey(key);
        if (oldGremlinData != null)
        {
            oldGremlinData.Name = newGremlinData.Name;
            oldGremlinData.PwrLvl = newGremlinData.PwrLvl;
            oldGremlinData.GremlinType = newGremlinData.GremlinType;
            return true;
        }
        return false;
    }

    //Delete
    public bool DeleteGremlin(int key)
    {
        return _gremlinDb.Remove(key);
    }
}