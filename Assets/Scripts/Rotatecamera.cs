using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatecamera : MonoBehaviour
{
    private float horizontalinput;
    private float rotatespeed = 100;
    private GameObject playerobject;
    private PlayerMovement playerscript;
    // Start is called before the first frame update
    void Start()
    {
        playerobject = GameObject.Find("Player");
        playerscript = playerobject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //to rotate camera
        horizontalinput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotatespeed * horizontalinput * Time.deltaTime);
        //to follow player when gameover=false
        if (!playerscript.gameover)
        {
            transform.position = playerobject.transform.position;
        }
    }
}
