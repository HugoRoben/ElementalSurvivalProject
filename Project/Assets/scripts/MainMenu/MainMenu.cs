using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public RawImage rawImage;
    public RenderTexture waterTexture;
    public RenderTexture fireTexture;
    public RenderTexture airTexture;
    public RenderTexture earthTexture;
    int index;
    public void ChooseWater()
    {
        index = 1;
        rawImage.texture = waterTexture;
    }
    public void ChooseFire()
    {
        index = 1;
        rawImage.texture = fireTexture;
    }
    public void ChooseAir()
    {
        index = 2;
        rawImage.texture = airTexture;
        // ChangeRawImageTexture(airTexture);
    }
    public void ChooseEarth()
    {
        index = 2;
        rawImage.texture = earthTexture;
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(index);
    }
}
