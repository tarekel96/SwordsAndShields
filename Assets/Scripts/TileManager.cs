using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    public Owner CurrentPlayer;
    public Tile[] Tiles = new Tile[9];

    private int Score_Sword = 0;
    private int Score_Shield = 0;

    public Text TextScoreSword;
    public Text TextScoreShield;

    public enum Owner
    {
        None,
        Sword,
        Shield
    }

    private bool won;

    // Start is called before the first frame update
    void Start()
    {
        TextScoreShield.text = Score_Shield.ToString();
        TextScoreSword.text = Score_Sword.ToString();
        won = false;
        CurrentPlayer = Owner.Sword;
    }

    public IEnumerator resetTiles()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < Tiles.Length; ++i)
        {
            Tiles[i].ResetTile();
        }
    }

    public void ChangePlayer()
    {
        if (CheckForWinner())
            return;

        if (CurrentPlayer == Owner.Sword)
            CurrentPlayer = Owner.Shield;
        else
            CurrentPlayer = Owner.Sword;
    }

    public bool CheckForWinner()
    {
        // first row win
        if (Tiles[0].owner == CurrentPlayer && Tiles[1].owner == CurrentPlayer && Tiles[2].owner == CurrentPlayer)
            won = true;
        // second row win
        else if (Tiles[3].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer)
            won = true;
        // last row in
        else if (Tiles[6].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        // first col win
        else if (Tiles[0].owner == CurrentPlayer && Tiles[3].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        // second col win
        else if (Tiles[1].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer)
            won = true;
        // last col win
        else if (Tiles[2].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        // top left -> bottom right win
        else if (Tiles[0].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        // top right -> bottom left win
        else if (Tiles[2].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;

        if (won)
        {
            Debug.Log("Winner: " + CurrentPlayer);
            if(CurrentPlayer == Owner.Sword)
            {
                Score_Sword++;
                TextScoreSword.text = Score_Sword.ToString();
            }
            else if(CurrentPlayer == Owner.Shield)
            {
                Score_Shield++;
                TextScoreShield.text = Score_Shield.ToString();
            }
            StartCoroutine(resetTiles());
            won = false;
            return true;
        }

        return false;
    }
}
