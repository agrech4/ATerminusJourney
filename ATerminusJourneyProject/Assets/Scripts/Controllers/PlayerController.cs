using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public enum PlayerState {
    moving,
    waiting,
    inMenu,
}

public class PlayerController : MonoBehaviour {

    protected Rigidbody2D playerRigidBody;
    protected Vector2 deltaPosition;
    protected Animator animator;
    public PlayerData playerData;
    public PlayerState playerState;

    protected virtual void Awake() {
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = playerData.animatorController;
        playerState = PlayerState.moving;
        if (playerData.newScenePos != Vector2.zero) {
            transform.position = new Vector3(playerData.newScenePos.x, playerData.newScenePos.y, 0);
            playerData.newScenePos = Vector2.zero;
        }
    }

    // Start is called before the first frame update
    protected virtual void Start() {
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
