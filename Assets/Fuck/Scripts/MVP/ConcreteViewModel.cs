public class ConcreteViewModel : BaseViewModel
{
    private readonly IGameData _gameData;
    
    public int Health => _gameData.Health;
    
    public ConcreteViewModel(IGameData gameData)
    {
        _gameData = gameData;
    }
    
    public void DoSomething()
    {
        _gameData.AddHealth();
    }
}

public interface IGameData
{
    int Health { get; set; }
    void AddHealth();
}