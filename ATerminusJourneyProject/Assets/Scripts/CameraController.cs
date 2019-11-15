using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Rigidbody2D target;
    public float smoothing;
    public Renderer background;

    private float leftBound;
    private float rightBound;

    // Start is called before the first frame update
    void Start() {
        Camera cam = GetComponent<Camera>();

        float camClearance = cam.orthographicSize * cam.aspect;
        leftBound = background.bounds.min.x + camClearance;
        rightBound = background.bounds.max.x - camClearance;

        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        targetPosition.x = Mathf.Clamp(targetPosition.x, leftBound, rightBound);

        if (transform.position != targetPosition) {
            transform.position = targetPosition;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        targetPosition.x = Mathf.Clamp(targetPosition.x, leftBound, rightBound);

        if (transform.position != targetPosition) {
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
