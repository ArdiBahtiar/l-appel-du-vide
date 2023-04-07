using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public PlayerHealth hp;
    public Rigidbody2D rb;
    public Pathfinding.AIPath myaipath;
    //[SerializeField] private float attackSpeed = 0f;
    //[SerializeField] private float canAttack = 1f;
    public float multiplier = 3f;
    public float duration = 3f;


    void Start() 
    {
        myaipath = GetComponent<Pathfinding.AIPath>();  
        rb = GetComponent<Rigidbody2D>();  
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("kena hit");

            other.gameObject.GetComponent<PlayerHealth>().TakeDamage();

            StartCoroutine(stun(other));
        }

         if(other.gameObject.tag == "Bullet")
        {
            StartCoroutine(takeDamage(other));
        }
    }

    IEnumerator stun(Collision2D other)
    {
        myaipath.enabled = false;
        rb.isKinematic = true;
        //this.enabled = false;

        yield return new WaitForSeconds (duration);

        myaipath.enabled = true;
        rb.isKinematic = false;
        //this.enabled = true;  
    }

    IEnumerator takeDamage(Collision2D other)
    {
        myaipath.enabled = false;
        rb.isKinematic = true;

        yield return new WaitForSeconds (duration);

        myaipath.enabled = true;
        rb.isKinematic = false;
    }
}
