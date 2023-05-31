using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSprite : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField] Sprite Validation;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            sr.sprite = Validation;
        }
    }
}
