using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using MVC.Model;

namespace MVC.Controller
{
    public class InventoryController : MonoBehaviour
    {
        private GameModel gm;
		public bool isAlive;
        
        // Use this for initialization
        void Awake()
        {
            gm = GetComponent<GameModel>();
        }
        
        public void loadPlayFabData()
        {
            gm.load();
        }

        public void buyLife()
        {
            gm.TryBuyLives();
        }

        public void loseLife()
        {
            gm.TryLoseLife();
        }

        public void submitScore(int score)
        {
            gm.TrySubmitScore(score);
        }
        public void loadLeaderBoard()
        {
            gm.TryGetLeaderBoard();
        }
        public void checkInventory()
        {
			if (gm.gameData.live <= 0)
				isAlive = false;
			else
				isAlive = true;
        }
    }
}
