using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Enemy
{
	namespace Model
	{
		public class EnemyModel : MonoBehaviour 
		{
			public float enemyHP;
			public float startingHP;
			//public float damageAmount = 20f;

			public float EnemyHP
			{
				get{ return enemyHP;}
				set
				{
					enemyHP = value;
					enemyHP = Mathf.Clamp (enemyHP, 0, 160f);

				}
			}
		}
	}
}