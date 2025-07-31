using TMPro;
using UnityEngine;

/*
*   The clock that runs throughout the day.
*/

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI clockText;
    private int hours = 6;
    private int minutes = 0;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f) // Every real second = 1 in-game minute
        {
            timer -= 1f;
            minutes++;

            if (minutes >= 60)
            {
                minutes = 0;
                hours++;

                if (hours >= 24)
                    hours = 0;
            }

            UpdateClockDisplay();
        }
    }

    void UpdateClockDisplay()
    {
        if (clockText != null)
        {
            clockText.text = string.Format("{0:D2}:{1:D2}", hours, minutes);
        }
        else
        {
            Debug.Log(string.Format("Clock: {0:D2}:{1:D2}", hours, minutes));
        }
    }
}
