using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform target;
    public float smoothTime = .3f;
    public Renderer background;
    private float rightBound;
    private float leftBound;

    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start() {
        rightBound = background.bounds.extents.x;
        leftBound = -rightBound;
    }

    // Update is called once per frame
    void Update() {

        Camera cam = GetComponent<Camera>();
        float leftmostView = cam.ViewportToWorldPoint(new Vector3(0, 0, 10)).x;
        float rightmostView = cam.ViewportToWorldPoint(new Vector3(1, 0, 10)).x;

        if (target && (leftmostView >= leftBound) && (rightmostView <= rightBound)) {
            Vector3 targetPos = target.position;
            float targetX = targetPos.x;
            Debug.Log(targetX.ToString());

            
            Vector3 destinationPos = new Vector3(targetPos.x, 0f, -10f);
            Vector3 newPos = Vector3.SmoothDamp(transform.position, destinationPos, 
                ref velocity, smoothTime);

            float xDiff = newPos.x - transform.position.x;

            if (((leftmostView + xDiff) >= leftBound) && ((rightmostView + xDiff) <= rightBound)) {
                transform.position = newPos;
            }

            leftmostView = cam.ViewportToWorldPoint(new Vector3(0, 0, 10)).x;
            rightmostView = cam.ViewportToWorldPoint(new Vector3(1, 0, 10)).x;

            if (leftmostView < leftBound) {
                float diff = leftBound - leftmostView;
                transform.position += new Vector3(diff, 0f, 0f);
            } else if (rightmostView > rightBound) {
                float diff = rightBound - rightmostView;
                transform.position += new Vector3(-diff, 0f, 0f);
            }

            //Debug.Log(background.bounds.extents.x.ToString());

            Debug.Log(leftmostView.ToString());
        } else if (leftmostView < leftBound) {
            float diff = leftBound - leftmostView;
            transform.position += new Vector3(diff, 0f, 0f);
        } else if (rightmostView > rightBound) {
            float diff = rightBound - rightmostView;
            transform.position += new Vector3(-diff, 0f, 0f);
        }
    }
}
