<<<<<<< HEAD
// script for the game-over scene

=======
>>>>>>> fe62b33e0b64134a2ecfd9fb2894ffbfb67925f0
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOver : MonoBehaviour
{
    public int totalKills;
    public TextMeshProUGUI killCount;
    public TextMeshProUGUI roundCount;
    public int finalRoundNumber;

    void Start()
    {
        totalKills = PlayerPrefs.GetInt("EnemiesTotal", 0);
        finalRoundNumber = PlayerPrefs.GetInt("CurrentWave", 0);
        killCount.text = totalKills.ToString();
        roundCount.text = finalRoundNumber.ToString();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
    }
    public void LoadTitleScreen()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();     
    }
}
