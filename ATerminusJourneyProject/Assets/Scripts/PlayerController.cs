using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    moving,
    inMenu
}

public class PlayerController : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    private Vector2 deltaPosition;
    private Animator animator;
    public PlayerData playerData;
    public PlayerState playerState;
    public float moveSpeed = 5f;
    public bool isReversed = false;

    // Start is called before the first frame update
    void Start() {
        playerState = PlayerState.moving;
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = playerData.animatorController;
        animator.SetFloat("moveX", 1f);
    }

    // Update is called once per frame
    void Update() {
        deltaPosition = Vector2.zero;
        deltaPosition.x = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate() {
        if (deltaPosition != Vector2.zero && playerState == PlayerState.moving) {
            MoveCharacter();
            animator.SetFloat("moveX", deltaPosition.x);
            animator.SetBool("isMoving", true);
        } else {
            animator.SetBool("isMoving", false);
        }
    }

    void MoveCharacter() {
        myRigidBody.MovePosition(myRigidBody.position 
            + (deltaPosition * moveSpeed * Time.fixedDeltaTime));
    }


}
