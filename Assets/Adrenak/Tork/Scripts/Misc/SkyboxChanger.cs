using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{

    public Material skybox;
    public Texture2D front;

    void Start()
    {
        RenderSettings.skybox = skybox;
        // StartCoroutine(SkyboxChange());
        LoadSkybox("1");
        LoadSkybox("2");
    }

    void Update()
    {
        float blend = Mathf.PingPong(0.01f * Time.time, 1.0f);
        RenderSettings.skybox.SetFloat("_Blend", blend);
    }

    private void LoadSkybox(string SkyboxNumber)
    {
        skybox.SetTexture("_FrontTex" + SkyboxNumber, (Texture2D)Resources.Load(SkyboxNumber + "_Front"));
        skybox.SetTexture("_BackTex" + SkyboxNumber, (Texture2D)Resources.Load(SkyboxNumber + "_Back"));
        skybox.SetTexture("_LeftTex" + SkyboxNumber, (Texture2D)Resources.Load(SkyboxNumber + "_Left"));
        skybox.SetTexture("_RightTex" + SkyboxNumber, (Texture2D)Resources.Load(SkyboxNumber + "_Right"));
        skybox.SetTexture("_UpTex" + SkyboxNumber, (Texture2D)Resources.Load(SkyboxNumber + "_Up"));
        skybox.SetTexture("_DownTex" + SkyboxNumber, (Texture2D)Resources.Load(SkyboxNumber + "_Down"));
    }

    // private IEnumerator SkyboxChange()
    // {
    //     while (true)
    //     {
    //         Material CurrentSkybox= RenderSettings.skybox;
    //         RenderSettings.skybox.Lerp(skyboxes[0],skyboxes[1],10f * Time.deltaTime);
    //         yield return new WaitForSeconds(50);
    //     }
    // }
}
