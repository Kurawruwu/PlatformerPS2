using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interrupteur : MonoBehaviour
{
    [SerializeField] bool isOn = false;
    bool inZone = false;
    [SerializeField] GameObject platform;
    Animator animController;

    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("Fire1")) && inZone)
        {
            isOn = true;
            Debug.Log(isOn);
            animController.SetBool("IsOn", true);
            StartCoroutine(Timer());
            
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
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        platform.SetActive(true);
    }
}
