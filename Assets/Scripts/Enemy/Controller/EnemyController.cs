using UnityEngine;
using System.Collections;
using Enemy.Model;

namespace Enemy
{
	namespace Controller
	{
		public class EnemyController : MonoBehaviour 
		{
			public float lifeTime;
			public GameObject explosion;
			public GameObject[] item;

			public AudioClip deathSound;
			public AudioClip hitSound;
			private AudioSource audioSource;

			private EnemyModel enemyModel;
			private BoxCollider2D enemyCollider;

			private float timer;

			void Awake()
			{
				enemyModel = GetComponent<EnemyModel> ();
				audioSource = GetComponent<AudioSource> ();
				enemyCollider = GetComponent<BoxCollider2D> ();
			}

			void Update()
			{
				timer += Time.deltaTime;

				if (timer > lifeTime && timer > Time.timeScale) 
				{
					timer = 0f;
					PoolManager.ReleaseObject (this.gameObject);
				}
			}

			public void TakeDamage(float damageAmount)
			{
				if (enemyModel.EnemyHP > 0f) {
					enemyModel.EnemyHP -= damageAmount;
					audioSource.PlayOneShot (hitSound);
				}
				else 
				{
					onDeath ();
					SpawnItem ();
				}
			}

			void onDeath()
			{
				StartCoroutine (Death ());
			}

			void SpawnItem()
			{
				Debug.Log (item.Length);
				int random = Random.Range (0, item.Length * 2);
				if (random < item.Length) {
					Instantiate (item [random], transform.position, Quaternion.identity);
				}

			}

			public IEnumerator Death()
			{
				enemyCollider.enabled = false;
				explosion.SetActive (true);
				audioSource.PlayOneShot (deathSound);

				yield return new WaitForSeconds (0.5f);

				ScoreManager.currentScore += 100;

				enemyCollider.enabled = true;
				explosion.SetActive (false);
				enemyModel.EnemyHP += enemyModel.startingHP;

				timer = 0f;
				PoolManager.ReleaseObject(this.gameObject);
			}
		}
	}
}
