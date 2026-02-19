using TMPro;
using UnityEngine;

public class TreatArrival : MonoBehaviour
{
    public TextMeshProUGUI winLoseText;

    public void OnTriggerEnter(Collider other)
    {
        SleepyTimer sleepyTimer = other.GetComponent<SleepyTimer>();

        if (sleepyTimer.playingGame)
        {
            winLoseText.text = "Got the treat with " + sleepyTimer.timeRemaining + " seconds left!";
            sleepyTimer.playingGame = false;
        }
    }
}
