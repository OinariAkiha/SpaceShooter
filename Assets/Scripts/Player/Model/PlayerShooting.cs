using UnityEngine;
using System.Collections;

namespace Player
{
	namespace Model
	{
		public class PlayerShooting {

			private GameObject[] _bullets;

			private Transform _bullet;

	// Use this for initialization
			public void CreateBullets (GameObject bullet, GameObject homingBullet) 
			{
				_bullet = new GameObject ("_BulletHolder").transform;
				PoolManager.WarmPool (bullet, 30);
				PoolManager.WarmPool (homingBullet, 20);

				_bullets = GameObject.FindGameObjectsWithTag ("Bullet");

				for(int count = 0; count < _bullets.Length; count++)
				{
					_bullets [count].transform.SetParent(_bullet);
					_bullets [count].SetActive (false);
				}
			}
		}
	// Update is called once per frame

	}
}