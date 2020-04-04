using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;


public class PlayerControllerEncounter : PlayerController {

    public float gridScaleX = 1.75f;
    public float gridScaleY = 1.75f;
    public float gridMoveWait = .1f;
    private bool gridCanMove = true;
    public Tilemap tilemap;

    // Start is called before the first frame update
    new void Start() {
        base.Start();
        playerState = PlayerState.encounter;
        animator.SetBool("onEncounter", true);
    }

    new void Update() {
        base.Update();
        if (gridCanMove) {
            if (MoveCharacterGrid()) {
                StartCoroutine(WaitForGridMove());
            }
        }
    }

    bool MoveCharacterGrid() {
        deltaPosition.x = (int)System.Math.Round(deltaPosition.x, 0);
        deltaPosition.y = (int)System.Math.Round(deltaPosition.y, 0);
        deltaPosition.x *= gridScaleX;
        deltaPosition.y *= gridScaleY;
        Vector3Int tile = tilemap.WorldToCell(myRigidBody.position + deltaPosition);
        bool moved = false;
        if (!tilemap.HasTile(tile) && deltaPosition != Vector2.zero) {
            MoveCharacter();
            moved = true;
        }
        return moved;
    }

    private IEnumerator WaitForGridMove() {
        gridCanMove = false;
        yield return new WaitForSeconds(gridMoveWait);
        gridCanMove = true;
    }

}
