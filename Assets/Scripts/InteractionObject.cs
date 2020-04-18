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
    
}
