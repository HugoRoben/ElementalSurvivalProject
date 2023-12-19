// script for the main menu

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsPopUp;
    public RawImage rawImage;
    public RenderTexture waterTexture;
    public RenderTexture airTexture;
    public RenderTexture earthTexture;
    int index = 1;
    void Start()
    {
        rawImage.texture = airTexture;
        controlsPopUp.SetActive(false);
    }
    // following functions determine which character is showed in the menu 
    // and which scene to move to once start is played
    public void ChooseWater()
    {
        rawImage.texture = waterTexture;
    }
    public void ChooseAir()
    {
        index = 1;
        rawImage.texture = airTexture;
    }
    public void ChooseEarth()
    {
        index = 2;
        rawImage.texture = earthTexture;
    }
    // function that loads the selected level and locks the mouse to the screen
    public void LoadLevel()
    {
        SceneManager.LoadScene(index);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // functions for the button for controls
    public void OpenControls()
    {
        controlsPopUp.SetActive(true);
    }
    public void ExitControls()
    {
        controlsPopUp.SetActive(false);
    }
}
