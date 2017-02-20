using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Player
{
	namespace Model
	{
		public abstract class Model : MonoBehaviour 
		{
			public virtual void save()
			{
				string savedata = JsonUtility.ToJson (this, true);
				PlayerPrefs.SetString (this.GetType ().Name, savedata);
			}

			public virtual void load()
			{
				if (PlayerPrefs.HasKey (this.GetType ().Name) == false) {return;}

				string str;

				str = PlayerPrefs.GetString (this.GetType ().Name);
				JsonUtility.FromJsonOverwrite (str, this);
			}
		}
	}
}
