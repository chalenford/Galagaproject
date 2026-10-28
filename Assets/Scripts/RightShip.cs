using UnityEngine;

public class RightShip : MonoBehaviour
{
    public float speed = 1;
    public GameObject bullet;
    public GameObject explosion;
    public int points = 150;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);

        if (transform.position.x <= 7)
        {
            Instantiate(bullet, transform.position - new Vector3(.5f, 0, 0), Quaternion.identity);
            speed *= -1;
        }
        if (transform.position.x > 12)
        {
            Destroy(gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet") || collision.gameObject.CompareTag("GalagaPlayer"))
        {
            if (collision.gameObject.CompareTag("PlayerBullet"))
                Playermove.scoreVal += points;
            //  Adds to the player score when destroyed by player bullet.

            GameObject temp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(temp, 1.0f);
            Destroy(gameObject);
        }
    }
}
