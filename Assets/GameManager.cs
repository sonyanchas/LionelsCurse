using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text TimerText;
    public int Timer;
    [SerializeField] int TimeSet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer = (TimeSet - (int)Time.time); // Make timer go down by the time and how much time set
        TimerText.text = Timer.ToString();
        if (Timer == 0) //If timer hits 0, print game over and end  
        {
            TimerText.text = "Game Over";
            Time.timeScale = 0;
        }
    }
}
