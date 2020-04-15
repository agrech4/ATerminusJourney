using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerControllerEncounter : PlayerController {

    public float gridScaleX = 1.75f;
    public float gridScaleY = 1.75f;
    public float gridMoveWait = .1f;
    public List<Transform> obstacles;
    public Tilemap boundsMap;
    public Tilemap movementOverlay;
    public TileBase tileBase;
    //public EncounterMenu encounterMenu;
    
    private bool gridCanMove = true;
    private readonly List<(Vector3Int tile, int dist)> movableTiles = new List<(Vector3Int tile, int dist)>();

    new void Awake() {
        base.Awake();
        playerState = PlayerState.waiting;
    }

    // Start is called before the first frame update
    new void Start() {
        base.Start();
        animator.SetBool("onEncounter", true);
    }

    new void Update() {
        base.Update();
        if (gridCanMove && playerState == PlayerState.moving) {
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
        Vector3Int tile = boundsMap.WorldToCell(playerRigidBody.position + deltaPosition);
        bool moved = false;
        if (TileEmpty(tile) && deltaPosition != Vector2.zero && movableTiles.Exists(x => x.tile == tile)) {
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

    private bool TileEmpty(Vector3Int tile) {
        if (boundsMap.HasTile(tile)) return false;
        foreach (Transform obstacle in obstacles) {
            if (boundsMap.WorldToCell(obstacle.position) == tile) return false;
        }
        return true;
    }

    public void SetMovableTiles(int maxDist) {
        movableTiles.Clear();
        if (maxDist <= 0) return;
        Queue<Vector3Int> tempTiles = new Queue<Vector3Int>();
        Queue<int> tempDists = new Queue<int>();
        Vector3Int startTile = boundsMap.WorldToCell(transform.position);
        tempTiles.Enqueue(startTile);
        tempDists.Enqueue(0);
        while (tempTiles.Count > 0) {
            Vector3Int baseTile = tempTiles.Dequeue();
            int dist = tempDists.Dequeue();
            if (dist != maxDist) {
                for (int x = baseTile.x-1; x <= baseTile.x+1; x++) {
                    for (int y = baseTile.y-1; y <= baseTile.y+1; y++) {
                        Vector3Int edgeTile = new Vector3Int(x, y, 0);
                        if (TileEmpty(edgeTile)) {
                            bool inTemp = tempTiles.Contains(edgeTile);
                            bool inFinal = movableTiles.Exists(_ => _.tile == edgeTile);
                            if (!inTemp && !inFinal) {
                                tempTiles.Enqueue(edgeTile);
                                tempDists.Enqueue(dist + 1);
                            }
                        }
                    }
                }
            }
            int index = movableTiles.FindIndex(_ => _.tile == baseTile);
            if (index < 0) {
                movableTiles.Add((baseTile, dist));
            } else {
                if (movableTiles[index].dist > dist) {
                    movableTiles.RemoveAt(index);
                    movableTiles.Add((baseTile, dist));
                }
            }
        }
    } 

    public void DisplayMovableTiles() {
        movementOverlay.ClearAllTiles();
        foreach ((Vector3Int tile, _) in movableTiles) {
            movementOverlay.SetTile(tile, tileBase);
        }
    }

    public void ResetMovableTiles() {
        movableTiles.Clear();
        movementOverlay.ClearAllTiles();
    }

    public int GetDistMoved() {
        Vector3Int tile = boundsMap.WorldToCell(transform.position);
        return movableTiles.Find(_ => _.tile == tile).dist;
    }
}
