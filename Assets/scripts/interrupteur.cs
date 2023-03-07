using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interrupteur : MonoBehaviour
{
    [SerializeField] bool isOn = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("dans la zone");

        if (collision.transform.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                isOn = true;
                Debug.Log("appuie");
            }
        }
    }
}
