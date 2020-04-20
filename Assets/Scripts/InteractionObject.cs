using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    bool stolenFrom = false;
    public Canvas messageCanvas;

    private void Start()
    {
        messageCanvas.enabled = false;
    }

    public void DoSellInteraction(string[] item)
    {
        messageCanvas.enabled = true;
        int money = GameObject.Find("Character").GetComponent<MoneyScript>().money;

        string itemName = item[1];
        double itemPrice = Convert.ToDouble(item[2]);

        double increase = itemPrice * .1;
        if (stolenFrom == true)
        {
            itemPrice += increase;
            Math.Ceiling(itemPrice);
        }

        Convert.ToInt32(itemPrice);

        if (Input.GetButtonDown("Interact"))
        {
            if(money >= itemPrice)
            {
                SendMessage("SubtractMoney", "itemPrice");
                //Inventory.NextSlot(itemName);
                //show item in inventory

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
        int fullPay = 0;
        int time = Convert.ToInt32(GameObject.Find("Time").GetComponent<TimeTracker>().hoursDisplay);
        int money = GameObject.Find("Character").GetComponent<MoneyScript>().money;
        int maxHours = job[0];
        int hourPay = job[1];

        if (time > 22 || time < 6)
        {
            messageCanvas.enabled = true;

            if (Input.GetButtonDown("Interact"))
            {
                GameObject.Find("Character").GetComponent<PlayerInteract>().jobDone = true;
                messageCanvas.SendMessage("FadeImage", "false");

                while (time < 22 && time > 6)
                {
                    GameObject.Find("Time").GetComponent<TimeTracker>().addedTime += 60;
                    hoursPassed += 1;
                    //FoodPoints -= 2;
                }
            }

            messageCanvas.enabled = false;
            fullPay = hoursPassed * hourPay;
            SendMessage("AddMoney", "fullPay");
            SendMessage("FadeImage", "true");
        }

        else
        {
            messageCanvas.enabled = false;
        }

    }

    void DoSleepInteraction()
    {
        messageCanvas.enabled = true;
        string status = GameObject.Find("Character").GetComponent<PlayerInteract>().playerStatus;
        int time = Convert.ToInt32(GameObject.Find("Time").GetComponent<TimeTracker>().hoursDisplay);
        int money = GameObject.Find("Character").GetComponent<MoneyScript>().money;

        if (Input.GetButtonDown("Interact"))
        {
            messageCanvas.SendMessage("FadeImage", "false");

            if (money > 100000 && status == "fancylad")
            {
                //win
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

            messageCanvas.SendMessage("FadeImage", "true");

        }

    }
}
