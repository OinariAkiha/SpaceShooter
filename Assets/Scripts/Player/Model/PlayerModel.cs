using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Player
{
	namespace Model
	{
		[System.Serializable]
		public class HealthChangedEvent : UnityEvent<float>{}

		public class PlayerModel : Model
		{
			[SerializeField]
			private float playerHp = 100f;

			[SerializeField]
			private float shieldHP = 0f;

			[SerializeField]
			public HealthChangedEvent onHealthChangedEvent;

			public float repeatDamagePeriod = 2f;
			public float damageAmount = 20f;

			public float Health
			{
				get {return playerHp;}
				set
				{
					playerHp = value;
					if (playerHp > 100f) playerHp = 100f;
					onHealthChangedEvent.Invoke (playerHp);
				}
			}

			public float Shield
			{
				get {return shieldHP;}
				set {
					shieldHP = value;
					if (shieldHP > 100f)
						shieldHP = 100f;
				}
			}
		}
	}
}