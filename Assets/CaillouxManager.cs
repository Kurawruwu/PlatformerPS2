using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaillouxManager : MonoBehaviour
{
    [SerializeField] GameObject Cailloux;
    [SerializeField] Transform[] Waypoints;
    private float timer;
    int i=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        timer += Time.deltaTime;
        if (timer >1.25f)
        {
            timer = 0;
            
            if((Random.Range(0, 10) < 5)) ChuteCailloux(i);

            if (i == Waypoints.Length - 1)
            {
                i = 0;
            }
            else i++;
            Debug.Log(i);
        }
    }

    void ChuteCailloux(int index)
    {
        Instantiate(Cailloux, Waypoints[index].position, Quaternion.identity);
    }
}
