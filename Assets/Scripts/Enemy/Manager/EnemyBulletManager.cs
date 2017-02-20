using UnityEngine;
using System.Collections;

namespace Enemy
{
	namespace Manager
	{
public class EnemyBulletManager : MonoBehaviour 
{
	private Transform _bullet;

	void Awake()
	{
		_bullet = new GameObject ("_EnemyBulletHolder").transform;
	}
}
	}
}