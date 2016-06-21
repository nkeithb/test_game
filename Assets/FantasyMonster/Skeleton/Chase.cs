using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour {

    public Transform player;
    public Transform head;
    Animator anim;
    public float aggroRange = 10.0f;
    public float attackRange = 3.0f;
    public float FOVAngle = 40.0f;
    bool pursuing = false;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
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
        if ((distance < aggroRange && angle < FOVAngle) || pursuing)
        // || distance < attackRange + 0.5f
        { 
            pursuing = true;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.1f);
            anim.SetBool("isIdle", false);
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
            if (direction.magnitude > aggroRange)
                pursuing = false;
        }
        else
            GoIdle();
    }

    void WalkToPlayer(Vector3 direction)
    {

    }

    void GoIdle()
    {
        anim.SetBool("isIdle", true);
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", false);
        pursuing = false;
    }
}
