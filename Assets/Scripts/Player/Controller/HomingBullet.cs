using UnityEngine;
using System;
using System.Collections;
using Enemy.Controller;
using Boss.Controller;

namespace AllBullet
{
	public class HomingBullet : MonoBehaviour {

		float bulletTimer;
		public GameObject hit;

		float speed = 0.15f;
		float angularSpeed = 1.5f;
		Transform enemy;
		bool isLock;

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

			if (isLock) {
				Seek ();
			} else {
				transform.Translate (0, speed, 0);
			}

			if (bulletTimer > 5f && Time.timeScale != 0) 
			{
				PoolManager.ReleaseObject(this.gameObject);
				bulletTimer = 0;
				enemy = null;
			}

		}

		void Seek()
		{
			float leftOrRight = 0;

			if (enemy.position.x > transform.position.x) {
				leftOrRight = -1f;
			} else if (enemy.position.x < transform.position.x) {
				leftOrRight = 1f;
			}

			float totalRotate = angularSpeed * leftOrRight;
			transform.Rotate (0, 0, totalRotate);

			transform.Translate (0, speed, 0);
		}

		void OnEnable()
		{
			sound = GetComponent<AudioSource> ();
			sound.PlayOneShot (shot, 0.75f);

			try{
				enemy = GameObject.FindGameObjectWithTag ("Enemy").transform;
				print(enemy.name);
				isLock = true;
			}
			catch(Exception ex) {
				Debug.Log (ex);
				isLock = false;
			}
				
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
			enemy = null;
		}
	}
}