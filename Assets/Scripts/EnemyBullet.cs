using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 6;
    public int points = 25;
    //  Added point value 


    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.up * speed * Time.deltaTime);

        if (transform.position.y < -6)
        {
            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GalagaPlayer"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Playermove.scoreVal += points;
            Destroy(gameObject);
        }
        //  Added collision with player bullets so you can shoot them to destroy them.
        //  Shooting enemy bullets adds to score
    }   
}