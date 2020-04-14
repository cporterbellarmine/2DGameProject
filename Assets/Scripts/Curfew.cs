using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curfew : MonoBehaviour
{
    public bool curfew;
    TimeTracker time = GameObject.Find("Clock").AddComponent<TimeTracker>();
    // Start is called before the first frame update
    void Start()
    {
        curfew = false;
    }

    // Update is called once per frame
    void Update()
    {
        curfew = time.curfew;
        if(time.curfew == true)
        {
            GetComponent<Renderer>().enabled = false;
        }
        else
        {
            GetComponent<Renderer>().enabled = true;
        }
    }
}
