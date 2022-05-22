using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StdChassTile : MonoBehaviour
{
    //define at component level
    public GameObject visual;
    public Color selectedColor = Color.cyan;
    public Color hoveredColor = Color.white;
    public Color moveableColor = Color.green;

    //define at game level
    public enum State
    {
        None,
        Selected,
        Moveable
    }
    public State state = State.None;
    StdChassBoard board_script;
    StdChassPiece piece_script;
    private ButtonEvent buttonEvent;
    private int x, y;
    private bool seletable = false;


    private void SetOutline(bool value)
    {
        for (int i = 0; i < visual.transform.childCount; i++)
        {
            visual.transform.GetChild(i).gameObject.SetActive(value);
        }
        visual.GetComponent<SpriteRenderer>().enabled = value;
    }
    private void SetColor(Color value)
    {
        visual.GetComponent<SpriteRenderer>().color = value;
    }

    public void SetNoneVisual()
    {
        SetOutline(false);
    }
    public void SetSelectedVisual()
    {
        SetColor(selectedColor);
        SetOutline(true);
    }
    public void SetHoveredVisual()
    {
        SetColor(hoveredColor);
        SetOutline(true);
    }
    public void SetMoveableVisual()
    {
        SetColor(moveableColor);
        SetOutline(true);
    }
    public void SetStateVisual()
    {
        switch(state)
        {
            case State.None:
                SetNoneVisual();
                break;
            case State.Selected:
                SetSelectedVisual();
                break;
            case State.Moveable:
                SetMoveableVisual();
                break;
        }
    }

    private void ChangeButtonState()
    {
        if (seletable)
        {
            if (buttonEvent.Pressed)
            {
                Chess.MoveMap map = piece_script?.piece.moveMap;
                if (map != null) // if exist pice on this tile
                {
                    foreach (var tile in board_script.GetTile())
                    {
                        tile.GetXY(out int x, out int y);
                        if ((map.map[x, y] & Chess.MoveMap.Status.MoveAble) != 0)
                        {
                            tile.state = State.Moveable;
                            tile.seletable = true;
                            tile.SetStateVisual();
                        }
                        else
                        {
                            tile.state = State.None;
                            tile.seletable &= tile.state != State.Moveable;
                            tile.SetStateVisual();
                        }
                    }

                    state = State.Selected;
                    SetSelectedVisual();
                }         
            }
            else
            {
                if (buttonEvent.Hover)
                {
                    SetHoveredVisual();
                }
                else
                {
                    SetStateVisual();
                }
            }
        }
        else
        {
            state = State.None;
            seletable &= state != State.Moveable;
        }
    }
   

    public void GetXY(out int x, out int y)
    {
        x = this.x;
        y = this.y;
    }
    private void SetXY(int x, int y)
    {
        this.x = x;
        this.y = y;

        name = "Tile_" + x + "_" + y;
    }

    public void Init(StdChassBoard board_script, int x, int y,Vector3 position, Vector3 scale)
    {
        this.board_script = board_script;
        SetXY(x, y);
        transform.position += position;
        visual.transform.localScale = Vector3.Scale(scale, transform.localScale);
    }

    void Start()
    {
        buttonEvent = GetComponent<ButtonEvent>();
        buttonEvent.settedHover += new EventHandler(SettedHover);
        buttonEvent.resettedHover += new EventHandler(ResettedHover);
        buttonEvent.settedPressed += new EventHandler(SettedPressed);
        buttonEvent.settedRelesed += new EventHandler(SettedRelesed);
    }
    
    public void SetPiece()
    {
        var piece = board_script.game.GetCurrentPice(x, y);
        if (piece != null)
        {
            var piece_obj = board_script.PieceToGameObject(piece);
            var piece_ins = Instantiate(piece_obj, transform, false);
            piece_script = piece_ins.GetComponent<StdChassPiece>();
            piece_script.Init(this, piece);
            seletable = true;
        }
    }

    void SettedHover(object sender, EventArgs e)
    {
        ChangeButtonState();
    }
    void ResettedHover(object sender, EventArgs e)
    {
        ChangeButtonState();
    }
    void SettedPressed(object sender, EventArgs e)
    {
        ChangeButtonState();
    }
    void SettedRelesed(object sender, EventArgs e)
    {
        ChangeButtonState();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !buttonEvent.Hover)
        {
            buttonEvent.Pressed = false;
        }
    }
}
