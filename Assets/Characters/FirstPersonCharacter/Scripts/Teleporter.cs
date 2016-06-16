using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    /* - Will teleport to destination object on collision with player
       - teleportDelay > 0 required to prevent looping
       - Replace PlayerController.instance.recentlyTeleported with
         location of your own recentlyTeleported bool. */

    public GameObject destination;
    public bool soundEnabled = true;
    public float teleportDelay = 0.1f;

    private Transform playerTransform;
    private Transform spawnPoint;
    private Rigidbody rigidBody;
    private bool recentlyTeleported = false;

    // Use this for initialization
	void Start ()
    {
        recentlyTeleported = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        // Here, 'Teleporter1' will hold tag 'Teleporter2' and vice versa, creating the teleport effect. 
        // Can be used multiple times, however the tag of the teleporter MUST match the name of the 
        // target teleporter.
        if (other.name.Contains("Player") && recentlyTeleported == false)
        {
            PlayTeleporterSound();
            AddTeleportDelay();
            Teleport(destination.name);
        }
    }

    private void PlayTeleporterSound()
    {
        //if (soundEnabled == true)
            //SoundManager.instance.RandomizeSfx(PlayerController.instance.teleportSounds);
    }

    private void SetRecentlyTeleported()
    {
        recentlyTeleported = false;
    }

    private void AddTeleportDelay()
    {
        recentlyTeleported = true;
        Invoke("SetRecentlyTeleported", teleportDelay);
    }

    private void Teleport(string spawnTag)
    {
        SetTransformValues(spawnTag);
        playerTransform.position = spawnPoint.position;
        rigidBody.velocity = new Vector3(0, 0, 0);
        rigidBody.ResetInertiaTensor();
    }

    private void SetTransformValues(string spawnTag)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        spawnPoint = GameObject.Find(spawnTag).transform;
        rigidBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
}
