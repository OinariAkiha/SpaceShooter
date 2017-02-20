using UnityEngine;
using System.Collections;
using Boss.Model;
using Boss.Shooting;

namespace Boss
{
	namespace Controller
	{
		public class BossController : MonoBehaviour 
		{
			public GameObject[] explosion;
			public GameObject text;
			public GameObject[] item;

			public AudioClip deathSound;
			public AudioClip hitSound;
			private AudioSource audioSource;

			private BossShooting bossShoot;
			private BossModel bossModel;
			private CircleCollider2D bossCollider;

			void Awake()
			{
				bossShoot = GetComponent<BossShooting> ();
				bossModel = GetComponent<BossModel> ();
				audioSource = GetComponent<AudioSource> ();
				bossCollider = GetComponent<CircleCollider2D> ();
			}

			public void TakeDamage(float damageAmount)
			{
				if (bossModel.BossHP > 0f) {
					bossModel.BossHP -= damageAmount;
					audioSource.PlayOneShot (hitSound);
					SpawnItem ();
				}
				else 
				{
					onDeath ();
				}
			}

			void SpawnItem()
			{
				int random = Random.Range (0, item.Length * 4);
				if (random < item.Length) {
					Instantiate (item [random], transform.position, Quaternion.identity);
				}
			}

			void onDeath()
			{
				StartCoroutine (Death ());
			}

			public IEnumerator Death()
			{
				bossCollider.enabled = false;
				bossShoot.Death ();

				for (int count = 0; count < explosion.Length; count++) 
				{
					explosion[count].SetActive (true);
				}
				audioSource.PlayOneShot (deathSound);

				yield return new WaitForSeconds (1.5f);

				Instantiate (text, new Vector2(0,0), Quaternion.identity);

				ScoreManager.currentScore += 10000;

				Destroy (gameObject);
			}
		}
	}
}
