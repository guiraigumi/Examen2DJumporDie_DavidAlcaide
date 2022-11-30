using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator animator;
    private SFXManager sfxManager;

    private void Awake()

    {
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sfxManager.BombSound();
            animator.SetBool("Bomba", true);
            GameManager.Instance.LoseLife();
            Destroy(this.gameObject, .5f);
        }
    }
}
