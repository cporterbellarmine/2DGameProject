using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debtCollector : MonoBehaviour
{
    private GameObject Player = GameObject.Find("Character");
    private Vector2 movement;
    public float speed;
    public float distance;
    public float outOfRange;
    public double damageModified;
    System.Random rnd = new System.Random();

    //triggers
    private bool rentCollected;
    private bool rentChase;

    // Start is called before the first frame update
    void Start()
    {
        rentCollected = false;
        rentChase = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rentChase == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, Player.transform.position) > outOfRange)
            {
                rentChase = false;

            }


        }

        if (Vector2.Distance(transform.position, Player.transform.position) < distance)
        {


            if (GameObject.Find("Renter").GetComponent<Renter>().lateDue > 0 && rentCollected == true)
            {
                rentChase = true;
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject Warrick = collision.gameObject;

        if (Warrick.gameObject.name == "Character")
        {
            Controller script = Warrick.GetComponent<Controller>();
            if (rentChase == true)
            {
                rentChase = false;
                script.hp -= rentDamage();
                rentCollected = true;

            }
        }
    }

    private int rentDamage()
    {
        int damage = (int)System.Math.Ceiling((double)GameObject.Find("Renter").GetComponent<Renter>().lateDue * (.5));

        return damage;
    }
}
