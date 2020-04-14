using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private int lumpSum;
    public int lateDue;
    public int currentDue;
    public int lateInterest;
    public int gracePeriod;
    public int gracePeriodRenewal;
    public int tier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tier == 0)
        {
            gracePeriodRenewal = 0;
        }
        else if (tier == 1)
        {
            gracePeriodRenewal = 1;
        }
        else if (tier == 2)
        {
            gracePeriodRenewal = 2;
        }
        if (((int)GameObject.Find("Clock").GetComponent<TimeTracker>().days % 7) == 0)
        {
            if(lateDue == 0)
            {
                gracePeriod = gracePeriodRenewal;
            }
            lateDue += currentDue;
            lateDue = lateDue * lateInterest;
            currentDue += lumpSum;

        }

        if (((int)GameObject.Find("Clock").GetComponent<TimeTracker>().days % 7) == gracePeriod)
        {
            gracePeriod = 0;
            if(gracePeriod == 0)
            {
                GameObject.Find("Guard").GetComponent<Guard>().gracePeriod = false;
            }
            else
            {
                GameObject.Find("Guard").GetComponent<Guard>().gracePeriod = true;
            }
        }
       


    }
}
