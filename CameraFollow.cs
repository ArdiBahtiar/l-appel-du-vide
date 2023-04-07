using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public LevelGenerator script;

    //private GameObject target => script.player;
    //private Vector3 offset;
    //public Transform pemain;
    //private Transform target => script.tf;
    Transform target;

  
    void Start()
    {
        
    }

    
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}
