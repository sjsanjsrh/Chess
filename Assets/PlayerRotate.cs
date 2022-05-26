using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float speed = 0.1f;
    public float rotate_speed = 0.1f;
    public StdChassBoard chassBoard;
    //public StdGame.Faction currentPlayer = StdGame.Faction.Black;
    public Transform target_tr;

    void Update()
    {
        //var board = chassBoard.game.GetCurrentBoard();
        //currentPlayer = (StdGame.Faction)board.currentPlayer;
        //var rotate_y = currentPlayer == StdGame.Faction.Black
        //    ? 180
        //    : 0;
        //var rotate = Quaternion.Euler(0, rotate_y, 0);
        //transform.position = Vector3.Lerp(transform.position, target_tr.position, speed);
        //transform.rotation = Quaternion.Lerp(transform.rotation, rotate* target_tr.rotation, rotate_speed);
    }
}
