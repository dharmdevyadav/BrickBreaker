using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
  public int points;
  public int numberOfHit;
  public Sprite BrokenImage;

  public void AfterHitSprite()
  {
    numberOfHit--;
    GetComponent<SpriteRenderer>().sprite=BrokenImage;
    
  }

}
