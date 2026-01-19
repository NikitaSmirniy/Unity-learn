public class BombSpawnerUnit : SpawnerUnitBase<Bomb>
{
    public void Spawn(Cube cube)
    {
        var freeBomb = PoolMono.GetFreeEelement();

        freeBomb.Dead += OnDead;
        freeBomb.gameObject.SetActive(true);
        freeBomb.transform.position = cube.transform.position;
        freeBomb.StartExplodeTimer();
        
        AddCreatedObjectsCount();
    }
    
    private void OnDead(Bomb bomb)
    {
        bomb.Dead -= OnDead;
        bomb.gameObject.SetActive(false);
        PoolMono.TakeElement(bomb);
    }
}