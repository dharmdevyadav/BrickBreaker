using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMove : MonoBehaviour
{
  [SerializeField] private float Speed;
  [SerializeField] private float LeftEdge;
  [SerializeField] private float RightEdge;
  public GameManager gm;

  public void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("PowerUp"))
    {
      gm.UpdateLive(1);
      Destroy(other.gameObject);
    }
  }
  void Update()
    {
    if (gm.gameOver)
    {
      return;
    }
    float Move = Input.GetAxis("Horizontal");
    transform.Translate(Vector2.right * Move * Time.deltaTime * Speed);

    if (transform.position.x < LeftEdge)
    {
      transform.position = new Vector2(LeftEdge, transform.position.y);
    }
    if (transform.position.x > RightEdge)
    {
      transform.position = new Vector2(RightEdge, transform.position.y);
    }
  }
}
