using UnityEngine;
using System.Collections;

namespace Enemy
{
	namespace Controller
	{
		public class EnemyShooting : MonoBehaviour {

			private Transform _Holder;
			private GameObject _Bullet;
			public GameObject bullet;
			public Transform[] spawnPoints;

			void Start()
			{
				_Holder = GameObject.Find ("_EnemyBulletHolder").transform;
			}

			void OnEnable () 
			{
				InvokeRepeating ("Shoot", 1f, 0.25f);
			}
	
			void Shoot () 
			{
				for (int count = 0; count < spawnPoints.Length; count++) {
					_Bullet = (GameObject) GameObject.Instantiate (bullet, spawnPoints [count].position, spawnPoints [count].rotation);
					_Bullet.transform.parent = _Holder.transform;
				}
			}

			void OnDisable()
			{
				CancelInvoke ();
			}
		}
	}
}
