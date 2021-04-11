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

    public Button ResetButton;
    public Button QuitButton;
    private bool ShowButtons = false;

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
        // hide buttons on start
        ResetButton.GetComponent<CanvasGroup>().alpha = 0;
        QuitButton.GetComponent<CanvasGroup>().alpha = 0;
        // assign score to score text
        TextScoreShield.text = Score_Shield.ToString();
        TextScoreSword.text = Score_Sword.ToString();
        // init won to false and player to sword
        won = false;
        CurrentPlayer = Owner.Sword;
    }

    // resets the tiles of the tiles array
    public void resetTiles()
    {
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

        // logic after a player wins
        if (won)
        {
            // buttons are to be shown
            ShowButtons = true;
            if (ShowButtons)
            {
                ResetButton.GetComponent<CanvasGroup>().alpha = 1;
                QuitButton.GetComponent<CanvasGroup>().alpha = 1;
            }
            Debug.Log("Winner: " + CurrentPlayer);
            // increment appropriate score counter
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
            Button resetButton = ResetButton.GetComponent<UnityEngine.UI.Button>();
            resetButton.onClick.AddListener(() => {
                resetTiles();
                won = false;
            });
            //// reset the tiles
            //StartCoroutine(resetTiles());
            //won = false;
            return true;
        }

        return false;
    }
}
