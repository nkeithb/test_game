using UnityEngine;
using System.Collections;

public class AntiPlayerSpawner : MonoBehaviour {
    //Attach to empty GameObject and place at desired spawn point.
    // Future: Add multiple spawn points and a random selection of spawn point

    [Tooltip("Number of AntiPlayers that will cause the spawner to cease spawning activities")]
    public int maximumAntiPlayers = 5;
    [Tooltip("Time between start and first enemy spawn")]
    public float spawnDelay = 3.0f;
    [Tooltip("Time between enemy spawns (Set greater than zero to avoid collisions)")]
    public float spawnRate = 3.0f;
    [Tooltip("AntiPlayer prefab to spawn")]
    public GameObject antiPlayer;

    private int antiPlayerNumber;
    private bool spawned = true;

	// Use this for initialization
	void Start ()
    {
        Invoke("ResetSpawnTimer", spawnDelay);
	}
	
	// Update is called once per frame
	void Update ()
    {
        FindAntiPlayers();
        SpawnIfDeficient();
	}

    private void FindAntiPlayers()
    {
        antiPlayerNumber = GameObject.FindGameObjectsWithTag("AntiPlayer").Length;
    }

    private void SpawnIfDeficient()
    {
        if (antiPlayerNumber < maximumAntiPlayers && spawned == false)
        {
            spawned = true;
            GameObject obj = Instantiate(antiPlayer, transform.position, transform.rotation) as GameObject;

            //
            //obj.GetComponent<Collider>().enabled = false;
            //obj.GetComponent<Collider>().enabled = true;
            //

            Invoke("ResetSpawnTimer", spawnRate);
        }
    }

    private void ResetSpawnTimer()
    {
        if (spawned == true)
            spawned = false;
    }




    /*
    public PlayerHealth playerHealth;       // Reference to the player's heatlh.
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


    // Find a random index between zero and one less than the number of spawn points.
    int spawnPointIndex = Random.Range(0, spawnPoints.Length);

    // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
    Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    */
}
