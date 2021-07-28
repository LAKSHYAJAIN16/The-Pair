using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool bothBlueAndRed = false;
    public string whatPlayer;
    public string othertagf;

    private SpriteRenderer sr;

    public Color pressedColor = Color.green;
    public Color normalColor;

    [Header("Behavior")]
    public bool isRisingPlatform = true;
    public RisingPlatform risingsr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D other)
    { 
        Debug.Log("Entered");
        if (bothBlueAndRed)
        {
            if (other.tag == "BluePlayer" || other.tag == "RedPlayer" || other.tag == whatPlayer || other.tag == othertagf)
                Open();
        }
        else if (!bothBlueAndRed)
        {
            if (other.tag == whatPlayer || other.tag == othertagf)
                Open();
        }
    }

    private void OnTriggerExit2D()
    {
        sr.color = normalColor;
        if (isRisingPlatform) risingsr.Down();
    }

    private void Open()
    {
        //Whatever the button does
        sr.color = pressedColor;
        if (isRisingPlatform) risingsr.Rising();
    }
}
