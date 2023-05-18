using System.Collections.Generic;
using System.Linq;




public class GremlinListRepository
{
    //this is the list
    private readonly List<Gremlin> _gremlinDb = new List<Gremlin>();
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
            _gremlinDb.Add(gremlin);
            return true;
        }
    }

    //Read All
    public List<Gremlin> GetGremlins()
    {
        return _gremlinDb;
    }

    //Read By Id
    public Gremlin GetGremlin(int gremlinId)
    {
        return _gremlinDb.SingleOrDefault(g => g.ID == gremlinId);
    }

    //Update
    public bool UpdateGremlin(int gremlinId, Gremlin newGremlinData)
    {
        var oldGremlinData = GetGremlin(gremlinId);
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
    public bool DeleteGremlin(int gremlinId)
    {
        return _gremlinDb.Remove(GetGremlin(gremlinId));
    }
}