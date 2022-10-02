using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display
{
    Color32 [] displaybuffer = new Color32[Define.SCREENSIZE_X * Define.SCREENSIZE_Y];

    public Texture2D mainTexture;

    public void Create()
    {
        mainTexture = new Texture2D(Define.SCREENSIZE_X, Define.SCREENSIZE_Y, TextureFormat.RGBA32, false);
    }

    public void Draw(int x, int y, Color32 color)
    {
        displaybuffer[y * Define.SCREENSIZE_X + x] = color;
    }
}
