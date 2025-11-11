using System.Collections;
using UnityEngine;

public class DecalDestroyer : MonoBehaviour 
{
	[SerializeField] private float _lifeTime = 5.0f;
	[SerializeField] private AudioClip[] _clipEffects;
	[SerializeField] private bool _canMakeSound;

	private IEnumerator Start()
	{
		if(_canMakeSound)
        {
			GetComponent<AudioSource>().PlayOneShot(_clipEffects[Random.Range(0, _clipEffects.Length)]);
        }

		yield return new WaitForSeconds(_lifeTime);
		Destroy(gameObject);
	}
}