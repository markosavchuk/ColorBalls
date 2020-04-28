using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeBalls : MonoBehaviour
{
    public int numberOfBalls;
    public int range;

    public GameObject ColorBall;
    public GameObject MainBall;
    public Terrain Terrain;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize main ball
        var centerTerrainHeight = Terrain.terrainData.GetHeight((int)Terrain.terrainData.size.x / 2, (int)Terrain.terrainData.size.z / 2);
        var absoluteHeight = centerTerrainHeight + Terrain.transform.position.y;
        MainBall.transform.SetPositionAndRotation(new Vector3(0, absoluteHeight+10, 0), Quaternion.identity);

        // Initialize color balls
        if (ColorBall == null)
        {
            return;
        }

        for (int i=0; i<numberOfBalls; i++)
        {
            var instance = Instantiate(ColorBall, new Vector3(Random.Range(-range, range), 1f, Random.Range(-range, range)), Quaternion.identity);
            instance.GetComponent<Renderer>().material.color = ColorExtension.ChooseColor(true);
        }
    }
}
