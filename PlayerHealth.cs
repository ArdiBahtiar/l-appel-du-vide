using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   
   public int MaxHealth = 100;
   public int currentHealth;
   private PlayerMovement pm;
   //public GameManager gm;


   //public HealthBar healthBar;
   private HealthBar hp;

    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        currentHealth = MaxHealth;
        hp.SetMaxHealth(MaxHealth);
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
        }

        if(currentHealth <= 0)
        {
            //EndTrigger.goodWill--;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 10;

        hp.SetHealth(currentHealth);
    }

    public void Heal()
    {
        currentHealth += 50;

        hp.SetHealth(currentHealth);
        //Destroy(gameObject); YANG ILANG ORANGNYA NANTI
    }

}