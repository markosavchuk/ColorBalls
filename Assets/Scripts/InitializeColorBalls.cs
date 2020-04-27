using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeColorBalls : MonoBehaviour
{
    public GameObject ColorBall;

    // Start is called before the first frame update
    void Start()
    {
        if (ColorBall == null)
        {
            return;
        }

        for (int i=0; i<100; i++)
        {
            var instance = Instantiate(ColorBall, new Vector3(Random.Range(-100, 100), 1f, Random.Range(-100, 100)), Quaternion.identity);
            instance.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}
