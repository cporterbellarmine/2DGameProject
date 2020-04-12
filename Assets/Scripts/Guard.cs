/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    private GameObject Player = GameObject.Find("Character");
    private Vector2 movement;
    public float speed;
    public float distance;
    public float outOfRange;
    public double damageModified;
    System.Random rnd = new System.Random();
    
    //triggers
    private bool checkPlayer;
    private int criminalRating;

    public bool gracePeriod = false;
    private bool taxCollected;
    private bool failedSteal;
    private bool taxChase;
    private bool criminalChase;
    private bool curfew;
        


    // Start is called before the first frame update
    void Start()
    {
        curfew = false;
        checkPlayer = false;
        taxCollected = false;
        failedSteal = false;
        taxChase = false;
        criminalChase = false;
    }

    // Update is called once per frame
    void Update()           
    {
        criminalRating = Player.GetComponent<Controller>().criminalRating;
        if (taxChase == true || criminalChase == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, Player.transform.position) > outOfRange)
            {
                taxChase = false;
                criminalChase = false;
                checkPlayer = false;
            }
            
     
        }
        
        
        if (Vector2.Distance(transform.position, Player.transform.position) < distance && checkPlayer == false)
        {
            checkPlayer = true;

            if (GameObject.Find("TaxCollector").GetComponent<TaxCollector>().lateDue > 0 && taxCollected == false && gracePeriod == false)
            {
                taxChase = true;
            }
            else if (((criminalRating > 0 && (rnd.Next(1, 100) <= criminalRating)) || curfew == true || failedSteal == true) && taxChase == false)
            {
                criminalChase = true;
            }
        }

        curfew = GameObject.Find("Clock").AddComponent<TimeTracker>().curfew;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject Warrick = collision.gameObject;
        
        if (Warrick.gameObject.name == "Character")
        {
            Controller script = Warrick.GetComponent<Controller>();
            if (taxChase == true)
            {
                taxChase = false;

                script.gold -= fine(script);
<<<<<<< HEAD
                script.hp -= taxDamage();
                taxCollected = true;
=======
                script.TakeDamage(taxDamage());

>>>>>>> 2664bad00e965e54770d6df3ea53e42f2cdee866

            }
            else if(criminalChase == true)
            {
                criminalChase = false;

<<<<<<< HEAD
                if(curfew == true)
                {
                    script.hp -= 10;
                }
                else{
                    script.hp -= crimeDamage(script);
                    script.inventory.clearStolenGoods();
                    GameObject.Find("TaxCollector").GetComponent<TaxCollector>().criminalRating = 0;
                }
                
=======
                script.TakeDamage(crimeDamage(script));
                script.inventory.clearStolenGoods();
                GameObject.Find("TaxCollector").GetComponent<TaxCollector>().criminalRating -= 20;
>>>>>>> 2664bad00e965e54770d6df3ea53e42f2cdee866



            }
            
        }


            
    }

    private int taxDamage()
    {
        int damage = (int)System.Math.Ceiling((double)GameObject.Find("TaxCollector").GetComponent<TaxCollector>().lateDue * (.5+damageModified));
        
        return damage;
    }

    private void damageModifier(double d)
    {
        damageModified = d;
        
    }

    private int fine(Controller script)
    {
        int fine = GameObject.Find("TaxCollector").GetComponent<TaxCollector>().lateDue;
        double denominator = (double)fine;
        double numerator = 0;
        if(fine > script.gold)
        {
            GameObject.Find("TaxCollector").GetComponent<TaxCollector>().lateDue -= script.gold;
            numerator = (double)GameObject.Find("TaxCollector").GetComponent<TaxCollector>().lateDue;
            fine = script.gold;
           
            damageModifier(numerator / denominator);
        }
        else if(fine<= script.gold)
        {
            
            GameObject.Find("TaxCollector").GetComponent<TaxCollector>().lateDue =0;
            
        }

        
        return fine;
    }

    private int crimeDamage(Controller script)
    {
        int damage = (int)System.Math.Ceiling((double)script.stolenGoodsValue() * .5);

        return damage;
    }
    
}
*/