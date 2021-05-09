
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  public Rigidbody2D rb;
  private Animator animator;

  [SerializeField]
  public float speed;

  [SerializeField]
  private Transform[] groundPoints;
  private bool facingRight = true;

  [SerializeField]
  private float groundRadius;

  [SerializeField]
  private LayerMask whatIsGround;
  private bool isGrounded;
  private bool jump;

  [SerializeField]
  private float jumpForce;
  private float dirX;

  public float leftLimit;
  public float rightLimit;
  public GameObject bullet;
  public Transform firePoint;

  public float knockBack;
  public float knockBackLength;
  public float knockBackCount;
  public bool knockbFromRight;

  // Use this for initialization
  void Start()
  {
    animator = this.GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    HandleInput();
  }

  void FixedUpdate()
  {
    float horizontal = Input.GetAxis("Horizontal");
    isGrounded = IsGrounded();
    HandleMovement(horizontal);
    ResetValues();
    KnockBackHandler();
  }

  private void HandleInput()
  {
    if (Input.GetKeyDown(KeyCode.UpArrow))
      jump = true;

    if (Input.GetKeyDown(KeyCode.Space))
      Instantiate(bullet, firePoint.position, firePoint.rotation);
  }

  private void HandleMovement(float horizontal)
  {
    dirX = horizontal * speed;
    rb.velocity = new Vector2(dirX, rb.velocity.y);

    // X axis gameplay edge
    if (transform.position.x <= leftLimit)
    {
      transform.position = new Vector3(leftLimit, transform.position.y, 1f);
    }
    else if (transform.position.x >= rightLimit)
    {
      transform.position = new Vector3(rightLimit, transform.position.y, 1f);
    }

    // Y axis gameplay edge
    if (transform.position.y <= -8.7f)
    {
      transform.position = new Vector3(transform.position.x, -8.7f, 1f);
    }
    else if (transform.position.y >= 4f)
    {
      transform.position = new Vector3(transform.position.x, 4f, 1f);
    }

    // running
    if (Mathf.Abs(dirX) > 0)
      animator.SetBool("isRunning", true);
    else
      animator.SetBool("isRunning", false);

    // stop jumping and landing on the ground
    if (isGrounded && !jump)
    {
      animator.SetBool("isJumping", false);
      animator.SetBool("isLanding", false);
    }

    if (rb.velocity.y > 0)
    {
      //animator.SetBool("isJumping", true);
      animator.SetBool("isLanding", false);
    }

    if (rb.velocity.y < 0)
    {
      animator.SetBool("isJumping", false);
      animator.SetBool("isLanding", true);
    }
    
    if (isGrounded && jump)
    {
      animator.SetBool("isJumping", true);
      rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
    }

    // turn sprite left or right
    if (horizontal > 0 && !facingRight)
      Flip();
    else if (horizontal < 0 && facingRight)
      Flip();
  }

  void KnockBackHandler ()
  {
    if (knockBackCount <= 0)
      rb.velocity = new Vector2(dirX, rb.velocity.y);
    else
    {
      if (knockbFromRight)
        rb.velocity = new Vector2(-knockBack, knockBack/5);
      if (!knockbFromRight)
        rb.velocity = new Vector2(knockBack, knockBack/5);
      knockBackCount -= Time.deltaTime;
    }

  }

  void Flip ()
  {
    facingRight = !facingRight;
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;
  }

  private bool IsGrounded()
  {
    if (rb.velocity.y <= 0)
    {
      foreach (Transform point in groundPoints)
      {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

        for (int i = 0; i < colliders.Length; i++)
        {
          if (colliders[i].gameObject != gameObject)
          {
            return true;
          }
        }
      }
    }
    return false;
  }

  private void ResetValues()
  {
    jump = false;
  }
}
