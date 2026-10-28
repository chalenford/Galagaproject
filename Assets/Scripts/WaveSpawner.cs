
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemyWaves;
    public GameObject bossWave;
    public GameObject powerupSpawn;
      

    public float waveTimer = 0, waveWait = 3;
    public float bossTimer = 0, bossWait = 60;
    public float powerupTimer = 0, powerupWait = 10;
   //   Extended the methods for the wave spawning to add a spawn for a boss enemy and a powerup.

    // Update is called once per frame
    void Update()
    {
        waveTimer += Time.deltaTime;
        bossTimer += Time.deltaTime;
        powerupTimer += Time.deltaTime;
       

        if (waveTimer > waveWait)
        {
            waveTimer = 0;
            Instantiate(enemyWaves[Random.Range(0, enemyWaves.Length)], transform.position, Quaternion.identity);
            //integers are exclusive
            //floats are inclusive
            //float array goes to max -1
        }
     
        if (bossTimer > bossWait)
        {
            bossTimer = 0;
            waveWait = 10;
            Instantiate(bossWave, transform.position, Quaternion.identity);
            //  Extended out the wave spawning when the boss spawns so the enemies aren't cluttering the screen so much.
        }

        if (powerupTimer > powerupWait)
        {
            powerupTimer = 0;
            Instantiate(powerupSpawn, transform.position, Quaternion.identity);
        }

    }

}
