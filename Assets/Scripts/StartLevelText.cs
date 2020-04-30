using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLevelText : MonoBehaviour
{
    public Text TextLevel;

    public void OnFinishedStartLevel()
    {
        gameObject.SetActive(false);
        TextLevel.gameObject.SetActive(true);
    }
}
