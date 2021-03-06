using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

  private bool playerInZone;
  [SerializeField]
  public string levelToLoad;

	// Use this for initialization
	void Start () {
    playerInZone = false;
  }
	
	// Update is called once per frame
	void Update () {
		if(playerInZone)
    {
      SceneManager.LoadScene(levelToLoad);
    } 
	}

  void OnTriggerEnter2D(Collider2D other) {
    if (other.name == "Trump")
    {
      playerInZone = true;
    }
  }

  void OnTriggerExit2D(Collider2D other)
  {
    if (other.name == "Trump")
    {
      playerInZone = false;
    }
  }
}
