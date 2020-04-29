using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(50 * Time.deltaTime, 0, 0);
    }
}
