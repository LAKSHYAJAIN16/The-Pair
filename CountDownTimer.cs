using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public PlayerMovement player1;
    public PlayerMovement player2;

    public float time = 10f;
    float maxTime;

    public TextMeshProUGUI timeText;

    void Start()
    {
        maxTime = time;
    }

    void Update()
    {
        time -= Time.deltaTime;
        
        string timeStr = time.ToString("00");
        timeText.text = timeStr;

        if (time <= 0f)
        {
            Reset();
        }
    }

    void Reset()
    {
        time = maxTime;
    }
}
