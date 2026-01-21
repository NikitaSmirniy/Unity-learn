using UnityEngine;

public class BulletSpawner : SpawnerBase<Bullet>
{
    public void Spawn(Vector3 origin, Vector2 direction)
    {
        var freeBullet = Pool.GetFreeEelement();

        freeBullet.gameObject.SetActive(true);
        freeBullet.transform.position = origin;
        freeBullet.FlyOutToDirection(direction);
        freeBullet.Hit += OnBulletHit;
    }

    private void OnBulletHit(Bullet bullet)
    {
        bullet.Hit -= OnBulletHit;
        bullet.gameObject.SetActive(false);
        Pool.TakeElement(bullet);
    }
}