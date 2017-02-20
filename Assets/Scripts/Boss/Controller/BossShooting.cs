using UnityEngine;
using System.Collections;

namespace Boss
{
	namespace Shooting
	{
		public class BossShooting : MonoBehaviour {
	
		public GameObject bullet;
		public Transform[] spawnPoints;

		int random;
		float timer;
		float shootTimer;
		private Transform _Holder;
		private GameObject _Bullet;

		public BossShootRotateLeft BSRL;
		public BossShootRotateRight BSRR;


		void Start () 
		{
			InvokeRepeating ("Shoot", 1f, 0.15f);
			_Holder = GameObject.Find ("_EnemyBulletHolder").transform;
		}

		public void Death()
		{
			CancelInvoke ();
		}
			
		void Update()
		{
	
			shootTimer += Time.deltaTime;
			
			if (shootTimer > 2f && Time.timeScale != 0) 
			{
				if (BSRL.enabled == true && BSRR.enabled == false) 
					{						
					BSRL.enabled = false;
					BSRR.enabled = true;
					shootTimer = 0;
				} 
				else if (BSRR.enabled == true && BSRL.enabled == false) 
				{
					BSRL.enabled = true;
					BSRR.enabled = false;
					shootTimer = 0;
				}
					else if (BSRL.enabled == false && BSRR.enabled == false)
					{
						BSRL.enabled = true;
						shootTimer = 1;
					}
				}
			}
		// Update is called once per frame
			void Shoot ()
			{
				for (int count = 0; count < spawnPoints.Length; count++) 
				{
					_Bullet = (GameObject) GameObject.Instantiate (bullet, spawnPoints [count].position, spawnPoints [count].rotation);
					//_Bullet.transform.parent = _Holder.transform;
				}
			}
		}
	}
}