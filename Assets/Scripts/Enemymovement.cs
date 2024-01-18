using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    private float enemyspeed = 500;
    private GameObject playerobject;
    private Rigidbody Enemyrb;
    private Vector3 playerdirection;
    private PlayerMovement playerscript;
    // Start is called before the first frame update
    void Start()
    {
        playerobject = GameObject.Find("Player");
        Enemyrb = GetComponent<Rigidbody>();
        playerscript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //to get enemy to move in player direction when gameover=false
        if (!playerscript.gameover)
        {
            playerdirection = (playerobject.transform.position - transform.position).normalized;
            Enemyrb.AddForce(playerdirection * enemyspeed * Time.deltaTime);
        }
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
