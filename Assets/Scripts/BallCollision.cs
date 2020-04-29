using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private const int ShowedColorsDistanse = 4;
    private const float PersantageForShowedColors = 0.4f;

    private int _numberOfShowedColorsOnHorizont;
    private int _numberOfCollidedColors = 0;
    private float _currentYOfShowedColors;

    public GameObject SelectedColorCube;
    public Camera UICamera;

    private void Start()
    {
        _currentYOfShowedColors = SelectedColorCube.transform.position.y;
    }

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

                if (mainBallRederer.material.color.Equals(Color.white))
                {
                    ResetShowedColors();
                }
                else
                {
                    _numberOfCollidedColors++;

                    ShowColorOnScreen(colliderColor);
                }

            }
            else if (coliderRenderer.material.color != Color.black)
            {
                _numberOfCollidedColors++;

                mainBallRederer.material.color = mainBallColor.MixColors(colliderColor, _numberOfCollidedColors);

                ShowColorOnScreen(colliderColor);
            }

            coliderRenderer.material.color = Color.black;

            if (mainBallRederer.material.color.Equals(FindObjectOfType<LevelManager>()?.TargedColor))
            {
                Debug.Log("PASSED");
            }
        }        
    }

    private void ResetShowedColors()
    {
        _numberOfShowedColorsOnHorizont = 0;
        _numberOfCollidedColors = 0;

        var exisitingObjedts = GameObject.FindGameObjectsWithTag(TagConstacts.SelectedColorElement);
        foreach (var obj in exisitingObjedts)
        {
            Destroy(obj);
        }
    }

    private void ShowColorOnScreen(Color colliderColor)
    {
        var instance = Instantiate(SelectedColorCube);
        instance.GetComponent<Renderer>().material.color = colliderColor;

        var position = instance.GetComponent<Transform>().position;
        var newPosition  = new Vector3(
            position.x + (_numberOfShowedColorsOnHorizont * ShowedColorsDistanse),
            _currentYOfShowedColors,
            position.z);

        var viewportPoint =  UICamera.WorldToViewportPoint(newPosition);
        if (viewportPoint.x>=0 && viewportPoint.x <= PersantageForShowedColors)
        {
            instance.GetComponent<Transform>().position = newPosition;
        }
        else
        {
            _currentYOfShowedColors -= ShowedColorsDistanse;
            _numberOfShowedColorsOnHorizont = 0;

            newPosition = new Vector3(
                position.x + (_numberOfShowedColorsOnHorizont * ShowedColorsDistanse),
                _currentYOfShowedColors,
                position.z);
            instance.GetComponent<Transform>().position = newPosition;
        }
       
        var exisingObjects = GameObject.FindGameObjectWithTag(TagConstacts.SelectedColorElement);
        if (exisingObjects != null)
        {
            instance.GetComponent<Transform>().rotation = exisingObjects.GetComponent<Transform>().rotation;
        }

        _numberOfShowedColorsOnHorizont++;
       
        //todo consider overflow the whole screen
    }
}
