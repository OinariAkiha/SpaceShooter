using UnityEngine;
using System.Collections;

namespace Boss
{
	namespace Controller
	{
		public class BossMovement : MonoBehaviour {

			float speed = 5f;
			float playerPos;
			float movement;
			Rigidbody2D bossRigid;
			Transform player;

			bool isDead = false;

			void Awake () 
			{
				bossRigid = GetComponent<Rigidbody2D> ();
				player = GameObject.FindGameObjectWithTag ("Player").transform;
			}
	
			public void Death()
			{
				isDead = true;
				movement = 0;
				Move (transform.position.x);
			}

			void Update () 
			{
				if (!isDead) 
				{
					playerPos = player.position.x;
					Move (playerPos);
			}
		}
			
		void Move(float playerPos)
			{
				if (playerPos > this.transform.position.x) 
				{
					movement = 0.2f;
				} 
				else if (playerPos < this.transform.position.x) 
				{
					movement = -0.2f;
				}
				
				bossRigid.velocity = new Vector2 (movement, 0) * speed;
			}
		}
	}
}