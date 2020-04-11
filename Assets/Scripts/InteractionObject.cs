using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    bool stolenFrom = false;
    public void DoSellInteraction(string name, int price)
    {
        if (stolenFrom == true)
            price += 0;

    }

    public void IsStolenFrom()
    {
        stolenFrom = true;
    }

}
