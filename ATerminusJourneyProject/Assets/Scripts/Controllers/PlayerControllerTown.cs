using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;


public class PlayerControllerTown : PlayerController {

    private IEnumerator waitForIdle;
    public float moveSpeed = 5f;
    public bool isReversed = false;
    public int timeToIdle = 2;

    // Start is called before the first frame update
    new void Start() {
        base.Start();
        animator.SetFloat("moveX", 1f);
        
    }

    void FixedUpdate() {
        deltaPosition.y = 0;
        if (deltaPosition != Vector2.zero && playerState == PlayerState.moving) {
            MoveCharacter();
            animator.SetFloat("moveX", deltaPosition.x);
            animator.SetBool("isMoving", true);
            animator.SetBool("idle", false);
            if (waitForIdle != null) {
                StopCoroutine(waitForIdle);
                waitForIdle = null;
            }
        } else if (animator.GetBool("isMoving")) {
            animator.SetBool("isMoving", false);
            if (waitForIdle == null) {
                waitForIdle = WaitForIdle();
                StartCoroutine(waitForIdle);
            }
        }
    }
    new void MoveCharacter() {
        playerRigidBody.MovePosition(playerRigidBody.position + deltaPosition * moveSpeed * Time.fixedDeltaTime);
    }

    private IEnumerator WaitForIdle() {
        yield return new WaitForSeconds(timeToIdle);
        animator.SetBool("idle", true);
        waitForIdle = null;
    }

}
