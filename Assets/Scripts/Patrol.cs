﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private float waitTime;
    public float startWaitTime;
    public Transform[] moveSpots;
    private int randomSpot;
    private int lastSpot;
    private Vector2 movement;
    private Animator animator;
    private float deltaX;
    private float deltaY;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        waitTime = startWaitTime;
        randomSpot = 0;
        lastSpot = 3;
        animator.SetFloat("Speed", speed);
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        GameObject.Find("NPC").GetComponent<Animation>().movement = movement;
        transform.position = movement;

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                lastSpot = randomSpot;
                randomSpot += 1;
                if(randomSpot == 4)
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
/*
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
        }
        */
        
    }
}
