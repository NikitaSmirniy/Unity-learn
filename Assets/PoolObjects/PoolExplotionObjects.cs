using UnityEngine;

namespace PoolObjects
{
    public class PoolExplotionObjects : MonoBehaviour
    {
        [SerializeField] private int _poolCount = 3;
        [SerializeField] private bool _autoExpand;
        [SerializeField] private Explosion _explosionPrefab;

        private PoolMono<Explosion> _pool;

        private void Start()
        {
            _pool = new PoolMono<Explosion>(_explosionPrefab, _poolCount, transform);
            _pool.AutoExpand = _autoExpand;
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                CreateExplotionObject();
            }
        }

        private void CreateExplotionObject()
        {
            var rX = Random.Range(-5, 5);
            var rZ = Random.Range(-5, 5);
            var rY = Random.Range(-5, 5);

            var rPosition = new Vector3(rX, rZ, rY);
            var explotionObject = _pool.GetFreeEelement();
            explotionObject.transform.position = rPosition;
        }
    }
}
