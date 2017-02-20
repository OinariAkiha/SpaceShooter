using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Player.Model;
using Player.View;
using Player.Controller;
using MVC.Controller;

namespace Player
{
	namespace Controller
	{
		public class PlayerController : MonoBehaviour 
		{
			private float lastHitTime;

			private PlayerModel model;
			private HPBarView hpBar;
			private Rigidbody2D playerRB;

			public GameObject playerModelObject;
			public GameObject playerViewObject;
			public GameObject shield;
			public GameObject explosion;

			AudioSource audioSource;
			public AudioClip hitSound;
			public AudioClip deathSound;

			void Start()
			{
				model = playerModelObject.GetComponent<PlayerModel> ();
				hpBar = playerViewObject.GetComponent<HPBarView> ();
				audioSource = GetComponent<AudioSource> ();
			}

			public void OnTriggerEnter2D(Collider2D other)
			{
				if (other.tag == "EnemyBullet") 
				{
					if (Time.time > lastHitTime + model.repeatDamagePeriod) 
					{
						if (model.Shield > 0f) 
						{
							TakeDamageShield ();
							lastHitTime = Time.time;
						}
						else if(model.Shield <= 0f && model.Health > 0f)
						{
							TakeDamagePlayer ();
							lastHitTime = Time.time;
						}
						else
						{
							onDeath();
						}
					}
				}
			}

			void TakeDamageShield()
			{
				model.Shield -= model.damageAmount;
				audioSource.PlayOneShot (hitSound);

				if (model.Shield <= 0f) 
				{
					shield.SetActive (false);
				}
			}

			void TakeDamagePlayer()
			{
				model.Health -= model.damageAmount;
				audioSource.PlayOneShot (hitSound);
			}

			void onDeath()
			{
				if (ScoreManager.highScore < ScoreManager.currentScore) 
				{
					ScoreManager.highScore = ScoreManager.currentScore;
					PlayerPrefs.SetInt ("HighScore", ScoreManager.currentScore);
				}
				StartCoroutine (Death ());
			}

			public IEnumerator Death()
			{
				GameObject profile = GameObject.Find ("ProfileManager");
				profile.GetComponent<InventoryController> ().loseLife();

				explosion.SetActive (true);
				audioSource.PlayOneShot (deathSound);
				yield return new WaitForSeconds (0.5f);

				ScoreManager.currentScore = 0;
				SceneManager.LoadScene (3);
				Destroy (this.gameObject);
			}
		}
	}
}
