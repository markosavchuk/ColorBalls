using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static float _accuracy = 0.8f;
    private static int _level = 1;
    private Color _targedColor;

    public Material TargetColorMaterial;
    public GameObject TargetObject;
    public Text TextLevel;
    public Text StartTextLevel;
    public Camera UICamera;
    public GameObject StartLevelText;
    public GameObject FinishLevelText;

    private void Start()
    {
        StartLevelText.SetActive(true);
        TextLevel.gameObject.SetActive(false);

        _targedColor = GenerateLevel(_level);
        TargetColorMaterial.color = _targedColor;
        TargetObject.transform.position = UICamera.ViewportToWorldPoint(new Vector3(LocationConstants.XRightMargin, LocationConstants.YTopMargin, -UICamera.transform.position.z));

        TextLevel.text = $"Level {_level}";
        StartTextLevel.text = $"Level {_level}";

        FindObjectOfType<HintManager>().SetTargetAndAccurace(_targedColor, _accuracy);
    }

    public void PassLevel()
    {        
        _level++;
        _accuracy += (1 - _accuracy) / (_level + 2);

        FinishLevelText.SetActive(true);

        Invoke(nameof(LoadScene), 2f);          
    }

    public bool CheckIfPass(Color color)
    {
        var error = 1 - _accuracy;

        return color.r >= _targedColor.r - error && color.r <= _targedColor.r + error &&
            color.g >= _targedColor.g - error && color.g <= _targedColor.g + error &&
            color.b >= _targedColor.b - error && color.b <= _targedColor.b + error;
    }

    private Color GenerateLevel(int level)
    {
        Color targetColor = ColorExtension.ChooseColor(false);

        Debug.Log(targetColor);

        for (int i=1; i < level; i++)
        {
            var newColor = ColorExtension.ChooseColor(false);
            Debug.Log(newColor);

            targetColor = targetColor.MixColors(newColor, i);
        }

        Debug.Log("Target: "+targetColor);

        return targetColor;
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
