using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] private float Speed;
  [SerializeField] Transform PaddlePosition;
  [SerializeField] Transform explosion;
  [SerializeField] Transform explosion2;
  [SerializeField] Transform explosion3;
  [SerializeField] Transform explosion4;
  [SerializeField] Transform PowerUps;
  GameManager gm;
  Rigidbody2D rb;
  public bool inPlay=false;
  private void Start()
  {
    rb=GetComponent<Rigidbody2D>();
    gm=FindObjectOfType<GameManager>();
  }
  private void FixedUpdate()
  {
    if (gm.gameOver)
    {
      rb.velocity = Vector2.zero;       
    }
    if (!inPlay)
    {
      transform.position = PaddlePosition.position;
    }
    if(Input.GetButtonDown("Jump")&& !inPlay)
    {
      inPlay = true;
      rb.AddForce(Vector2.up * Speed);
    }
  }
  public void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Bottom"))
    {
      transform.position = PaddlePosition.position;
      rb.velocity= Vector2.zero;
      inPlay = false;
      gm.UpdateLive(-1);
    }
  }
  public void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Brick"))
    {
      Bricks brickScript= other.gameObject.GetComponent<Bricks>();
      
      if (brickScript.numberOfHit > 1)
      {
        brickScript.AfterHitSprite();
      }
      else
      {
        int RandChance = Random.Range(1, 101);
        if (RandChance > 70)
        {
          Instantiate(PowerUps, other.transform.position, other.transform.rotation);
        }
        if (brickScript.points < 20)
        {
          Transform effect = Instantiate(explosion, other.transform.position, other.transform.rotation);
          Destroy(effect.gameObject, 2f);
        }
        if (brickScript.points == 20)
        {
          Transform effect1 = Instantiate(explosion2, other.transform.position, other.transform.rotation);
          Destroy(effect1.gameObject, 2f);
        }
        if (brickScript.points == 25)
        {
          Transform effect3 = Instantiate(explosion4, other.transform.position, other.transform.rotation);
          Destroy(effect3.gameObject, 2f);
        }
        if (brickScript.points == 30)
        {
          Transform effect2 = Instantiate(explosion3, other.transform.position, other.transform.rotation);
          Destroy(effect2.gameObject, 2f);
        }
        gm.UpdatenumberOfBrick();
        Destroy(other.gameObject);
        gm.UpdateScore(brickScript.points);
      }

    }
  }
}
