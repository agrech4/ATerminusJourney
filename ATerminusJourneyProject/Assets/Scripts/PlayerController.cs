using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public enum PlayerState {
    moving,
    overworld,
    encounter,
    inMenu
}

public class PlayerController : MonoBehaviour {

    protected Rigidbody2D myRigidBody;
    protected Vector2 deltaPosition;
    protected Animator animator;
    public PlayerData playerData;
    public PlayerState playerState;

    // Start is called before the first frame update
    protected virtual void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = playerData.animatorController;
    }

    // Update is called once per frame
    protected virtual void Update() {
        deltaPosition = Vector2.zero;
        deltaPosition.x = Input.GetAxisRaw("Horizontal");
        deltaPosition.y = Input.GetAxisRaw("Vertical");
    }

    public virtual void MoveCharacter() {
        myRigidBody.MovePosition(myRigidBody.position + deltaPosition);
    }

}
