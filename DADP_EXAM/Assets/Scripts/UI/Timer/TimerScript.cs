using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float minutes = 59;
    public int Hours = 3;
    public TMP_Text timerDisplay;

    void Update()
    {
        minutes -= Time.deltaTime;
        if(minutes <= 0)
        {
            minutes = 59;
            Hours --;
        }

        if(Hours <= 0)
        {
            print("Time's Over");
            Hours = 3;
        }

        timerDisplay.text = string.Format("{0:00} :{1:00}",Hours, minutes);
    }
}
