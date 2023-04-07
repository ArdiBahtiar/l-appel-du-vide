using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Camera cam = ;
    public Rigidbody2D rb;
    public float MoveSpeed = 6.0f;
    Vector2 movement;
    Vector2 mousePos;
    //public Animator animator;

    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //langsung pake Camera.main biar gapake public2 lagi, jadi bisa buat instantiate
    }

    private void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);    

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }


    //KODINGAN SELINGAN BUAT SKIZOFRENIA

    public void Jumbo()
    {
        //transform.localScale *= 2.0f;
        transform.localScale = new Vector3(10,10,0);
    }

    public void Shrink()
    {
        //transform.localScale /= 2.0f;
        transform.localScale = new Vector3(5,5,0);
    }

}
