using TMPro;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed = 2;
    public float hoverspeed = 3;
    //  Lateral speed
    public GameObject bullet; 
    //  Downward bullet volleys
    public GameObject[] sideShots;
    //  Bullets that shoot diagonally from the boss
    public GameObject explosion;
    public float health = 4000;
    public int points = 5000;
    
        

    public float bulletTimer = 0, bulletWait = 2;
    public float sideTimer = 0, sideWait = 2;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.up * speed * Time.deltaTime);
        bulletTimer += Time.deltaTime;
        sideTimer += Time.deltaTime;

        if (transform.position.y <= 3.5)
        {
            
            speed = 0;
            transform.Translate(transform.right * hoverspeed * Time.deltaTime);
            if (transform.position.x > 4.5)
            {
                hoverspeed *= -1;
            }
            if (transform.position.x < -4.5)
            {
                hoverspeed *= -1;
            }
            if (sideTimer > sideWait)
            {
                sideTimer = 0;
                Instantiate(sideShots[Random.Range(0, sideShots.Length)], transform.position - new Vector3(0, -1f, 0), Quaternion.identity);
            }
            if (bulletTimer > bulletWait)
            {
                bulletTimer = 0;
                Instantiate(bullet, transform.position - new Vector3(0, .5f, 0), Quaternion.identity);
                Instantiate(bullet, transform.position - new Vector3(-1f, .5f, 0), Quaternion.identity);
                Instantiate(bullet, transform.position - new Vector3(1f, .5f, 0), Quaternion.identity);
                Instantiate(bullet, transform.position - new Vector3(-2f, .5f, 0), Quaternion.identity);
                Instantiate(bullet, transform.position - new Vector3(2f, .5f, 0), Quaternion.identity);
            }
        }
        //     Boss enters from top and paths left and right firing volleys that the player can dodge.
        //     Originally I had the side bullets on 0 wait and it made a continuous beam, but honestly
        //     I liked it so I left it in for a bit.  I removed it because it looked pretty ridiculous.
        //     I used the same logic as the wavespawner to randomize the side bullets for some flair and randomness.
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            health -= 50;
            if (health <= 0)
            {               
                Playermove.scoreVal += points;
                Playermove.bossDead = 1;
                Destroy(collision.gameObject);             

                GameObject temp = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(temp, 1.0f);
                Destroy(gameObject);
                
            }
        }
        //  Gives boss a health pool that can be decreased by shooting it 
        //  On boss death, adds to player score and triggers score screen for player.
    }
}
