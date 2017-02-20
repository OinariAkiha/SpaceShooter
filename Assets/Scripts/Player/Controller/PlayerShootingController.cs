using UnityEngine;
using System.Collections;
using Player.Model;
using Player.View;
using Player.GunSystem;

namespace Player
{
	namespace Controller
	{
		public class PlayerShootingController : MonoBehaviour 
		{

			public MonoBehaviour[] gunSystem;
			public GameObject view;
			private int index = 1;
			private ShootingView shootingView;

			public GameObject bullet;
			public GameObject homingBullet;
			public GameObject homingCanon;
			public Transform homingSpawner;
			public Transform[] spawnpoint;

			GameObject weapon;

			PlayerShooting playerShooting = new PlayerShooting();
		
			// Use this for initialization
			void Awake () 
			{
				playerShooting.CreateBullets (bullet,homingBullet);
				shootingView = view.GetComponent<ShootingView> ();
			}

			void OnTriggerEnter2D(Collider2D other)
			{
				if (other.tag == "Weapon") 
				{
					if (index < gunSystem.Length) {
						gunSystem [index-1].enabled = false;
						index++;
						gunSystem [index-1].enabled = true;
					} else {
					}
				}
			}
		}
	}
}
