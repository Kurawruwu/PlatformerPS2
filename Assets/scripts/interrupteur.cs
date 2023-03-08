using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interrupteur : MonoBehaviour
{
    [SerializeField] bool isOn = false;
    bool inZone = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && inZone)
        {
            isOn = !isOn;
            Debug.Log(isOn);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Player")
        {
            //Debug.Log("dans la zone");
            inZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name == "Player")
        {
            //Debug.Log("dehors la zone");
            inZone = false;
        }
    }
}
