using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    private float totalSeconds; //represents how many seconds has passed since the game has started
    private float minutes; //represents the total minutes in game time
    private float hours; //represents the total hours in game time
    private float days; //represents the total days in game time.

    // Start is called before the first frame update
    void Start()
    {

    }//end start

    // Update is called once per frame
    void Update()
    {
        totalSeconds = Time.fixedTime;

        //We want each second to be one minute in this game.
        minutes = totalSeconds;
        hours = minutes / 60;
        days = hours / 24;
        
    }//end update

    private void OnGUI()
    {
        //This label appears in the top right corner while the game is running.
        GUI.Label(new Rect(Screen.width - 100, 0, 100, 50), $"Day {(int)days%24} {(int)hours%60}:{(int)minutes%60}");

    }//end ongui
}
