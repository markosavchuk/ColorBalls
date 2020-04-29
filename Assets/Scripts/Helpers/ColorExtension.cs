using UnityEngine;

public static class ColorExtension
{
    public static Color ChooseColor(bool includeWhite)
    {
        Color color = Color.black;


        while (color == Color.black || (color == Color.white && !includeWhite))
        {
            color = new Color(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
        }

        return color;
    }

    public static Color MixColors(this Color color1, Color color2, int k)
    {
        return new Color(
            (k * color1.r + color2.r) / (k + 1),
            (k * color1.g + color2.g) / (k + 1),
            (k * color1.b + color2.b) / (k + 1));
    }
}
