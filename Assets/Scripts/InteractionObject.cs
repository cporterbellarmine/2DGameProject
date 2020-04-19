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
            if(moneyVariable >= itemPrice)
            {
                moneyVariable -= itemPrice;
                Inventory.NextSlot(itemName);
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

    }

    public void JobInteraction(int[] job)
    {
        int hoursPassed = 0;
        int fullPay = 0;

        if (Input.GetButtonDown("Interact"))
        {
            int time = Convert.ToInt32(GameObject.Find("Time").GetComponent<TimeTracker>().hoursDisplay);

            if (time == 22)
            {
                messageCanvas.enabled = false;
            }

            else
            {
                messageCanvas.enabled = true;

                int maxHours = job[0];
                int hourPay = job[1];

                if(time < 22 && time > 6)
                {
                    messageCanvas.SendMessage("FadeImage", false);
                    GameObject.Find("Time").GetComponent<TimeTracker>().hours += 1;
                    hoursPassed += 1;
                }

                messageCanvas.enabled = false;
                fullPay = hoursPassed * hourPay;
                Inventory.MoneyValue += fullPay;
                messageCanvas.SendMessage("FadeImage", true);
            }

        }

    }

    void SleepInteract()
    {
        messageCanvas.enabled = true;

        if(Input.GetButtonDown("Interact"))
        {
            messageCanvas.SendMessage("FadeImage", "true");
            if()
        }
    }
}
