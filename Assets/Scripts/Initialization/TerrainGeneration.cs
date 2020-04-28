using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    private float _offsetX = 100f;
    private float _offsetY = 100f;

    public Terrain terrain;

    public int width = 256;
    public int height = 256;
    public int depth = 20;

    public float scale = 20f;
   
    private void Start()
    {
        _offsetX = Random.Range(0, 9999);
        _offsetY = Random.Range(0, 9999);

        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    private TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());

        return terrainData;
    }

    private float[,] GenerateHeights()
    {
        var heights = new float[width, height];

        for (int x=0; x < width; x++)
        {
            for (int y=0; y<height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    private float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale + _offsetX;
        float yCoord = (float)y / height * scale + _offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
