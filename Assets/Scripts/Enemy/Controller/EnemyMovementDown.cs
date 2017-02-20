using UnityEngine;
using System.Collections;

namespace Enemy
{
	namespace Movement
	{
		public class EnemyMovementDown : MonoBehaviour {

			void Update () 
			{
				transform.Translate (0, 0.03f, 0);
			}
		}
	}
}
