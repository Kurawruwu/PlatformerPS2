using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ronces : MonoBehaviour
{
    [SerializeField] Transform[] Waypoints;
    bool AttaqueRonces = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Waypoints[2].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

            transform.position = AttaqueRonces ? Waypoints[2].position : Waypoints[0].position;
            AttaqueRonces = !AttaqueRonces;
        }

        if (AttaqueRonces)
        {
            Vector3 dir = Waypoints[1].position - transform.position;
            transform.Translate(dir.normalized * 5f * Time.deltaTime, Space.World);

            if((int)transform.position.x == (int)Waypoints[2].position.x)
            {
                transform.position = Waypoints[0].position;
            }
        }
        
    }
}
