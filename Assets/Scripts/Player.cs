using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator anim;
    private float horizontal;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] Transform groundSensor;
    [SerializeField] float sensorRadius;
    [SerializeField] LayerMask sensorLayer;
    [SerializeField] bool isGrounded;
    [SerializeField] private float speed = 3;
    private SFXManager sfxManager;
    void Awake()
    {
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        rBody = GetComponent<Rigidbody2D>();      
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("isRunning", true);
        }
        else if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("isRunning", true);
        }
        else if (horizontal == 0)
        {
            anim.SetBool("isRunning", false);
        }
        isGrounded = Physics2D.OverlapCircle(groundSensor.position, sensorRadius, sensorLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            sfxManager.JumpSound();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Estrella")
        {
            GameManager.Instance.LoadLevel(1);
        }

        else if (collider.gameObject.tag == "Moneda")
        {
            GameManager.Instance.AddCoin(collider.gameObject);
            sfxManager.MonedaSound();
        }
    }
    void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontal * speed, rBody.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 3)
        {
            anim.SetBool("isJumping", false);
        }
    }
    void OnDrawGizmos()
    {
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundSensor.position, sensorRadius);
        }
    }
}



