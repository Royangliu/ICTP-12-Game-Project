using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField] public Transform[] Points;
    private float moveSpeed = 1f;
    private int pointIndex = 0;
    private Animator animator;

    public bool isWalking = false;
    public bool isWalkingBack = false;

    public bool isSittingFacingLeft;

    private void Awake()
    {
        transform.position = Points[pointIndex].transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            Move();
        }
    }

    private void Move()
    {
        // walks to waypoins in decending order
        if (isWalkingBack)
        {
            if (pointIndex == 4)
            {
                animator.SetBool("isFacingLeft", false);
                animator.SetBool("isFacingRight", false);
            }
            Vector3 nextVector = Vector3.MoveTowards(transform.position, Points[pointIndex - 1].transform.position, moveSpeed * Time.deltaTime);
            animator.SetBool("isWalking", true);

            Vector3 calculating = nextVector - transform.position;

            animator.SetFloat("Xinput", calculating.x);
            animator.SetFloat("Yinput", calculating.y);

            transform.position = nextVector;
            if (transform.position == Points[pointIndex - 1].transform.position)
            {
                pointIndex -= 1;
                animator.SetBool("isWalking", false);
            }
            if (pointIndex == 0)
            {
                isWalkingBack = false;
                isWalking = false;
            }
        }

        // walks to waypoints in acending order
        else if (pointIndex < Points.Length)
        {
            Vector3 nextVector = Vector3.MoveTowards(transform.position, Points[pointIndex].transform.position, moveSpeed * Time.deltaTime);
            animator.SetBool("isWalking", true);

            Vector3 calculating = nextVector - transform.position;

            animator.SetFloat("Xinput", calculating.x);
            animator.SetFloat("Yinput", calculating.y);

            transform.position = nextVector;
            if (transform.position == Points[pointIndex].transform.position)
            {
                pointIndex += 1;
                animator.SetBool("isWalking", false);
            }
            if (pointIndex == Points.Length)
            {
                isWalking = false;
                switch (isSittingFacingLeft)
                {
                    case true:
                        animator.SetBool("isFacingLeft", true);
                        break;
                    case false:
                        animator.SetBool("isFacingRight", true);
                        break;
                }
            }
        }
    }
}
