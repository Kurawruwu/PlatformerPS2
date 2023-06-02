using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isInvincible = false;
    public SpriteRenderer graphics;
    public float invincibilityFlashDelay = 0.2f;
    Transform playerSpawn;
    public BarreDeVie healthBar;

    [SerializeField] GameObject hitboxDMG;

    public static PlayerHealth instance;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'une instance PlayerHealth dans la scene");
            return;
        }
        instance = this;
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;

    }

    // Start is called before the first frame update
    void Start()
    {
        // le joueur commence avec toute sa vie
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void HealPlayer (int amount) 
    {
        if ((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

       
        healthBar.SetHealth(currentHealth);
    }
    public void TakeDamage (int damage)
    {
        if(!isInvincible)
        {
            currentHealth -= damage;  // si on prends des degats ont retire de la vie a la vie actuelle
            healthBar.SetHealth(currentHealth); // pour mettre a jour le visuel de la barre de vie
            if (currentHealth <= 0)
            {
                Die();
               return;
            }

            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());


        }
    }

    public void Die()
    {
        Debug.Log("mort");
        PlayerMovement.instance.enabled = false;
        // ajouter pour animation mort du perso
        gameObject.layer = 6;
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.playerCollider.enabled = false;
        transform.position = playerSpawn.position;
        // Retour ? la vie
        currentHealth = 100;
        healthBar.SetHealth(currentHealth);
        gameObject.layer = 3;
        PlayerMovement.instance.enabled = true;
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.playerCollider.enabled = true;
    }
    public void Revive()
    {

    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            hitboxDMG.SetActive(false);
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);

            hitboxDMG.SetActive(true);
        }
      //  Debug.Log("Coroutine1");
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(1.5f);
        isInvincible = false;
      //  Debug.Log("Coroutine2");
    }
}
