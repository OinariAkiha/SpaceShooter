using UnityEngine;
using System.Collections;

namespace Boss
{
	namespace Model
	{
		public class BossModel : MonoBehaviour 
		{
			public float bossHP = 1500f;
			public float damageAmount = 20f;

			public float BossHP {
				get{return bossHP;}
				set 
				{
					bossHP = value;
					bossHP = Mathf.Clamp (bossHP, 0f, 1500f);
				}
			}
		}
	}
}
