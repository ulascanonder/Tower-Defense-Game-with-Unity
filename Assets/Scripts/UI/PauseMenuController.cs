using System;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace TD.UI
{
    public class PauseMenuController : MonoBehaviour
    {
        [NonSerialized] public static bool isPaused = false;
        public GameObject pauseMenuUI;


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isPaused) pause();
                else resume();
            }
        }

        public void resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }

        public void pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }

        public void toMainMenu()
        {
            Time.timeScale = 1;
            isPaused = false;
            SceneManager.LoadScene(0);
        }


    }
}

