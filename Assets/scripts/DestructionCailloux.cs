using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionCailloux : MonoBehaviour
{
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
            timer += Time.deltaTime;

            if (timer > 2)
            {
                Destroy(gameObject);
            }
        
    }
    
}
