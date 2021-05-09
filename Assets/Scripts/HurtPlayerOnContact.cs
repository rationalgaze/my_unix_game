using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour {

  public int damageToGive;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.name == "Trump")
    {
      HealthManager.HurtPlayer(damageToGive);
      other.GetComponent<AudioSource>().Play();

      var player = other.GetComponent<PlayerController>();
      player.knockBackCount = player.knockBackLength;

      if (other.transform.position.x < transform.position.x)
        player.knockbFromRight = true;
      else
        player.knockbFromRight = false;
    }
  }
}
