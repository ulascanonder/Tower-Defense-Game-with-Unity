using UnityEngine.SceneManagement;
using TD.Core;
using UnityEngine;
using Unity.VisualScripting;

public class GameOverMenuController : MonoBehaviour
{
    public GameObject gameOverMenuUI;

    public void OnEnable()
    {
        EventManager.OnGameOver += toggleGameOverScreen;
    }
    public void OnDisable()
    {
        EventManager.OnGameOver -= toggleGameOverScreen;
    }

    private void toggleGameOverScreen()
    {
        Time.timeScale = 0;
        gameOverMenuUI.SetActive(true); // Toggles Gamer Over Menu when game is over
    }

    public void retryButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reloads the current level
    }

}
