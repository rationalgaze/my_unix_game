using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

  public int maxPlayerHealth;
  public static int playerHealth;
  public Sprite flag;
  public Sprite noflag;
  //Text text;

  public Image[] flags;

  private LevelManager levelManager;
  public bool isDead;

  void Start () {
    //text = GetComponent<Text>();
    playerHealth = maxPlayerHealth;
    levelManager = FindObjectOfType<LevelManager>();
    isDead = false;
  }

	void Update () {
    if (playerHealth <= 0 && !isDead)
    {
      playerHealth = 0;
      levelManager.RespawnPlayer();
      isDead = true;
    }

    Debug.Log(playerHealth);

    for (int i = 0; i < flags.Length; i++)
    {
      if(i < playerHealth)
        flags[i].sprite = flag;
      else
        flags[i].sprite = noflag;

      if (i < maxPlayerHealth)
        flags[i].enabled = true;
      else
        flags[i].enabled = false;
    }
    //text.text = "" + playerHealth;
	}

  public static void HurtPlayer(int damageToGive)
  {
    playerHealth -= damageToGive;
  }

  public void FullHealth ()
  {
    playerHealth = maxPlayerHealth;
  }
}
