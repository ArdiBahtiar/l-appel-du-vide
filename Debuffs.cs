using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuffs : MonoBehaviour
{

    public PlayerMovement pm;
    public PlayerHealth hp;
    public float multiplier = 2.0f;


    private void Start() 
    {
        pm = GetComponent<PlayerMovement>();   
        hp = GetComponent<PlayerHealth>(); 
    }

   // INI BUAT MANGGIL DEBUFF NYA YGY
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Depression")
        {
            StartCoroutine(DepressionDOT(other));
        }

        if(other.gameObject.tag == "Anxiety")
        {
            StartCoroutine(AnxietySlow(other));
        }

        if(other.gameObject.tag == "PTSD")
        {
            StartCoroutine(PTSDstun(other));
        }

        if(other.gameObject.tag == "Skizofrenia")
        {
            StartCoroutine(SkizofreniaIllusion(other));
        }

        if(other.gameObject.tag == "ADHD")
        {
            StartCoroutine(ADHDrandom(other));
        }
    }

     // BUAT 5 DEBUFF DARI MUSUH

    IEnumerator DepressionDOT(Collision2D other)
    {  
        yield return new WaitForSeconds(1.0f);

        hp.TakeDamage();
        //other.gameObject.GetComponent<PlayerHealth>().TakeDamage();

        yield return new WaitForSeconds(1.0f);

        hp.TakeDamage();
        //hp.currentHealth -= 20;
    }

    IEnumerator ADHDrandom(Collision2D player)
    {
        pm.MoveSpeed = -9.0f;

        yield return new WaitForSeconds (4.0f);

        pm.MoveSpeed = 6.0f;
    }

    IEnumerator PTSDstun(Collision2D other)
    {
        pm.MoveSpeed = 0f;

        yield return new WaitForSeconds(1.0f);

        pm.MoveSpeed = 6.0f;
    }

    IEnumerator AnxietySlow(Collision2D other)
    {
        //pm.MoveSpeed /= multiplier;
        pm.MoveSpeed = 3.0f;

        yield return new WaitForSeconds(4.0f);

        //pm.MoveSpeed *= multiplier;
        pm.MoveSpeed = 6.0f;
    }

    IEnumerator SkizofreniaIllusion(Collision2D other)
    {
        //player.transform.localScale *= multiplier;
        pm.Jumbo();

        yield return new WaitForSeconds (6.0f);

        //player.transform.localScale /= multiplier;
        pm.Shrink();
    }

}
