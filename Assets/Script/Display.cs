using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display
{
    Color32 [] displaybuffer = new Color32[Define.SCREENSIZE_X * Define.SCREENSIZE_Y];

    public Texture2D mainTexture;

    public Display()
    {
        mainTexture = new Texture2D(Define.SCREENSIZE_X, Define.SCREENSIZE_Y, TextureFormat.RGBA32, false);
        mainTexture.filterMode = FilterMode.Point;

        for (int y = 0; y < Define.SCREENSIZE_Y; y++)
            for (int x = 0; x < Define.SCREENSIZE_X; x++)
                mainTexture.SetPixel(x, y, Color.black);
    }

    public void Draw(int x, int y, Color32 color)
    {
        displaybuffer[y * Define.SCREENSIZE_X + x] = color;
    }

    public void Render()
    {
        for (int y = 0; y < Define.SCREENSIZE_Y; y++)
            for (int x = 0; x < Define.SCREENSIZE_X; x++)
            {
                int ypos = ((Define.SCREENSIZE_Y-1) - y) * Define.SCREENSIZE_X;
                mainTexture.SetPixel(x, y, displaybuffer[ ypos + x]);
            }

        mainTexture.Apply();
    }
}
