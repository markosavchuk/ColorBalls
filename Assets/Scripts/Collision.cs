using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals(TagConstacts.ColorElement))
        {
            var coliderRenderer = collision.collider.gameObject.GetComponent<Renderer>();
            var mainBallRederer = GetComponent<Renderer>();

            if (GetComponent<Renderer>().material.color.Equals(Color.white))
            {
                mainBallRederer.material.color = coliderRenderer.material.color;
            }
            else if (coliderRenderer.material.color != Color.black)
            {
                var mainBallColor = mainBallRederer.material.color;
                var colliderColor = coliderRenderer.material.color;                

                mainBallRederer.material.color = new Color(
                    (mainBallColor.r + colliderColor.r) / 2f,
                    (mainBallColor.g + colliderColor.g) / 2f,
                    (mainBallColor.b + colliderColor.b) / 2f);

                /*mainBallRederer.material.color = new Color(
                    Mathf.Min(mainBallColor.r + colliderColor.r, 1),
                    Mathf.Min(mainBallColor.g + colliderColor.g, 1),
                    Mathf.Min(mainBallColor.b + colliderColor.b, 1));*/
            }

            coliderRenderer.material.color = Color.black;
        }
    }
}
