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
    private bool taxOwed;
    bool gracePeriod;
    private bool taxCollected;
    private bool failedSteal;
    private bool taxChase;
    private bool criminalChase;
    private bool curfew;
        


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        criminalRating = GameObject.Find("TaxCollector").GetComponent<TaxCollector>().criminalRating;
        if (taxChase == true || criminalChase == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, Player.transform.position) > outOfRange)
            {
                taxChase = false;
                criminalChase = false;
            }
            
     
        }
        
        if (Vector2.Distance(transform.position, Player.transform.position) < distance && checkPlayer == false)
        {
            checkPlayer = true;
            if (taxOwed == true && taxCollected == true && gracePeriod == false)
            {
                taxChase = true;
            }
            else if (((criminalRating > 0 && (rnd.Next(1, 100) <= criminalRating)) || curfew == true || failedSteal == true) && taxChase == false)
            {
                criminalChase = true;
            }
        }
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
                script.TakeDamage(taxDamage());


            }
            else if(criminalChase == true)
            {
                criminalChase = false;

                script.TakeDamage(crimeDamage(script));
                script.inventory.clearStolenGoods();
                GameObject.Find("TaxCollector").GetComponent<TaxCollector>().criminalRating -= 20;



            }
            checkPlayer = true;
        }


            
    }

    private int taxDamage()
    {
        int damage = (int)System.Math.Ceiling((double)GameObject.Find("TaxCollector").GetComponent<TaxCollector>().fine * (.5+damageModified));
        
        return damage;
    }

    private void damageModifier(double d)
    {
        damageModified = d;
        
    }

    private int fine(Controller script)
    {
        int fine = GameObject.Find("TaxCollector").GetComponent<TaxCollector>().fine;
        double denominator = (double)fine;
        double numerator = 0;
        if(fine > script.gold)
        {
            GameObject.Find("TaxCollector").GetComponent<TaxCollector>().fine -= script.gold;
            numerator = (double)GameObject.Find("TaxCollector").GetComponent<TaxCollector>().fine;
            fine = script.gold;
           
            damageModifier(numerator / denominator);
        }
        else if(fine<= script.gold)
        {
            
            GameObject.Find("TaxCollector").GetComponent<TaxCollector>().fine =0;
            
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