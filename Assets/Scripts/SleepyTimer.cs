using System.Collections;
using TMPro;
using UnityEngine;

public class SleepyTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI winLoseText;
    public bool playingGame;
    public float timeRemaining; // current value of timer

    public float maxTimerDuration; // max duration of timer
    public bool timerShouldDecrease; // when this variable becomes true, the coroutine is started again to subtract another second

    // Start is called before the first frame update
    public void Start()
    {
        playingGame = true;

        timeRemaining = maxTimerDuration;
        timerShouldDecrease = true;
    }

    // Update is called once per frame
    public void Update()
    {
        if (timerShouldDecrease && playingGame)
        {
            StartCoroutine(DecreaseTimer());
        }

        if (timeRemaining < 0)
        {
            playingGame = false;
            winLoseText.text = "Game over... You got too sleepy... zzz";
            timerText.text = "Sleepy timer: 0";
        }
    }

    public IEnumerator DecreaseTimer()
    {
        timerShouldDecrease = false;

        timerText.text = "Sleepy timer: " + timeRemaining;

        yield return new WaitForSeconds(1);

        if (playingGame)
        {
            timeRemaining -= 1;
        }

        timerShouldDecrease = true;  

    }
}
