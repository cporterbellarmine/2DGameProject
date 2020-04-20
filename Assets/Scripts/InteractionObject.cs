using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    bool stolenFrom = false;
    public Canvas messageCanvas;
    public GameObject prefab;
    bool buttonPressed = false;
    public Fade fade;
    MoneyScript moneyScript;

    private void Start()
    {
        messageCanvas.enabled = false;
        fade = GameObject.Find("FadeCanvas").GetComponent<Fade>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact"))
            buttonPressed = true;
        else
            buttonPressed = false;

        moneyScript = GameObject.Find("MoneyBorder").GetComponent<MoneyScript>();
      
    }

    public void DoSellInteraction(string[] item)
    {
        messageCanvas.enabled = true;
        int money = GameObject.Find("Character").GetComponent<MoneyScript>().money;

        string itemName = item[1];
        int itemPrice = Convert.ToInt32(item[2]);

        double increase = itemPrice * .1;
        if (stolenFrom == true)
        {
            Math.Ceiling(increase);
            itemPrice += Convert.ToInt32(increase);
        }

        if (Input.GetButtonDown("Interact"))
        {
            if(money >= itemPrice)
            {
                moneyScript.SubtractMoney(itemPrice);
                Instantiate(prefab, GameObject.Find("Character").transform.position, Quaternion.identity);
            }

            else
            {
                
            } 
        }
    }

    public void IsStolenFrom()
    {
        stolenFrom = true;
    }

    public void LeaveInteraction()
    {
        messageCanvas.enabled = false;
    }

    public void DoJobInteraction(int[] job)
    {
        Console.WriteLine("Job Interaqction");
        int hoursPassed = 0;
        int time = Convert.ToInt32(GameObject.Find("Time").GetComponent<TimeTracker>().hoursDisplay);
        int maxHours = job[0];
        int hourPay = job[1];

        if (time > 22 || time < 6)
        {
            messageCanvas.enabled = true;

            if (Input.GetButtonDown("Interact"))
            {
                GameObject.Find("Character").GetComponent<PlayerInteract>().jobDone = true;
                fade.FadeImage(false);

                while (time < 22 && time > 6)
                {
                    if (hoursPassed <= maxHours)
                    {
                        GameObject.Find("Time").GetComponent<TimeTracker>().addedTime += 60;
                        hoursPassed += 1;
                        //FoodPoints -= 2;
                    }
                }
            }

            messageCanvas.enabled = false;
            int fullPay = hoursPassed * hourPay;
           // moneyScript.AddMoney(fullPay);
            fade.FadeImage(true);
        }

        else
        {
            messageCanvas.enabled = false;
        }

    }

    public void DoSleepInteraction()
    {
        messageCanvas.enabled = true;
        string status = GameObject.Find("Character").GetComponent<PlayerInteract>().playerStatus;
        int time = Convert.ToInt32(GameObject.Find("Time").GetComponent<TimeTracker>().hoursDisplay);
        int money = 1;// GameObject.Find("Character").GetComponent<MoneyScript>().money;

        if (buttonPressed)
        {
            fade.FadeImage(false);

            if (money > 100000 && status == "fancylad")
            {
                GameObject.Find("Character").GetComponent<PlayerInteract>().possibleStatus = "noble";
            }

            if (money > 10000 && status == "townfolk")
            {
                GameObject.Find("Character").GetComponent<PlayerInteract>().possibleStatus = "fancylad";
            }

            if (money > 1000 && status == "pleb")
            {
                GameObject.Find("Character").GetComponent<PlayerInteract>().possibleStatus = "townfolk";
            }

            while (time != 6)
            {
                GameObject.Find("Time").GetComponent<TimeTracker>().addedTime += 60;
                // FoodPoints -= 1;
            }

            fade.FadeImage(true);

        }

    }
}
