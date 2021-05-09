using UnityEngine;

public class CameraFollow : MonoBehaviour {
  [SerializeField]
  private float xMax;
  [SerializeField]
  private float yMax;
  [SerializeField]
  private float xMin;
  [SerializeField]
  private float yMin;

  private Transform target;
  public bool isFollowing;

  void Start () {
    target = GameObject.Find("Trump").transform;
	}
	
	void LateUpdate () {
    if (isFollowing)
      transform.position = new Vector3(
        Mathf.Clamp(target.position.x, xMin, xMax), 
        Mathf.Clamp(target.position.y, yMin, yMax),
        transform.position.z
      );
	}
}
