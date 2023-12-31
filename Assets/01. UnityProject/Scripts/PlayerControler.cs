using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public GameObject CoinEffectPrefab;
    public AudioClip deathClip;
    public float jumpForce = 700f;

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRigid = default;
    private Animator animator = default;
    private AudioSource playerAudio = default;

    void Start()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Debug.Assert(playerRigid != null);
        Debug.Assert(animator != null);
        Debug.Assert(playerAudio != null);
    }

    void Update()
    {
        if (isDead) {  return; }

        // LEGACY:
        //if (Input.GetMouseButtonDown(0) && jumpCount < 3)
            //{
            //    jumpCount += 1;
            //    playerRigid.velocity = Vector2.zero;
            //    playerRigid.AddForce(new Vector2(0, jumpForce));
            //    playerAudio.Play();

            //    GameObject coineffect = Instantiate(CoinEffectPrefab, transform.position, transform.rotation);
            //    Destroy(coineffect.gameObject, 0.5f);
            //}
            //else if (Input.GetMouseButtonDown(0) && 0 < playerRigid.velocity.y)
            //{
            //    playerRigid.velocity = playerRigid.velocity * 1f;
            //}

            animator.SetBool("Ground", isGrounded);
    }

    public void Jump()
    {
        if (jumpCount < 3)
        {
            jumpCount += 1;
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();

            GameObject coineffect = Instantiate(CoinEffectPrefab, transform.position, transform.rotation);
            Destroy(coineffect.gameObject, 0.5f);
        }
        else if (Input.GetMouseButtonDown(0) && 0 < playerRigid.velocity.y)
        {
            playerRigid.velocity = playerRigid.velocity * 1f;
        }
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRigid.velocity = Vector2.zero;
        isDead = true;

        GameManager_.instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Dead") && isDead == false)
        {
            Die();
        }
        if (collision.tag.Equals("Coin") && isDead == false)
        {
            GameManager_.instance.AddCoin(1);
            collision.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (0.7f < collision.contacts[0].normal.y)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
