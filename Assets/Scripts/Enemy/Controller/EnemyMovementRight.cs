using UnityEngine;
using System.Collections;

namespace Enemy
{
	namespace Movement
	{
		public class EnemyMovementRight : MonoBehaviour {

			void Update () 
			{
				transform.Translate (0.03f, 0, 0);
			}
		}
	}
}
