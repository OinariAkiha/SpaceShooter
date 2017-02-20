using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace Player
{
	namespace Controller
	{
		public class PlayerMovement : MonoBehaviour {

			private float speed = 4f;
			private Vector3 movement;
			private Rigidbody2D playerRigid;

			void Start () 
			{
				playerRigid = this.GetComponent<Rigidbody2D> ();
			}
	
			// Update is called once per frame
			void FixedUpdate () 
			{
				float horizontal = CrossPlatformInputManager.GetAxisRaw ("Horizontal");
				float vertical = CrossPlatformInputManager.GetAxisRaw ("Vertical");
				Move (horizontal, vertical);
			}

			void Move(float horizontal, float vertical)
			{
				movement.Set (horizontal, vertical, 0f);
				movement = movement.normalized * speed * Time.deltaTime;
					
				playerRigid.MovePosition (transform.position + movement);
			}
		}
	}
}