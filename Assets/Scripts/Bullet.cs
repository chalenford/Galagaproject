using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
 


    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);

        if (transform.position.y > 6)
        {
            Destroy(gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}

        