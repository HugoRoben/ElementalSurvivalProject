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
    int index = -1;
    void Start()
    {
        rawImage.texture = airTexture;
    }
    public void ChooseWater()
    {
        rawImage.texture = waterTexture;
    }
    public void ChooseAir()
    {
        index = 1;
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
        if (index != -1)
        {
            SceneManager.LoadScene(index);
        }
    }
}
