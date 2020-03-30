using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapToAndFro : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private float waitTime;
    public float startWaitTime;
    public Transform[] moveSpots = new Transform[3];
    private int randomSpot;
    private int lastSpot;
    private Vector2 movement;
    private Animator animator;
    private float deltaX;
    private float deltaY;
    float count = 0.0f;
    private float ground = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        waitTime = startWaitTime;
        randomSpot = 0;
        lastSpot = 3;
        animator.SetFloat("Speed", speed);
        animator.SetFloat("Direction", -1);
        


    }

    // Update is called once per frame
    void Update()
    {
        if (ground == 0)
        {
     

            if (count < 1.0f)
            {
                if (count < .5f)
                {
                    animator.SetFloat("Up", 1);

                }
                else if (count >= .5f)
                {
                    animator.SetFloat("Up", 0);

                }
                count += 1.0f * Time.deltaTime;

                Vector3 m1 = Vector3.Lerp(moveSpots[0].position, moveSpots[1].position, count);
                Vector3 m2 = Vector3.Lerp(moveSpots[1].position, moveSpots[2].position, count);
                transform.position = Vector3.Lerp(m1, m2, count);
                if (count >= 1.0f)
                {
                    ground = 1;
                    animator.SetFloat("Speed", 0);
                    count = 0;
                }
            }
        }
        else if (ground == 1)
        {
           
            if (Vector3.Distance(transform.position, moveSpots[2].position) < 0.2f)
            {
                if(transform.position.x < moveSpots[1].position.x)
                {
                    animator.SetFloat("Direction", -1);
                }
                else if(transform.position.x > moveSpots[1].position.x)
                {
                    animator.SetFloat("Direction", 1);
                }
                if (waitTime <= 0)
                {
                    Transform[] temp = new Transform[1];
                    temp[0] = moveSpots[0];
                    moveSpots[0] = moveSpots[2];
                    moveSpots[2] = temp[0];

                    waitTime = startWaitTime;
                    ground = 0;
                    animator.SetFloat("Speed", speed);
                    if (transform.position.x < moveSpots[1].position.x)
                    {
                        animator.SetFloat("Direction", 1);
                    }
                    else if (transform.position.x > moveSpots[1].position.x)
                    {
                        animator.SetFloat("Direction", -1);
                    }
                }
                else
                {
                    waitTime -= Time.deltaTime;
                    animator.SetFloat("Speed", 0);

                }
            }
        }
        


        
       /* movement = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        transform.position = movement;

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                lastSpot = randomSpot;
                randomSpot += 1;
                if (randomSpot == 4)
                {
                    randomSpot = 0;
                }
                waitTime = startWaitTime;
                animator.SetFloat("Speed", speed);


            }
            else
            {
                waitTime -= Time.deltaTime;
                animator.SetFloat("Speed", 0);

            }
        }

        deltaX = moveSpots[randomSpot].position.x - moveSpots[lastSpot].position.x;
        deltaY = moveSpots[randomSpot].position.y - moveSpots[lastSpot].position.y;

        if (deltaX > 0 && deltaY == 0)
        {
            animator.SetFloat("IdleHorizontal", 1);
            animator.SetFloat("IdleVertical", 0);
            animator.SetFloat("Horizontal", 1);
            animator.SetFloat("Vertical", 0);
        }
        else if (deltaX < 0 && deltaY == 0)
        {

            animator.SetFloat("IdleHorizontal", -1);
            animator.SetFloat("IdleVertical", 0);
            animator.SetFloat("Horizontal", -1);
            animator.SetFloat("Vertical", 0);
        }
        else if (deltaX == 0 && deltaY > 0)
        {
            animator.SetFloat("IdleHorizontal", 0);
            animator.SetFloat("IdleVertical", 1);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 1);
        }
        else if (deltaX == 0 && deltaY < 0)
        {
            animator.SetFloat("IdleHorizontal", 0);
            animator.SetFloat("IdleVertical", -1);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", -1);
        }
        else if (deltaX == 0 && deltaY == 0)
        {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
        }*/
    }
}
