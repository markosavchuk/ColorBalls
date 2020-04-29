using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int Level;
    public Color TargedColor;

    void Start()
    {
        TargedColor = GenerateLevel(Level);
        Debug.Log("Targer color: "+TargedColor.ToString());
    }

    private Color GenerateLevel(int level)
    {
        Color targetColor = ColorExtension.ChooseColor(false);

        for (int i=1; i < level; i++)
        {
            targetColor = targetColor.MixColors(ColorExtension.ChooseColor(false), i);
        }

        return targetColor;
    }
}
