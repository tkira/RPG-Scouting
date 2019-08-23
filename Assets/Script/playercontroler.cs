using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroler : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public Slider HealthBar;
    public Slider Armor;
    public GameObject player;
    void Start()
     {

        rb = GetComponent<Rigidbody2D>();

     }
     void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        //potion
        //if (Input.GetKey(KeyCode.H))
        //{
        //    HealthBar.value -= 0.05f;
        //}

        if (HealthBar.value == 0.00f)
        {
            HealthBar.value += 1.00f;
            dead();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Armor.value > 0.1f) {
            if (other.CompareTag("bullet"))
            {
                HealthBar.value -= 0.05f;
                Armor.value -= 0.2f;
            }
        }
        else{
            HealthBar.value -= 0.3f;
        }

    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    void dead()
    {
        Destroy(gameObject);
    }
}
