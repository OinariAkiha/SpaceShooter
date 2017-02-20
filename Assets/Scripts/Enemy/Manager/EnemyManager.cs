using UnityEngine;
using System.Collections;

namespace Enemy
{
	namespace Manager
	{
public class EnemyManager : MonoBehaviour 
{
	public GameObject[] enemies;
	public Transform[] spawnPoints;

	GameObject[] _enemies;
	Transform _Holder;
	int randomEnemy;
	int randomSpawn;
	float timer;
	public float spawnTime;
	void Awake()
	{
		for (int count = 0; count < enemies.Length; count++) 
		{
			PoolManager.WarmPool (enemies [count], 3);
		}

		_Holder = new GameObject ("_EnemyHolder").transform;

		_enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		for (int count = 0; count < _enemies.Length; count++) 
		{
			_enemies [count].transform.SetParent (_Holder);
			_enemies [count].SetActive (false);
		}
	}
	
	void Update () 
	{
		timer += Time.deltaTime;

		if (timer >= spawnTime && Time.timeScale != 0) 
		{
			timer = 0;
			EnemySpawn ();
		}
	}

	void EnemySpawn()
	{
		randomEnemy = Random.Range (0, enemies.Length);

		if (randomEnemy == 0) {
			randomSpawn = Random.Range (0, 3);
		} else if (randomEnemy == 1) {
			randomSpawn = Random.Range (3, 6);
		}else if (randomEnemy == 2) {
			randomSpawn = Random.Range (6, 9);			
		}

		PoolManager.SpawnObject (enemies [randomEnemy], spawnPoints [randomSpawn].position, spawnPoints [randomSpawn].rotation);
	}
}
	}
}
