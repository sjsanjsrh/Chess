using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StdChassBoard : MonoBehaviour
{
    //define at component level
    [System.Serializable]
    public class PieceObjects
    {
        public GameObject Pawn_B;
        public GameObject Pawn_W;
    }
    public PieceObjects pieceObjects;
    public GameObject tile;
    public Vector2 start, end;
    public float hight;

    //define at game level
    //public readonly StandardGame game = new StandardGame();

    private Vector3[,] anchors;
    private StdChassTile[,] m_tileMap;

    //public GameObject PieceToGameObject(Chess.Piece piece)
    //{
    //    if (piece is Pawn)
    //        return (Faction)piece.owner == Faction.Black ?
    //            pieceObjects.Pawn_B : pieceObjects.Pawn_W;
    //    else
    //        return null;
    //}

    public StdChassTile GetTile(int x, int y)
    {
        return m_tileMap[x, y];
    }
    public StdChassTile[,] GetTile()
    {
        return m_tileMap;
    }

    void ComputingAnchors()
    {
        int w, h;
        Vector2 c, s;
        Vector2 vlen = end - start;

        // Todo: Get board size
        w = 8;
        h = 8;

        s.x = vlen.x / w;
        s.y = vlen.y / h;
        c = start + s / 2;
        anchors = new Vector3[w, h];
        for (int x = 0; x < w; x++)
        {
            for (int y = 0; y < h; y++)
            {
                anchors[x, y] = new Vector3(c.x + x * s.x, hight, c.y + y * s.y);
            }
        }
    }

    private void Awake()
    {
        // m_tileMap = new StdChassTile[game.BOARD_W, game.BOARD_H];
    }

    void Start()
    {
        ComputingAnchors();
        //game.Init();
        CreateTileObject();
    }

    private void CreateTileObject()
    {
        //var board = game.GetCurrentBoard();
        //Vector2 vlen = end - start;
        //var scale = new Vector3(1, 1, 1);
        //scale.x *= Mathf.Abs(vlen.x) / game.BOARD_W;
        //scale.y *= Mathf.Abs(vlen.y) / game.BOARD_H;
        //for (int y = 0; y < game.BOARD_W; y++)
        //{
        //    for (int x = 0; x < game.BOARD_H; x++)
        //    {
        //        var tile_ins = Instantiate(tile, transform, false);
        //        var tile_script = tile_ins.GetComponent<StdChassTile>();
        //        m_tileMap[x, y] = tile_script;
        //        tile_script.Init(this, x, y, anchors[x, y], scale);
        //        tile_script.SetPiece();
        //    }
        //}
    }

    void OnDrawGizmos()
    {
        ComputingAnchors();
        Gizmos.color = Color.yellow;
        foreach(var anchor in anchors)
        {
            Gizmos.DrawSphere(transform.position + anchor, 0.1f);
        }
    }

    void Update()
    {
        
    }
}
