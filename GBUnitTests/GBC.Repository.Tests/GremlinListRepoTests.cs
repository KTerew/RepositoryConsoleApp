
public class GremlinListRepoTests
{
    private GremlinListRepository _gRepo;
    public GremlinListRepoTests()
    {
        var stripe = new Gremlin
        {
            ID = 2,
            Name = "Stripe",
            GremlinType = GremlinType.King
        };

        var gizmo = new Gremlin
        {
            ID = 3,
            Name = "Gizmo",
            GremlinType = GremlinType.King
        };
        _gRepo = new GremlinListRepository();

        _gRepo.AddGremlin(stripe);
        _gRepo.AddGremlin(gizmo);
    }

    [Fact]
    public void AddGremlin_ShouldReturnTrue()
    {
        //Arrange
        Gremlin gremlinData = new Gremlin()
        {
            ID = 4,
            Name = "Dude",
            GremlinType = GremlinType.Minion
        };

        //Act
        bool isSuccess = _gRepo.AddGremlin(gremlinData);

        //Assert
        Assert.True(isSuccess);
    }
    
    [Fact]
    public void GetGremlins_ShouldReturnCorrectCount()
    {
        //Arrange
        
        //Act
        int expected = 2;
        int actual = _gRepo.GetGremlins().Count();

        //Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void GetGremlin_ShouldReturnCorrectGremlinName()
    {
        var expected = "Stripe";
        var actualName = _gRepo.GetGremlin(1).Name;

        Assert.Equal(expected, actualName);
    }

    [Fact]
    public void UpdateGremlin_ShouldReturnCorrectName()
    {
        //Arrange
        Gremlin newGremlinData = new Gremlin();
        newGremlinData.Name = "T-Dog";
        newGremlinData.PwrLvl = 9000;

        //Act
        int gremlinIdToUpdate = 1;

        bool isSuccess = _gRepo.UpdateGremlin(gremlinIdToUpdate, newGremlinData);
        //Assert
        Assert.True(isSuccess);
    }

    [Fact]
    public void DeleteGremlin_ShouldReturnTrue()
    {
        //Arrange
        
        //Act
        bool isSuccess = _gRepo.DeleteGremlin(2);
        int expectedCount = 1;
        int actualCount = _gRepo.GetGremlins().Count();

        //Assert
        Assert.True(isSuccess);
        Assert.Equal(expectedCount, actualCount);
    }
}
