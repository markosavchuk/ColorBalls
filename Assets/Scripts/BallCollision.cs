using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals(TagConstacts.ColorElement))
        {
            var coliderRenderer = collision.collider.gameObject.GetComponent<Renderer>();
            var mainBallRederer = GetComponent<Renderer>();

            var mainBallColor = mainBallRederer.material.color;
            var colliderColor = coliderRenderer.material.color;

            if (colliderColor.Equals(Color.black))
            {
                return;
            }
            else if (mainBallColor.Equals(Color.white) || colliderColor.Equals(Color.white))
            {
                mainBallRederer.material.color = coliderRenderer.material.color;
            }
            else if (coliderRenderer.material.color != Color.black)
            {
                mainBallRederer.material.color = mainBallColor.MixColors(colliderColor);
            }

            coliderRenderer.material.color = Color.black;

            //var LevelManager = FindObjectOfType<LevelManager>()?.TargedColor
            if (mainBallRederer.material.color.Equals(FindObjectOfType<LevelManager>()?.TargedColor))
            {
                Debug.Log("PASSED");
            }
        }
    }
}
