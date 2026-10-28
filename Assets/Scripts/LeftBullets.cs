using UnityEngine;


public class LeftBullets : MonoBehaviour
   {
    public float speed = 5;
    public int points = 25;

    // Update is called once per frame
    //  Similar to regular enemy bullets but these go right to left
    void Update()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);

        if (transform.position.x < -9)
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
    }
}
