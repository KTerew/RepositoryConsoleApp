using System.Collections.Generic;
using System.Linq;


public class GremlinQueueRepository
{
    private readonly Queue<Gremlin> _gremlinDb = new Queue<Gremlin>();
    private int _count = 0;

    //C.R.U.D

    //Create
    public bool AddGremlin(Gremlin gremlinData)
    {
        if (gremlinData != null)
            return false;
        else
        {
            _count++;
            gremlinData.ID = _count;
            _gremlinDb.Enqueue(gremlinData);
            return true;
        }
    }

    //Read All
    public Queue<Gremlin> GetGremlins()
    {
        return _gremlinDb;
    }

    //Read By Id
    public Gremlin GetGremlin()
    {
        if (_gremlinDb.Count() > 0)
        {
            return _gremlinDb.Peek();
        }
        else
        {
            return null;
        }
    }

    //Update
    public bool UpdateGremlin(Gremlin newGremlinData)
    {
        //we can only do work with the gremin that is currently in line
        Gremlin gremlinInLine = GetGremlin();
        if (gremlinInLine != null)
        {
            gremlinInLine.Name = newGremlinData.Name;
            gremlinInLine.PwrLvl = newGremlinData.PwrLvl;
            gremlinInLine.GremlinType = newGremlinData.GremlinType;
            return true;
        }
        return false;
    }

    //Delete
    public bool DeleteGremlin()
    {
        if (_gremlinDb.Count() > 0)
        {
            _gremlinDb.Dequeue();
            return true;
        }
        else
        {
            return false;
        }
    }
}