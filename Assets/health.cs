using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private int hpmax;
    private Image healthbar;
    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Image>();
    }
    public void TakeDamage(int damages)
    {
        hp -= damages;
        UpdateHealth();
    }
    // Soigne le joueur
    public void Heal(int heal)
    {
        hp += heal;
        UpdateHealth();
    }
    // Actualise les points de vie pour rester entre 0 et hpmax
    private void UpdateHealth()
    {
        hp = Mathf.Clamp(hp, 0, hpmax);
        float amount = (float)hp / hpmax;
        healthbar.fillAmount = amount;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
