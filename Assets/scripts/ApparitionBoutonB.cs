using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparitionBoutonB : MonoBehaviour
{
    

    [SerializeField] GameObject BoutonB;
    
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
        if (collision.transform.name == "Player")
        {
            
            
            BoutonB.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name == "Player")
        {

            BoutonB.SetActive(false);
        }
    }
}
