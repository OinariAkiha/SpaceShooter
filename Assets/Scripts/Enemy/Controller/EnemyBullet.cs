using UnityEngine;
using System.Collections;

namespace AllBullet
{
	public class EnemyBullet : MonoBehaviour {

		float bulletTimer;
		float speed = 0.15f;
		public GameObject hit;

		void Update () 
		{
			bulletTimer += Time.deltaTime;

			transform.Translate (0,speed,0);

			if (bulletTimer > 1f && Time.timeScale != 0) 
			{
				Destroy (gameObject);
			}

		}

		void OnTriggerEnter2D (Collider2D other)
		{
			if (other.tag == "Player") 
			{
				StartCoroutine (onHit ());
			}
		}

		public IEnumerator onHit()
		{
			speed = 0;
			hit.SetActive (true);

			yield return new WaitForSeconds (0.1f);
			Destroy (gameObject);
		}
	}
}