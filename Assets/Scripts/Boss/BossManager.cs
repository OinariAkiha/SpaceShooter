using UnityEngine;
using System.Collections;

namespace Boss
{
	namespace Manager
	{
		public class BossManager : MonoBehaviour {

			public GameObject boss;
	
			void OnEnable () {
				Instantiate (boss, transform.position, transform.rotation);
			}
		}
	}
}
