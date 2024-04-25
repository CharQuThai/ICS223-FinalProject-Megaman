using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public int maxHealth = 10;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthText.text = health.ToString();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthText.text = health.ToString();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
