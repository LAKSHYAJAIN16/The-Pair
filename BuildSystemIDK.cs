using UnityEngine;

public class BuildSystemIDK : MonoBehaviour
{
    bool selected = false, canPickUp = true;
    public static bool weAreHolding = false;
    public Color selectedColor = Color.green;
    Color normColor;
    protected SpriteRenderer sr;
    public GameObject Canvas_WITHID;

    bool canHold = true;
    bool inRange = true;

    public LayerMask whatIsPlayer = 7;
    private GameObject player;

    public bool hasRange = false;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        normColor = sr.color;
        player = GameObject.FindGameObjectWithTag("RedPlayer");
    }

    private void OnMouseOver()
    {
        if (!canHold) return;
        if (!inRange) return;
        if (!canPickUp) return;
        if (!BuildAnchor.Instance.canBuildB()) return;
        sr.color = selectedColor;
        Canvas_WITHID.SetActive(true);
    }

    private void OnMouseExit()
    {
        if (!canHold) return;
        if (!canPickUp) return;
        sr.color = normColor;
        Canvas_WITHID.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!inRange) return;
        if (!canHold) return;
        if (!canPickUp) return;
        if (!BuildAnchor.Instance.canBuildB()) return;
        if (weAreHolding) return;
        selected = true;
        weAreHolding = true;
    }

    private void OnMouseUp()
    {
        if (!canHold) return;
        if (!canPickUp) return;
        if (!weAreHolding) return;
        selected = false;
        weAreHolding = false;
    }

    private void Update()
    {
        float dist = distance();

        if (dist <= 6f && hasRange) inRange = true;
        if (dist > 3f && !selected && hasRange) inRange = false;
        if (!selected) return;
        if (!inRange) return;
        if (!canPickUp) return;

        //Grab screen Pos
        Vector2 screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        //Set position equal to Vector
        transform.position = new Vector3(worldPos.x, worldPos.y, 0f);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "stop")
        {
            canPickUp = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "stop")
        {
            canPickUp = true;
        }
    }

    public float distance()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        return dist;
    }
}
