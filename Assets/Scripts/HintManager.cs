using System;
using UnityEngine;
using UnityEngine.UI;

public class HintManager : MonoBehaviour
{
    private const string FloatFormat = "0.##";

    private string _target = string.Empty;
    private string _accuracy = string.Empty;
    private string _current = string.Empty;

    public Text HintText;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            HintText.gameObject.SetActive(!HintText.gameObject.activeSelf);
        }
    }

    public void SetTargetAndAccurace(Color target, float accuracy)
    {
        _target = $"Targed: R:{target.r.ToString(FloatFormat)} G:{target.g.ToString(FloatFormat)} B:{target.b.ToString(FloatFormat)}";
        _accuracy = $"Accuracy: {accuracy*100}%";

        UpdateHint();
    }

    public void SetCurrentColor(Color current)
    {
        _current = $"Current: R:{current.r.ToString(FloatFormat)} G:{current.g.ToString(FloatFormat)}, B:{current.b.ToString(FloatFormat)}";

        UpdateHint();
    }

    private void UpdateHint()
    {
        HintText.text = $"{_current}{Environment.NewLine}{_target}{Environment.NewLine}{_accuracy}";
    }
}
