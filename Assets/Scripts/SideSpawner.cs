using UnityEngine;

public class SideSpawner : MonoBehaviour
{
    public GameObject leftWave;
    public GameObject rightWave;
    public float leftTimer = 0, leftWait = 10;
    public float rightTimer = 0, rightWait = 15;
    // Update is called once per frame
    //  Sets up the spawn timers for the left and righthand waves.
    //  Uses the same logic as the WaveSpawner.
    //  I started setting this up before I decided to put the boss and powerup on the wavespawner file.
    //  Really no reason for it to be separate I guess, but it's working so I left it alone.
    void Update()
    {
        leftTimer += Time.deltaTime;
        rightTimer += Time.deltaTime;

        if (leftTimer > leftWait)
        {
            leftTimer = 0;
            Instantiate(leftWave, transform.position, Quaternion.identity);
        }
        if (rightTimer > rightWait)
        {
            rightTimer = 0;
            Instantiate(rightWave, transform.position, Quaternion.identity);
        }
    }
}
