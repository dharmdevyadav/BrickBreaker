using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
  [SerializeField]private float speed;
  
  private void Update()
  {
    transform.Translate(new Vector2(0f, -1f) * Time.deltaTime * speed);
    if (transform.position.y < -5.3f)
    {
      Destroy(gameObject);
    }
  }
}
