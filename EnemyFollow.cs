using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 1f;
    public float stoppedSpeed = 0f;
    Transform target;
    public float minimumDistance;

    private void Update() 
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if(Vector2.Distance(transform.position, target.position) > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }    
    }

    //IEnumerator afterDamageStop()
    //{
       //speed = stoppedSpeed;
        //yield return WaitForSeconds(3);
        //speed = 
    //}
    
}
