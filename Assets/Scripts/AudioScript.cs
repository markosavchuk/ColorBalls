using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public float MaxVolume = 0.2f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void FixedUpdate()
    {
        var audioSourse = gameObject.GetComponent<AudioSource>();

        if (audioSourse.volume < MaxVolume)
        {
            audioSourse.volume += 0.002f;
        }
    }
}
