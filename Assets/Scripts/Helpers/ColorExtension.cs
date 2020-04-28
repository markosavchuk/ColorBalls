using UnityEngine;

public static class ColorExtension
{
    public static Color ChooseColor(bool includeWhite)
    {
        var randomColor = includeWhite ? Random.Range(0, 4) : Random.Range(0, 4);
        switch (randomColor)
        {
            case 0:
                return Color.red;
            case 1:
                return Color.green;
            case 2:
                return Color.blue;
            default:
                return Color.white;
        }
    }

    public static Color MixColors(this Color color1, Color color2)
    {
        return new Color(
            (color1.r + color2.r) / 2f,
            (color1.g + color2.g) / 2f,
            (color1.b + color2.b) / 2f);
    }
}
