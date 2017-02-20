using UnityEngine;
using System;
using System.Collections;
using Enemy.Controller;
using Boss.Controller;

namespace AllBullet
{
	public class Bullet : MonoBehaviour {

		float bulletTimer;
		float speed = 0.15f;
		public GameObject hit;

		public AudioClip impact;
		public AudioClip shot;
		AudioSource sound;

		public float damage;
		private EnemyController enemyController;
		private BossController bossController;

	// Update is called once per frame
		void Update () 
		{
			bulletTimer += Time.deltaTime;

			transform.Translate (0,speed,0);

			if (bulletTimer > 1f && Time.timeScale != 0) 
			{
				PoolManager.ReleaseObject(this.gameObject);
				bulletTimer = 0;
			}
			
		}

		void OnEnable()
		{
			sound = GetComponent<AudioSource> ();
			sound.PlayOneShot (shot, 0.75f);
		}

		void OnTriggerEnter2D (Collider2D other)
		{
			if (other.tag == "Enemy") 
			{
				try{
				enemyController = other.gameObject.GetComponent<EnemyController> ();
				enemyController.TakeDamage (damage);
				}
				catch(Exception ex) {
					Debug.Log (ex);
					bossController = other.gameObject.GetComponent<BossController> ();
					bossController.TakeDamage (damage);
				}

				sound.PlayOneShot (impact);
				speed = 0;
				hit.SetActive (true);
				Invoke ("Release", 0.1f);
			}
		}

		void Release()
		{
			PoolManager.ReleaseObject (this.gameObject);
			hit.SetActive (false);
			speed = 0.15f;
			bulletTimer = 0;
		}
	}
}