public class BombSpawner : SpawnerBase<Bomb>
{
    public void Spawn(Cube cube)
    {
        var freeBomb = PoolMono.GetFreeEelement();

        freeBomb.Exploded += OnExploded;
        freeBomb.gameObject.SetActive(true);
        freeBomb.transform.position = cube.transform.position;
        freeBomb.Explode();
        
        AddCreatedObjectsCount();
    }
    
    private void OnExploded(Bomb bomb)
    {
        bomb.Exploded -= OnExploded;
        bomb.gameObject.SetActive(false);
        PoolMono.TakeElement(bomb);
    }
}