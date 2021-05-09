using UnityEngine;

public class BulletController : MonoBehaviour {

  public float bulletSpeed;
  public Rigidbody2D rb;
  private PlayerController playerController;
  public GameObject objectDeathEffect;
  public GameObject crateDeathEffect;
  public GameObject impactEffect;
  public int damageToGive;

  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    playerController = FindObjectOfType<PlayerController>();

    if (playerController.transform.localScale.x < 0)
      bulletSpeed = -bulletSpeed;
  }

  // Update is called once per frame
  void Update () {
    rb.velocity = new Vector2(bulletSpeed, rb.velocity.y);
	}

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Destroyable")
      other.GetComponent<EnemyHealthManager>().GiveDamage(damageToGive);

    if (other.tag == "Crate")
    {
      Instantiate(crateDeathEffect, other.transform.position, other.transform.rotation);
      Destroy(other.gameObject);
    }

    Instantiate(impactEffect, transform.position, transform.rotation);
    Destroy(gameObject);
  }
}
