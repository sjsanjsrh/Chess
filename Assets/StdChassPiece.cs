using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StdGame;

public class StdChassPiece : MonoBehaviour
{
    //define at component level
    public Faction faction;
    public TypeOfPiece type;
    public Vector3 anchor;

    //define at game level
    public StdChassTile tile;
    public Chess.Piece piece;

    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + anchor, 0.1f);
    }

    public void Init(StdChassTile tile, Chess.Piece piece)
    {
        this.tile = tile;
        this.piece = piece;
    }

    void Start()
    {
        if (piece == null) throw new Exception("piece is null must be call Init()", new NullReferenceException());
        if (tile == null) throw new Exception("tile is null must be call Init()", new NullReferenceException());
    }

    void Update()
    {
        
    }
}
