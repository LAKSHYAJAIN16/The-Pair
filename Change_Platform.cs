using UnityEngine;

public class Change_Platform : MonoBehaviour
{
    public GameObject red, blue;
    public float duration = 1f;
    void Start()
    {
        InvokeRepeating("Choose", 0f, duration);
    }

    void Choose()
    {
        //Randomly get an int
        int subscribe = Random.Range(0, 100);
        if (subscribe >= 50)
        {
            red.SetActive(true);
            blue.SetActive(false);
        }
        if (subscribe < 50)
        {
            blue.SetActive(true);
            red.SetActive(false);
        }
    }
}
