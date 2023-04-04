using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
   
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            Attack();
        }
    }

    void Attack()
    {
        // rajouter animation

        // Detection des ennemis dans la range de l attaque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        // Infliger des degats
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("hit" + enemy.name);
            enemy.GetComponent<EnemyHealth>().TakeDamage(50);

        }
    }
    // Dessine un cercle autour du gizmo pour voir la range de l attaque
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

       Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
