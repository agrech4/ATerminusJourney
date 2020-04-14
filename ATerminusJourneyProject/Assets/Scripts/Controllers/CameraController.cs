using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public float smoothing;
    public Renderer background;
    //Camera bounds
    private float leftBound;
    private float rightBound;
    private float topBound;
    private float bottomBound;

    void Awake() {
        Camera cam = GetComponent<Camera>();
        //Get camera bounds
        float camClearance = cam.orthographicSize * cam.aspect;
        leftBound = background.bounds.min.x + camClearance;
        rightBound = background.bounds.max.x - camClearance;
        bottomBound = background.bounds.min.y + cam.orthographicSize;
        topBound = background.bounds.max.y - cam.orthographicSize;

    }

    // Start is called before the first frame update
    void Start() {
        Vector3 targetPosition = GetTargetPosition();
        //Jump to target postion
        if (transform.position != targetPosition) {
            transform.position = targetPosition;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector3 targetPosition = GetTargetPosition();
        //Move smoothly toward taget position
        if (transform.position != targetPosition) {
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }

    //Get the position where the camera should move
    private Vector3 GetTargetPosition() {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        targetPosition.x = Mathf.Clamp(targetPosition.x, leftBound, rightBound);
        targetPosition.y = Mathf.Clamp(targetPosition.y, bottomBound, topBound);
        return targetPosition;
    }
}
