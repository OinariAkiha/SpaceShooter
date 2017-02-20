using UnityEngine;
using System.Collections;
using Player.Model;
using Player.View;

namespace Player
{
	namespace Controller
	{
		public class PlayerItemPickUp : MonoBehaviour 
		{
			private PlayerModel model;
			private HPBarView hpBar;
			private PlayerShootingController playerShootingController;

			public GameObject playerModelObject;
			public GameObject playerViewObject;

			public GameObject shield;

			void Start()
			{
				model = playerModelObject.GetComponent<PlayerModel> ();
				hpBar = playerViewObject.GetComponent<HPBarView> ();
			}

			void OnTriggerEnter2D(Collider2D other)
			{
				if (other.tag == "Health") 
				{
					model.Health += 20f;
				}
				else if (other.tag == "Shield")
				{
					model.Shield += 100f;
					shield.SetActive (true);
				}
			}
		}
	}
}
