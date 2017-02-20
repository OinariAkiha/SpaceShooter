using UnityEngine;
using System.Collections;

namespace Boss
{
	namespace Shooting
	{
		public class BossShootRotateLeft : MonoBehaviour {

			public Transform[] spawnPoints;
	
			// Update is called once per frame
			void Update () 
			{
				spawnPoints [0].Rotate (Vector3.forward);
				spawnPoints [1].Rotate (Vector3.forward);
			}
		}
	}
}