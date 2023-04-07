using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{

    public PlayerMovement pm;
    public float multiplier = 2f;
    public float duration = 3f;

    public GameObject popupLoveLetter;


    void Start()
    {
        
    }

 
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            popup();
            StartCoroutine( pickup(other) );
        }
        
    }

    IEnumerator pickup(Collider2D player)
    {
        PlayerMovement speed = player.GetComponent<PlayerMovement>();
            speed.MoveSpeed *= multiplier;

        // BUAT NGILANGIN SPRITE ITEM
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        // DURASI BUFF
        yield return new WaitForSeconds (duration);

        // KONDISI SEMULA
            speed.MoveSpeed /= multiplier;

            Destroy(gameObject);
    }


    void popup()
    {
        GameObject popup = Instantiate(popupLoveLetter, new Vector3(0,0,0), Quaternion.identity);
        Time.timeScale = 0;
    }

    public void jalanlagi()
    {
        Time.timeScale = 1;
    }
}
