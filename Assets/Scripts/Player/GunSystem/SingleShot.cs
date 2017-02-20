using UnityEngine;
using System.Collections;
using Player.Controller;

namespace Player
{
	namespace GunSystem
	{
		public class SingleShot : MonoBehaviour, IWeapon {
			
			PlayerShootingController playerSC;
			public GameObject shootingObject;

			void Start () 
			{
				playerSC = shootingObject.GetComponent<PlayerShootingController>();
				InvokeRepeating ("Shoot", 2f, 0.5f);
			}

			void OnDisable()
			{
				CancelInvoke ();
			}

			public void Shoot()
			{
				PoolManager.SpawnObject (playerSC.bullet, playerSC.spawnpoint[0].position, playerSC.spawnpoint[0].rotation);
			}
		}
	}
}

