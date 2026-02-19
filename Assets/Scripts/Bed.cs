using System.Collections;
using TMPro;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public float timeToAdd;
    public TextMeshProUGUI napText;
    public bool napTaken;

    public void Start()
    {
        napTaken = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ginger")
        {
            SleepyTimer sleepyTimer = other.GetComponent<SleepyTimer>();
            
            if (sleepyTimer.playingGame)
            {
                if (!napTaken)
                {
                    sleepyTimer.playingGame = false;

                    // make nap text appear for a short time, then disappear
                    StartCoroutine(DisplayNapText());

                    sleepyTimer.timeRemaining += timeToAdd;
                    sleepyTimer.timerText.text = "Sleepy timer: " + sleepyTimer.timeRemaining;

                    napTaken = true;
                }
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ginger")
        {
            SleepyTimer sleepyTimer = other.GetComponent<SleepyTimer>();
            sleepyTimer.playingGame = true;
        }
    }

    public IEnumerator DisplayNapText()
    {
        napText.text = "Ginger took a nap... zzzzzz";
        yield return new WaitForSeconds(1.5f);
        napText.text = "";
    }

}
