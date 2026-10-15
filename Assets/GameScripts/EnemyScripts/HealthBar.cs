using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{


    [SerializeField] private Slider healthBar;
    private int mainHealth;


    // Use this for initialization
    void Start()
    {
        // Basic enemy
        if (gameObject.tag == "Enemy")
        {
            SetMaxHealth(3);
        }
    }


    private void SetMaxHealth(int maxHealth)
    {
        healthBar.maxValue = maxHealth;
        SetHealth(maxHealth);
    }

    private void SetHealth(int newHealth)
    {
        mainHealth = newHealth;
        healthBar.value = newHealth;
    }

    public void SubtractHealth(int damage)
    {
        mainHealth -= damage;
        SetHealth(mainHealth);
    }

    public bool IsDead(int damage)
    {
        return (mainHealth - damage <= 0);
    }

    public int GetHealth()
    {
        return mainHealth;
    }
}
