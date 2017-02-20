using UnityEngine;
using System.Collections;

namespace Background
{
	public class BackgroundController : MonoBehaviour {
		
		float speed = -0.01f;
		public GameObject enemyManager;
		public GameObject bossManager;

		void Update () 
		{
			transform.Translate (speed, 0, 0);
		}

		void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "BG") 
			{
				speed = 0;
				enemyManager.SetActive (false);
				bossManager.SetActive (true);
			}
		}
	}
}