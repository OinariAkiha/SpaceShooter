using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using MVC.View;

namespace MVC
{
    namespace Model
    {
        [System.Serializable]
        public class GameDataChangeEvent : UnityEvent<GameModel.GameData> { }

        [System.Serializable]
        public class LeaederBoardChangeEvent : UnityEvent< List<PlayerLeaderboardEntry> > { }

        [System.Serializable]
        public class GameModel : MonoBehaviour
        {
            // PLAYFAB DATA
            const string    extraLivesBundleId  = "ExtraLives";
            const int       livesBundlePrice    = 10;
            const string    gmCode              = "GD";
            const string    lvCode              = "LV";
            
            [SerializeField]
            public LeaederBoardChangeEvent LeaederBoardChangeEvents = new LeaederBoardChangeEvent(); 
            private List<PlayerLeaderboardEntry>  _leaderboard;
            public List<PlayerLeaderboardEntry> leaderboard
            {
                get { return _leaderboard; }
                set { _leaderboard = value; LeaederBoardChangeEvents.Invoke(_leaderboard); }
            }// The player's score.                        
            
            GameData        _gameData           = new GameData();
            public GameDataChangeEvent GameDataChangeEvents = new GameDataChangeEvent();
            public class GameData
            {                
                public int live         =  0;               
                public int gem          =  0;                
                public int highscore    =  0;
                public int liveMax      = -1;
                public int rechargeLiveTime = -1; //second 
            }

            void Awake()
            {
                GameDataChangeEvents.AddListener(GetComponent<LoginView>().updateUI);
                
            }

          /*  void Start()
            {
                var go = GameObject.Find("ScoreDisplay");
                if (go != null)
                    LeaederBoardChangeEvents.AddListener(go.GetComponent<LeaderBoardView>().onLeaderBoardChange);

            }*/
            
            public GameData gameData
            {
                get { return _gameData; }
                set { _gameData = value; GameDataChangeEvents.Invoke(_gameData); }
            }
            public void TryBuyLives()
            {
                Debug.Log("Purchaseing Lives...");
                PurchaseItemRequest request = new PurchaseItemRequest() { ItemId = extraLivesBundleId, VirtualCurrency = gmCode, Price = livesBundlePrice };
                PlayFabClientAPI.PurchaseItem(request, TryBuyLivesCallback, OnApiCallError);
            }

            void TryBuyLivesCallback(PurchaseItemResult result)
            {
                Debug.Log("Lives Purchased!");
                load();
            }

            public void TryLoseLife()
            {
                Debug.Log("Lose life...");
                ExecuteCloudScriptRequest request = new ExecuteCloudScriptRequest()
                {
                    FunctionName = "LoseLife",
                };

                PlayFabClientAPI.ExecuteCloudScript(request, LoseLifeCallback, OnApiCallError);
            }

            void LoseLifeCallback(ExecuteCloudScriptResult result)
            {
                // output any errors that happend within cloud script
                if (result.Error != null)
                {
                    Debug.LogError(string.Format("{0} -- {1}", result.Error, result.Error.Message));
                    return;
                }

                load();

                /*
                Debug.Log("BATTLE REPORT:");
                BattleResults grantedItems = PlayFab.Json.JsonWrapper.DeserializeObject<BattleResults>(result.FunctionResult.ToString());

                if (grantedItems != null)
                {
                    Debug.Log(string.Format("You found {0} gems. \n You lost {1} lives.", grantedItems.gemsFound, grantedItems.lostALife ? 1 : 0));
                    GetInventory();
                }
                else
                {
                    Debug.LogError("An error occured when attemtpting to deserialize the BattleResults.");
                }//*/
            }
   
            public void load()
            {
                GetUserInventoryRequest request = new GetUserInventoryRequest();
                PlayFabClientAPI.GetUserInventory(request, OnGetInventoryCallback, OnApiCallError);                        
            }         
            
            private void OnGetInventoryCallback(GetUserInventoryResult result)
            {
                Debug.Log(string.Format("Inventory retrieved. You have {0} items.", result.Inventory.Count));

                int gmBalance;
                result.VirtualCurrency.TryGetValue(gmCode, out gmBalance);               

                int lvBalance;
                result.VirtualCurrency.TryGetValue(lvCode, out lvBalance);

                VirtualCurrencyRechargeTime rechargeDetails;
                result.VirtualCurrencyRechargeTimes.TryGetValue(lvCode, out rechargeDetails);

                gameData =  (rechargeDetails != null) ?
                            new GameData()
                             {
                                 live = lvBalance,
                                 gem = gmBalance,
                                 rechargeLiveTime = rechargeDetails.SecondsToRecharge,
                                 liveMax = rechargeDetails.RechargeMax
                             } :
                            new GameData()
                             {
                                 live = lvBalance,
                                 gem = gmBalance,                     
                             };                           
            }

            public void TrySubmitScore(int score)
            {
                UpdatePlayerStatisticsRequest req = new UpdatePlayerStatisticsRequest();
                req.Statistics = new List<StatisticUpdate>();
                req.Statistics.Add(new StatisticUpdate { StatisticName = "TotalPoints", Version = 0, Value = score });

                PlayFabClientAPI.UpdatePlayerStatistics(req, null, OnApiCallError);
            }

            public void TryGetLeaderBoard()
            {
                PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest { StatisticName = "TotalPoints", StartPosition = 0, MaxResultsCount = 10 },
                                                (GetLeaderboardResult r) =>
                                                {
                                                    leaderboard = r.Leaderboard;                                                    
                                                },
                                                null);                
            }

            void OnApiCallError(PlayFabError err)
            {
                string http = string.Format("HTTP:{0}", err.HttpCode);
                string message = string.Format("ERROR:{0} -- {1}", err.Error, err.ErrorMessage);
                string details = string.Empty;

                if (err.ErrorDetails != null)
                {
                    foreach (var detail in err.ErrorDetails)
                    {
                        details += string.Format("{0} \n", detail.ToString());
                    }
                }

                Debug.LogError(string.Format("{0}\n {1}\n {2}\n", http, message, details));
            }
        }
    }
}
