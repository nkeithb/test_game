using UnityEngine;
using System.Collections;

public class ShootProjectile : MonoBehaviour {

    public Transform projectile;
    public float bulletSpeed = 200.0f;
    public float shotDelay = 0.5f;
    public float bulletDecay = 20.0f;

    private bool shotDelayed = false;


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Fire1"))
        {
            CheckShot();
        }
    }

    void CheckShot()
    {
        if (!shotDelayed)
        {
            shotDelayed = true;
            // Instantiate the projectile at the position and rotation of this transform
            Transform clone;
            clone = Instantiate(projectile, transform.position, transform.rotation) as Transform;
            Collider cloneCollider = clone.GetComponent<Collider>();
            Collider myCollider = GetComponent<Collider>();
            // Add force to the cloned object in the object's forward direction
            Physics.IgnoreCollision(myCollider, cloneCollider);
            clone.GetComponent<Rigidbody>().AddForce(clone.transform.forward * bulletSpeed, ForceMode.Impulse);
            Destroy(clone.transform.gameObject, bulletDecay);
            Invoke("ResetShotDelay", shotDelay);
        }
    }

    void ResetShotDelay()
    {
        shotDelayed = false;
    }
}
