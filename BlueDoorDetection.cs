using UnityEngine;

public class BlueDoorDetection : MonoBehaviour
{
    public static BlueDoorDetection Instance { get; set; }

    bool blueIsThere;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "BluePlayer")
        {
            blueIsThere = true;
        }
    }

    void OnTriggerExit2D()
    {
        blueIsThere = false;
    }

    public bool isBlue()
    {
        return blueIsThere;
    }
}
