using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] GameObject playerRef;
    public float speed;
    public Transform[] waypoints;
    private Transform target;
    private int destPoint=0;
    bool onPlatform = false;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
        }
        if (onPlatform)
        {
            playerRef.transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            onPlatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            onPlatform = false;
        }
    }
}
