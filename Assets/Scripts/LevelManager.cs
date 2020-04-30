using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int Level;
    public Color TargedColor;

    public Material TargetColorMaterial;
    public GameObject TargetObject;
    public Camera UICamera;

    void Start()
    {
        TargedColor = GenerateLevel(Level);
        TargetColorMaterial.color = TargedColor;
        TargetObject.transform.position = UICamera.ViewportToWorldPoint(new Vector3(LocationConstants.XRightMargin, LocationConstants.YTopMargin, -UICamera.transform.position.z));
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
