using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

  public GameObject currentCheckpoin;
  private PlayerController player;
  public GameObject deathParticle;
  public GameObject respawnParticle;
  public CameraFollow mainCamera;

  public float respawnDelay;
  public HealthManager healthManager;

	// Use this for initialization
	void Start () {
    player = FindObjectOfType<PlayerController>();
    mainCamera = FindObjectOfType<CameraFollow>();
    healthManager = FindObjectOfType<HealthManager>();
	}

  public void RespawnPlayer ()
  {
    StartCoroutine("RespawnPlayerCo");
  }

  public IEnumerator RespawnPlayerCo ()
  {
    Instantiate(deathParticle, player.transform.position, player.transform.rotation);
    player.enabled = false;
    player.GetComponent<Renderer>().enabled = false;
    mainCamera.isFollowing = false;
    yield return new WaitForSeconds(respawnDelay);
    player.transform.position = currentCheckpoin.transform.position;
    player.enabled = true;
    player.GetComponent<Renderer>().enabled = true;
    healthManager.isDead = false;
    healthManager.FullHealth();
    mainCamera.isFollowing = true;
    Instantiate(respawnParticle, currentCheckpoin.transform.position, currentCheckpoin.transform.rotation);
  }
}
