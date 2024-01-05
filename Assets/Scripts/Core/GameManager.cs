using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TD.UI;

namespace TD.Core
{

    public class GameManager : MonoBehaviour
    {
        private TowerSpawner towerSpawnerCmp;
        private UIContoller UI;
        [NonSerialized] public int score = 0;
        [NonSerialized] public int towerLimit;
        [NonSerialized] public int enemyHealth;
        [NonSerialized] public int scoreLimit = 0;
        private int extraTowerScoreLimit = 5;
        private bool firstKill = false;
        private bool powerUpAvailable = false;


        void Awake()
        {
            towerSpawnerCmp = GetComponent<TowerSpawner>();
            UI = GameObject.FindGameObjectWithTag("UI").GetComponent<UIContoller>();
            Screen.SetResolution(1125, 2436, true);
        }

        public void OnEnable()
        {
            EventManager.OnKill += HandleKill;
        }

        public void OnDisable()
        {
            EventManager.OnKill -= HandleKill;
        }


        void Update()
        {
            // Spawn enemy with "E" key
            if (Input.GetKeyDown("e") && towerLimit > 0 && !PauseMenuController.isPaused)
            {
                towerSpawnerCmp.spawnTower();
                towerLimit--;
            }
            // Activate Power Up with "F" key
            if (powerUpAvailable && Input.GetKeyDown("f"))
            {
                powerUpAvailable = false;
                UI.togglePowerUp();
                EventManager.RaiseOnPowerUpUse();
            }
            //Score Limit increases as enemies are spawned. When the last enemy is killed victory UI is shown. 
            if (score == scoreLimit && firstKill) EventManager.RaiseOnLevelComplete(SceneManager.GetActiveScene().buildIndex);

        }

        private void HandleKill(string type)
        {
            //When an enemy dies score increases
            score++;
            // Players will be granted 1 extra tower when they eliminate 5 enemies
            if (score % extraTowerScoreLimit == 0) towerLimit++;
            if (type == "red")
            {
                UI.togglePowerUp();
                powerUpAvailable = true;
            }
            firstKill = true;

        }

    }
}



