using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{

    public Material skybox;
    public int SkyboxLength = 7;

    void Start()
    {
        RenderSettings.skybox = skybox;
    }

    void Update()
    {
        float blend = Mathf.PingPong(0.1f * Time.time, 1.0f);
        RenderSettings.skybox.SetFloat("_Blend", blend);

        if (blend.ToString("0.0").Equals("1.0"))
        {
            LoadSkybox(1, (Random.Range(1, SkyboxLength)).ToString());
        }
        else if (blend.ToString("0.0").Equals("0.0"))
        {
            LoadSkybox(2, (Random.Range(1, SkyboxLength)).ToString());
        }
    }

    private void LoadSkybox(int SkyboxNumber, string TextureNumber)
    {
        skybox.SetTexture("_FrontTex" + SkyboxNumber, (Texture2D)Resources.Load(TextureNumber + "_Front"));
        skybox.SetTexture("_BackTex" + SkyboxNumber, (Texture2D)Resources.Load(TextureNumber + "_Back"));
        skybox.SetTexture("_LeftTex" + SkyboxNumber, (Texture2D)Resources.Load(TextureNumber + "_Left"));
        skybox.SetTexture("_RightTex" + SkyboxNumber, (Texture2D)Resources.Load(TextureNumber + "_Right"));
        skybox.SetTexture("_UpTex" + SkyboxNumber, (Texture2D)Resources.Load(TextureNumber + "_Up"));
        skybox.SetTexture("_DownTex" + SkyboxNumber, (Texture2D)Resources.Load(TextureNumber + "_Down"));
    }

}
