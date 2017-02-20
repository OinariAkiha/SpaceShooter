using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using MVC.Controller;

namespace Other
{
	namespace SceneManagement
	{
		public class LoadScene : MonoBehaviour {

			public int _scene;
			InventoryController inventory;

			void Start()
			{
				inventory = GameObject.Find ("ProfileManager").GetComponent<InventoryController> ();
			}
	
			public void LoadStage()
			{
				inventory.checkInventory ();
				if (inventory.isAlive) {
					SceneManager.LoadScene (_scene);
				}
			}
		}
	}
}