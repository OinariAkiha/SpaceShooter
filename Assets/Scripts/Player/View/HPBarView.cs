using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Player
{
	namespace View
	{
		public class HPBarView : MonoBehaviour, IUIHandler 
		{

			private Slider slider;

			public float startHP = 100f;

			public void Start()
			{
				slider = GameObject.Find("PlayerHUD/HealthSlider").GetComponent<Slider>();

				slider.maxValue = startHP;
				slider.value = startHP;
			}

			public void DrawBar(float currentHP)
			{
				slider.value = currentHP;
			}
		}
	}
}
