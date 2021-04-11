using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileManager tileManager;
    public TileManager.Owner owner;

    private void OnMouseUp()
    {
        // Check for current player that is claiming ownership of this space
        owner = tileManager.CurrentPlayer;

        // Set the sprite color to represent the owner (Sword = Blue, Shield = Red)
        if (owner == TileManager.Owner.Sword)
            this.GetComponent<SpriteRenderer>().color = Color.blue;
        else if (owner == TileManager.Owner.Shield)
            this.GetComponent<SpriteRenderer>().color = Color.red;

        // Update to the next player in rotation
        tileManager.ChangePlayer();
    }
}
