using UnityEngine;


public class RightBullets : MonoBehaviour
{
    public float speed = 5;
    public int points = 25;
    //  Similar to the regular enemy bullets but these go left to right
    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);

        if (transform.position.x > 9)
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