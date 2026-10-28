using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Playermove : MonoBehaviour
{
    public float speed = 5;

    public GameObject bullet;
    public int multiShot = 0;
    // Updated when player picks up powerup or takes damage
    public Image[] lives;
    public int lifeCount = 3;
    public TextMeshProUGUI scoreBox;
    //  Score indicator
    public TextMeshProUGUI bossScreen;
    //  Displayed when boss is killed
    public TextMeshProUGUI endScreen;
    //  Displays final score for player
    public TextMeshProUGUI reload;
    //  Prompts player to reset the game
    public TextMeshProUGUI youDied;
    //  Displayed when player is destroyed
    public static int scoreVal = 0;
    //  So from what I was reading, a public static variable is not great practice i guess?, but I wanted to get score only from 
    //  player bullets destroying enemies, and I figured storing the score on the player made more sense than making a separate 
    //  object to store them on, for the scope of this project.
    public static int bossDead = 0;
    //  Updated when boss dies and when scene is reset

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        if (multiShot == 0)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Instantiate(bullet, transform.position + new Vector3(0, .5f, 0), Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Instantiate(bullet, transform.position + new Vector3(0, .5f, 0), Quaternion.identity);
                Instantiate(bullet, transform.position + new Vector3(.5f, .5f, 0), Quaternion.identity);
                Instantiate(bullet, transform.position + new Vector3(-.5f, .5f, 0), Quaternion.identity);               
            }
            //  When the player gets a powerup, they gain an extra shot pattern in front of them.  
            //  It's still very easy to lose the multishot so it doesn't feel overpowered.


        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7, 7), Mathf.Clamp(transform.position.y, -4, 4), 0);
        scoreBox.text = "Score: " + scoreVal;
        //  Displays the player score in the scene

        if (bossDead >= 1)
        {
            
            Time.timeScale = 0;
            bossScreen.text = "Boss Defeated";
            endScreen.text = "Your Final Score is: " + scoreVal;
            reload.text = "Press Backspace to restart.";
            if (Input.GetKey(KeyCode.Backspace))
            {
                bossDead = 0;
                scoreVal = 0;
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            //  When boss is killed, game pauses and shows your final score.  Player can restart by pressing Backspace.
            
        }
        if (lifeCount <= 0)
        {
            Time.timeScale = 0;
            youDied.text = "YOU DIED";
            endScreen.text = "Your Final Score is: " + scoreVal;
            reload.text = "Press Backspace to restart.";

            if (Input.GetKey(KeyCode.Backspace))
            {
                bossDead = 0;
                scoreVal = 0;
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            //  Losing all lives shows death screen.  Player can reset game by pressing Backspace.
            
        }
   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            multiShot -= 1;
            if(multiShot <= 0)
            {
                multiShot = 0;
            }
            lifeCount -= 1;
            if (lifeCount <= 0)
            {
                lifeCount = 0;               
            }
            //  Running into an enemy will decrease life count and force you to lose your powerup
                
            lives[lifeCount].enabled = false;
        }
        if (collision.gameObject.CompareTag("Powerup"))
        {
            multiShot += 1;
                //  Pickup collision gives player multishot
        }
    }
}
