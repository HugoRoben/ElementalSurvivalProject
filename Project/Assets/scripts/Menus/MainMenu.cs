using System.Collections;
using System.Collections.Generic;
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
    public void LoadLevel()
    {
        SceneManager.LoadScene(index);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void OpenControls()
    {
        controlsPopUp.SetActive(true);
    }
    public void ExitControls()
    {
        controlsPopUp.SetActive(false);
    }
}
