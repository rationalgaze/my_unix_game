using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectsOverTime : MonoBehaviour {

  public float lifetime;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    lifetime -= Time.deltaTime;
    if (lifetime < 0)
      Destroy(gameObject);
	}
}
