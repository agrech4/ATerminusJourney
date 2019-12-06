﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState {
    moving,
    overworld,
    inMenu
}

public class PlayerController : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    private Vector2 deltaPosition;
    private Animator animator;
    private IEnumerator waitForIdle;
    public PlayerData playerData;
    public PlayerState playerState;
    public float moveSpeed = 5f;
    public bool isReversed = false;
    public int timeToIdle = 2;
    public float gridScaleX = 2f;
    public float gridScaleY = 1.732051f;
    public float gridMoveWait = .1f;
    private bool gridCanMove = true;

    // Start is called before the first frame update
    void Start() {
        playerState = PlayerState.moving;
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = playerData.animatorController;
        animator.SetFloat("moveX", 1f);
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Overworld")) {
            playerState = PlayerState.overworld;
            animator.SetBool("onOverworld", true);
        }
    }

    // Update is called once per frame
    void Update() {
        deltaPosition = Vector2.zero;
        deltaPosition.x = Input.GetAxisRaw("Horizontal");
        deltaPosition.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        if (playerState != PlayerState.overworld) {
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
        } else {
            if(gridCanMove) {
                if (MoveCharacterGrid()) {
                    StartCoroutine(WaitForGridMove());
                }
            }
        }
    }

    void MoveCharacter() {
        myRigidBody.MovePosition(myRigidBody.position 
            + (deltaPosition * moveSpeed * Time.fixedDeltaTime));
    }

    bool MoveCharacterGrid() {
        deltaPosition.x = (int)System.Math.Round(deltaPosition.x, 0);
        deltaPosition.y = (int)System.Math.Round(deltaPosition.y, 0);
        deltaPosition.x *= System.Math.Abs(deltaPosition.y);
        deltaPosition.y -= deltaPosition.y * .5f * System.Math.Abs(deltaPosition.x);
        deltaPosition.x *= gridScaleX * .75f;
        deltaPosition.y *= gridScaleY;
        myRigidBody.MovePosition(myRigidBody.position + deltaPosition);
        return (deltaPosition != Vector2.zero);
    }


    private IEnumerator WaitForGridMove() {
        gridCanMove = false;
        yield return new WaitForSeconds(gridMoveWait);
        gridCanMove = true;
    }

    private IEnumerator WaitForIdle() {
        yield return new WaitForSeconds(timeToIdle);
        animator.SetBool("idle", true);
        waitForIdle = null;
    }

}
