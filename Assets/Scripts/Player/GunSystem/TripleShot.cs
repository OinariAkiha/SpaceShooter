using UnityEngine;
using System.Collections;
using Player.Controller;

namespace Player
{
	namespace GunSystem
	{
		public class TripleShot : MonoBehaviour, IWeapon 
		{
			PlayerShootingController playerSC;
			public GameObject shootingObject;

			void Start () 
			{
				playerSC = shootingObject.GetComponent<PlayerShootingController>();
				InvokeRepeating ("Shoot", 0f, 0.5f);
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
		}
	}
}
