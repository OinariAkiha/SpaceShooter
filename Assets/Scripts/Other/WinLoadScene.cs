using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Other
{
	namespace SceneManagement
		{
		public class WinLoadScene : MonoBehaviour 
		{
			public int _scene;
				
			void Start()
			{
				if (this.gameObject.activeSelf) {
					Invoke ("LoadStage", 1f);
				}
			}

			void LoadStage()
			{
				SceneManager.LoadScene (_scene);
			}
		}
	}
}
