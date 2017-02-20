using UnityEngine;
using System.Collections;
using Player.Controller;

namespace Player
{
	namespace GunSystem
	{
		public class HomingShot : MonoBehaviour, IWeapon 
		{

			PlayerShootingController playerSC;
			public GameObject shootingObject;

			void Start () 
			{
				playerSC = shootingObject.GetComponent<PlayerShootingController>();
				InvokeRepeating ("Shoot", 0f, 0.5f);
				InvokeRepeating ("homingShoot", 0.75f, 0.75f);
			}
				
			void OnDisable()
			{
				CancelInvoke ();
			}

			public void Shoot()
			{
				for (int count = 0; count < playerSC.spawnpoint.Length; count++) 
				{
					PoolManager.SpawnObject (playerSC.bullet, playerSC.spawnpoint [count].position, playerSC.spawnpoint [count].rotation);
				}
			}

			public void homingShoot()
			{
				PoolManager.SpawnObject (playerSC.homingBullet, playerSC.homingSpawner.position, playerSC.homingSpawner.rotation);
			}

		}
	}
}
