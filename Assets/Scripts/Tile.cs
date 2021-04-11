using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tile : MonoBehaviour
{
    public TileManager tileManager;
    public TileManager.Owner owner;
    public Sprite Sprite_Square;
    public Sprite Shield_Sprite;
    public Sprite Sprite_Sword;
    public Sprite OG_Sprite;

    public void ResetTile()
    {
        this.GetComponent<SpriteRenderer>().sprite = OG_Sprite;
        owner = TileManager.Owner.None;
    }

    void Start()
    {
        OG_Sprite = this.GetComponent<SpriteRenderer>().sprite;
    }

    private void OnMouseUp()
    {
        // Check for current player that is claiming ownership of this space
        owner = tileManager.CurrentPlayer;

        // Set the sprite color to represent the owner (Sword = Blue, Shield = Red)
        if (owner == TileManager.Owner.Sword)
        {
            this.GetComponent<SpriteRenderer>().sprite = Sprite_Sword;
        }
        else if (owner == TileManager.Owner.Shield)
        {
            this.GetComponent<SpriteRenderer>().sprite = Shield_Sprite;
        }
            // Update to the next player in rotation
        tileManager.ChangePlayer();
    }
}
