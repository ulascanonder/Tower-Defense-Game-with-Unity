using UnityEngine.SceneManagement;
using UnityEngine;



namespace TD.UI
{
    //This script manages the buttons of the main menu
    public class MainMenuController : MonoBehaviour
    {
        private bool instructionsOn = false;
        public GameObject mainMenuUI;
        public GameObject instructionsUI;

        public void playGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void instructionsButton()
        {
            if (!instructionsOn)
            {
                mainMenuUI.SetActive(false);
                instructionsUI.SetActive(true);
                instructionsOn = true;
            }
            else
            {
                instructionsUI.SetActive(false);
                mainMenuUI.SetActive(true);
                instructionsOn = false;
            }

        }


        public void exitGame()
        {
            Debug.Log("Quitting...");
            Application.Quit();
        }

    }
}


