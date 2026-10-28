using UnityEngine;

public class Powerup : MonoBehaviour
{

    public float speed = 2;
    public float sidespeed = 5;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.up * speed * Time.deltaTime);
        transform.Translate(transform.right * sidespeed * Time.deltaTime);
        
        if (transform.position.x > 5)
        {
            sidespeed *= -1;

        }
        if (transform.position.x < -5)
        {
            sidespeed *= -1;
        }
      
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
            //  Powerup follows a zig zag pattern as it descends through the scene.
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GalagaPlayer"))
        {
            Destroy(gameObject);
        }
       
        //  Originally I had it so the powerup would be destroyed if you shot it but that felt lame so I ditched it.
    }
}

