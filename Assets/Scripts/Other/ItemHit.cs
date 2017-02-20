using UnityEngine;
using System.Collections;

namespace Other
{
	public class ItemHit : MonoBehaviour 
	{
		float timer;

		void Update()
		{
			timer += Time.deltaTime;

			transform.Translate (0, -0.01f, 0);

			if (timer > 10 && Time.timeScale != 0) 
			{
				Destroy (this.gameObject);
			}
		}

		public void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Player") 
			{
				Destroy (this.gameObject);
			}
		}
	}
}
