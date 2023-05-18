public class Gremlin
{
    public Gremlin()
    {

    }
    public Gremlin(string name, int pwrLvl, GremlinType gremlinType)
    {
        Name = name;
        PwrLvl = pwrLvl;
        GremlinType = gremlinType;
    }

    public int ID { get; set; }
    public string Name { get; set; }
    public int PwrLvl { get; set; }
    public GremlinType GremlinType { get; set; }
}
