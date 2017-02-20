using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Player
{
	namespace View
	{

		public class ShootingView : MonoBehaviour 
		{
			SpriteRenderer spriteRenderer;

			public void showCannon(GameObject canon)
			{
				spriteRenderer = canon.GetComponent<SpriteRenderer> ();

				spriteRenderer.color = new Color (1f, 1f, 1f, 1f);
			}
			
		}
	}
}
