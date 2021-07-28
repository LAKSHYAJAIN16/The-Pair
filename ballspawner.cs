using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSpawner : MonoBehaviour
{
    public GameObject explosion, Spawner;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "BluePlayer")
        {
            if (Input.GetMouseButton(0))
            {
                    explosion.SetActive(true);
                    Spawner.SetActive(false);
                    MainMenuLight lightsr = Spawner.transform.GetComponent<MainMenuLight>();
                    lightsr.StopSpawning();
            }
        }
    }
}
