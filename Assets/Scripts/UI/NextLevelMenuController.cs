using TD.Core;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



namespace TD.UI
{
    public class NextLevelMenuController : MonoBehaviour
    {
        public GameObject nextLevelUI;
        public GameObject victoryUI;
        private int levelPassed;
        public TextMeshProUGUI title;

        public void OnEnable()
        {
            EventManager.OnLevelComplete += toggleNextLevelUI;
        }
        public void OnDisable()
        {
            EventManager.OnLevelComplete -= toggleNextLevelUI;
        }

        private void toggleNextLevelUI(int level)
        {
            // If the game is complete victory UI is displayed
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            {
                nextLevelUI.SetActive(false);
                victoryUI.SetActive(true);
                return;
            }
            levelPassed = level;
            title.text = $"Level {levelPassed} Complete!";
            nextLevelUI.SetActive(true);
        }

        public void nextLevelButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


    }
}


