using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManage : MonoBehaviour
{
    private float xpos,ypos,zpos;
    public GameObject enemyobject;
    public GameObject powerupobject;
    private int wave=1;
    private int enemycount;
    private PlayerMovement playerscript;
    public TextMeshProUGUI Gameovertext;
    public Button Restart;
    // Start is called before the first frame update
    void Start()
    {
        playerscript=GameObject.Find("Player").GetComponent<PlayerMovement>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //to check no. of enemies
        enemycount=FindObjectsOfType<Enemymovement>().Length;
        //to spawn enemy when no. of enemy is 0 & gameover=false
        if(enemycount==0&&!playerscript.gameover){
            int Spawnenemy=wave++;
            Instantiate(powerupobject,getposition(),powerupobject.transform.rotation);
            for(int i=0;i<Spawnenemy;i++){
                Instantiate(enemyobject,getposition(),enemyobject.transform.rotation);
            }
        }
        //text and button will show when game is over
        Gameovertext.gameObject.SetActive(playerscript.gameover);
        Restart.gameObject.SetActive(playerscript.gameover);
    }
    //get random position
    Vector3 getposition(){
        xpos=Random.Range(-10,10);
        ypos=0;
        zpos=Random.Range(-10,10);
        Vector3 pos=new Vector3(xpos,ypos,zpos);
        return pos;
    }
    //to restart the game
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
