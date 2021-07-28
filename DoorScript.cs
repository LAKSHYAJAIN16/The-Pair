using UnityEngine;
using TMPro;

public class DoorScript : MonoBehaviour
{
    public static DoorScript Instance { get; set; }

    bool redHasPassed, blueHasPassed, opened = false;
    bool hasPlayed = false, can = false, called = false;
    public TextMeshProUGUI text, attemptTakrenText, currentRecText;
    public GameObject warning, button, noice, TimeText, timeAddon;
    public GameObject winUI, lockedUI, tutorialInfo;
    private GameObject PlayerRed, PlayerBlue;
    int currentrec;
    public string nameofLevel = "Tutorial";
    public SpriteRenderer light;

    // Start is called before the first frame update
    void Start()
    {
        //Just for testing :L
        //PlayerPrefs.DeleteAll();
        Instance = this;
        hasPlayed = false;
        Time.timeScale = 1f;
        PlayerBlue = GameObject.FindGameObjectWithTag("BluePlayer");
        PlayerRed = GameObject.FindGameObjectWithTag("RedPlayer");
        if (PlayerPrefs.HasKey(nameofLevel))
            currentrec = PlayerPrefs.GetInt(nameofLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyScript.Instance.enemydefeated() && NumpAdScript.Instance.numpadunlocked())
        {
            opened = true;
            light.color = Color.green;
            if (!called)
            {
                called = true;
                AudioManager.Instance.Play("door");
            }
        }

        Check();
        if (opened)
        {
            can = false;
            button.SetActive(false);
        }
        if (blueHasPassed && redHasPassed && !hasPlayed)
        {
            warning.SetActive(false);
            AudioManager.Instance.Play("leveldoneb");
            attemptTakrenText.text = "ATTEMPTS TAKEN : " + TimeManager.Instance.timesTaken().ToString();
            hasPlayed = true;
            TimeText.SetActive(false);
            timeAddon.SetActive(false);
            if (tutorialInfo != null) tutorialInfo.SetActive(false);

            winUI.SetActive(true);
            Time.timeScale = 0f;
            int times = TimeManager.Instance.timesTaken();

            if (PlayerPrefs.HasKey(nameofLevel))
            {
                int old = PlayerPrefs.GetInt(nameofLevel);

                if (old <= times)
                {
                    currentRecText.text = "YOUR RECORD : " + old.ToString();
                    currentrec = old;
                }
                else if (old > times)
                {
                    //New Record!
                    //Override saved value
                    PlayerPrefs.SetInt(nameofLevel, times);
                    currentrec = times;
                    currentRecText.text = "YOUR RECORD : " + times.ToString();
                    noice.SetActive(true);
                }
            }
            else
            {
                PlayerPrefs.SetInt(nameofLevel, times);
                currentrec = times;
                currentRecText.text = "YOUR RECORD : " + times.ToString();
            }
        }
    }

    void Cantnoob()
    {
        warning.SetActive(true);
        Invoke(nameof(stop), 1f);
    }

    void stop()
    {
        warning.SetActive(false);
    }

    public void OnPress()
    {
        can = true;
        Check();
        Check();
    }

    void Check()
    {
        if (RedDoorDetection.Instance.isRed())
        {
            if (opened)
            {
                CinemachineCamShake.Instance.ShakeCamera(1f, 0.2f, 1f);
                redHasPassed = true;
                PlayerRed.gameObject.SetActive(false);
                TimeManager.Instance.Stop("red");
                AudioManager.Instance.Play("pop");
            }
            return;
        }

        else if (BlueDoorDetection.Instance.isBlue())
        {
            if (opened)
            {
                CinemachineCamShake.Instance.ShakeCamera(1f, 0.2f, 1f);
                blueHasPassed = true;
                PlayerBlue.gameObject.SetActive(false);
                TimeManager.Instance.Stop("blue");
                AudioManager.Instance.Play("pop");
            }

            return;
        }
        else
        {
            button.SetActive(false);
            can = false;
        }
    }
}
