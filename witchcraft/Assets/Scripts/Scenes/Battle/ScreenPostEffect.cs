using UnityEngine;
using System.Collections;

public class ScreenPostEffect : MonoBehaviour
{

    public Material tone;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, tone);
    }
}
