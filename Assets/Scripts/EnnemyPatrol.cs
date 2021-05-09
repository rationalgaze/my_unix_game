using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyPatrol : MonoBehaviour {

  public float moveSpeed;
  public bool moveRight;
  public Rigidbody2D rb;

  public Transform wallCheck;
  public Transform edgeCheck;
  public float wallCheckRadius;
  public LayerMask whatIsWal;
  private bool hittingWall;
  private bool notAtEdge;

  // Use this for initialization
  void Start () {
    rb = GetComponent<Rigidbody2D>();
  }
	
	// Update is called once per frame
	void Update () {
    hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWal);
    notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWal);

    if (hittingWall || !notAtEdge)
      moveRight = !moveRight;

    if (moveRight)
    {
      transform.localScale = new Vector3(0.15f, 0.15f, 1f);
      rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
    else
    {
      transform.localScale = new Vector3(-0.15f, 0.15f, 1f);
      rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    }
	}
}
