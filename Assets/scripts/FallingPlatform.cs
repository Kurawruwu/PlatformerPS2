using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    float fallDelay = 0.3f;
    float destroyDelay = 2f;
    float spawnDelay = 1.5f;
    SpriteRenderer sr;
    BoxCollider2D box;
    [SerializeField] Rigidbody2D rb;
    Vector2 spawnPosition;
    private void Start()
    {

       spawnPosition = gameObject.transform.position;
        sr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(destroyDelay);
        sr.enabled = false;
        box.enabled = false;
        yield return new WaitForSeconds(spawnDelay);
        sr.enabled = true;
        box.enabled = true;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector2.zero;
        gameObject.transform.position = spawnPosition;
    }

}
