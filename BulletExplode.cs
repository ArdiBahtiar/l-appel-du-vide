using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplode : MonoBehaviour
{
    // Start is called before the first frame update
    
      
    public GameObject hitEffect;
    private GameObject musuh;
    public EnemyDamage ed;
    public float durasi = 3f;

    void Start()
    {
        
    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    
        if(collision.gameObject.tag == "Enemy")
        {
            ed.StartCoroutine(stun(collision));
            Debug.Log("Kena Hit Gess");
        }
    }



    IEnumerator stun(Collision2D musuh)
    {
        ed.myaipath.enabled = false;
        yield return new WaitForSeconds(durasi);
        ed.myaipath.enabled = true;
    }
}
