using UnityEngine;
using TD.Core;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace TD.UI
{
    public class UIContoller : MonoBehaviour
    {
        public TextMeshProUGUI scoreText, towerLimitText, LevelText;
        public CanvasGroup canvasGroup;
        public GameManager gameManager;
        public GameObject powerUpImg;
        private bool powerUpOn = false;

        void Awake()
        {
            LevelText.text = $"Level {SceneManager.GetActiveScene().buildIndex}";
            LevelText.transform.DOMoveX(0, 0.7f).SetDelay(0.5f).OnComplete(() => LevelText.transform.DOMoveX(10, 2).SetDelay(1));

        }

        void Update()
        {
            // Update Score and Tower limit
            scoreText.text = $"Score: {gameManager.score}";
            towerLimitText.text = $"Towers: {gameManager.towerLimit}";
        }

        // Toggle the Power Up Icon on and off
        public void togglePowerUp()
        {
            if (!powerUpOn)
            {
                powerUpImg.SetActive(true);
                powerUpOn = true;
            }
            else
            {
                powerUpImg.SetActive(false);
                powerUpOn = false;
            }

        }
    }
}

