using UnityEngine;

public class BuildAnchor : MonoBehaviour
{
    public static BuildAnchor Instance { get; set; }
    bool selected = false;

    private void Start()
    {
        Instance = this;
    }
    public void StartB()
    {
        selected = true;
    }

    public void StopB()
    {
        selected = false;
    }

    public bool canBuildB()
    {
        return selected;
    }
}
