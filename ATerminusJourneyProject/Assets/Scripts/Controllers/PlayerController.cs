using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public enum PlayerState {
    moving,
    inMenu
}

public class PlayerController : MonoBehaviour {

    protected Rigidbody2D playerRigidBody;
    protected Vector2 deltaPosition;
    protected Animator animator;
    public PlayerData playerData;
    public PlayerState playerState;

    // Start is called before the first frame update
    protected virtual void Start() {
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = playerData.animatorController;
        playerState = PlayerState.moving;
        if (playerData.newScenePos != Vector2.zero) {
            playerRigidBody.MovePosition(playerData.newScenePos);
            playerData.newScenePos = Vector2.zero;
        }
    }

    // Update is called once per frame
    protected virtual void Update() {
        deltaPosition = Vector2.zero;
        if (playerState != PlayerState.inMenu) {
            deltaPosition.x = Input.GetAxisRaw("Horizontal");
            deltaPosition.y = Input.GetAxisRaw("Vertical");
        }
    }

    public virtual void MoveCharacter() {
        playerRigidBody.MovePosition(playerRigidBody.position + deltaPosition);
    }

}
