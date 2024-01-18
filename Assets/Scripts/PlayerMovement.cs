using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float speed=500;
    private float powerupforce=1000;
    private float verticalinput;
    private GameObject focalpoint;
    public GameObject indicator;
    public bool gameover=false;
    private Rigidbody playerrb;
    private bool haspowerup=false;
    public TextMeshProUGUI Gameovertext;
    public Button Restart;
    // Start is called before the first frame update
    void Start()
    {
        focalpoint=GameObject.Find("Focalpoint");
        playerrb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //to move player in forward direction of camera
        verticalinput=Input.GetAxis("Vertical");
        playerrb.AddForce(focalpoint.transform.forward*speed*verticalinput*Time.deltaTime);
        //to move powerup indicator with player
        indicator.transform.position=transform.position + new Vector3(0,1,0);
        if(transform.position.y<-1){
            Debug.Log("GameOver");
            gameover=true;
            Destroy(gameObject);
        }
        //text and button will show when game is over
        Gameovertext.gameObject.SetActive(gameover);
        Restart.gameObject.SetActive(gameover);
    }
    //to add haspowerup to true to player and destroy powerup
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("PowerUp")){
            haspowerup=true;
            Destroy(other.gameObject);
            indicator.SetActive(true);
            StartCoroutine(Poweruptime());
        }
    }
    // to add force when haspowerup is true
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy")&&haspowerup){
            Vector3 enemydirection=(collision.transform.position-transform.position);
            Rigidbody enemyrb=collision.gameObject.GetComponent<Rigidbody>();
            enemyrb.AddForce(enemydirection*powerupforce*Time.deltaTime,ForceMode.Impulse);
        }
    }
    //to restart the game
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // set time duration for powerup
    IEnumerator Poweruptime(){
        yield return new WaitForSeconds(10);
        haspowerup=false;
        indicator.SetActive(false);
    }
}
