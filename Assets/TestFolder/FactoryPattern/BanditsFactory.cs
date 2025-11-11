using UnityEngine;

public class BanditsFactory
{
    public Unit CreateBandit()
    {
        var prefab = Resources.Load<GameObject>("Unit/Enemy");
        var go = Object.Instantiate(prefab);
        var bandit = go.GetComponent<EnemyUnit>();
        bandit.Init();
        return bandit;
    }
}