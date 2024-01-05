using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace TD.Core
{
    public class LevelManager : MonoBehaviour // This class contols the differing variables within levels.
    {
        private GameManager gameManager;
        [NonSerialized] public int enemyLimit;
        void Awake()
        {
            // Tower Limit, enemy number and enemy healt are increased with each level
            gameManager = GetComponent<GameManager>();
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                gameManager.towerLimit = 2;
                enemyLimit = 6;
                gameManager.enemyHealth = 100;
            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                gameManager.towerLimit = 3;
                enemyLimit = 10;
                gameManager.enemyHealth = 125;
            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                gameManager.towerLimit = 5;
                enemyLimit = 15;
                gameManager.enemyHealth = 150;
            }
        }

    }
}



