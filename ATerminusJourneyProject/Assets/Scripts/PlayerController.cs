using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private SpriteRenderer mySpriteRenderer;
    public float moveSpeed = 5f;
    public bool isReversed = false;
    public BoxCollider2D collider;
    // Start is called before the first frame update
    void Start() {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        float movement = Input.GetAxis("Horizontal");

        ContactPoint2D[] contacts = new ContactPoint2D[1];
        int numContacts = collider.GetContacts(contacts);
        if (numContacts > 0) {
            if (contacts[0].normal.x < 0 && movement > 0) {
                movement = 0;
            } else if (contacts[0].normal.x > 0 && movement < 0) {
                movement = 0;
            }
        }

        Vector3 movementVector = new Vector3(movement, 0f);
        transform.position += movementVector * Time.deltaTime * moveSpeed;

        if ((isReversed == (movement > 0)) && (movement != 0)) {
            mySpriteRenderer.flipX = !mySpriteRenderer.flipX;
            isReversed = !isReversed;
        }

    }
}
