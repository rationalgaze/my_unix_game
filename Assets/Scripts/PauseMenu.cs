
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
  public string mainMenu;

  public bool isPaused;

  public GameObject pauseMenuCanvas;

  public AudioSource menuSound;

	// Update is called once per frame
	void Update () {
    if (isPaused)
    {
      pauseMenuCanvas.SetActive(true);
      Time.timeScale = 0f;
    }
    else
    {
      pauseMenuCanvas.SetActive(false);
      Time.timeScale = 1f;
    }

    if (Input.GetKeyDown(KeyCode.Escape))
    {
      isPaused = !isPaused;
      menuSound.Play();
    }
	}

  public void Pause()
  {
    isPaused = true;
    menuSound.Play();
  }

  public void Resume ()
  {
    isPaused = false;
    menuSound.Play();
  }

  public void Quit ()
  {
    SceneManager.LoadScene(mainMenu);
    menuSound.Play();
  }
}
