
using UnityEngine;

public class Soin : MonoBehaviour
{
    public int HealthPoints;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth.instance.HealPlayer(HealthPoints);
            Destroy(gameObject);
        }
    }


}
