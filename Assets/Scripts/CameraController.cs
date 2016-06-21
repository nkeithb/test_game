using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    [Tooltip("Set camera offset")]
    public Vector3 offset;

    private GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
