using UnityEngine;
using System.Collections;

public class ChaseWaypoint : MonoBehaviour {

    public Transform player;
    public Transform head;
    Animator anim;
    public float aggroRange = 10.0f;
    public float attackRange = 3.0f;
    public float FOVAngle = 40.0f;
    string state = "patrol";
    public GameObject[] waypoints;
    int currentWP = 0;
    public float rotSpeed = 0.2f;
    public float speed = 1.5f;
    public float accuracyWP = 5.0f;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckAction();
	}

    void CheckAction()
    {
        Vector3 direction = player.position - this.transform.position;
        direction.y = 0;
        float angle = Vector3.Angle(direction, head.up);
        float distance = Vector3.Distance(player.position, this.transform.position);
        if (state == "patrol" && waypoints.Length > 0)
        {
            anim.SetBool("isWalking", true);

            if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
            {
                currentWP++;
                if (currentWP >= waypoints.Length)
                    currentWP = 0;
            }

            direction = waypoints[currentWP].transform.position - transform.position;
            this.transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
            this.transform.Translate(0, 0, Time.deltaTime * speed);
        }

        if (distance < aggroRange && (angle < FOVAngle || state == "pursuing"))
                // || distance < attackRange + 0.5f
        {
            state = "pursuing";
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

            if (direction.magnitude > attackRange)
            {
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
        }
        else
            GoIdle();
    }

    void WalkToPlayer(Vector3 direction)
    {

    }

    void GoIdle()
    {
        anim.SetBool("isWalking", true);
        anim.SetBool("isAttacking", false);
        state = "patrol";
    }
}
