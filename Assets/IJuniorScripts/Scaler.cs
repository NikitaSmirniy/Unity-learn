using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Scale();
    }

    private void Scale()
    {
        transform.localScale += new Vector3(_speed, _speed, _speed);
    }
}