using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    enum elements { Scissor = 1, Paper, Rock }

    private int playerChoose = -1;
    private int botChoose = -1;

    private bool playersTurn = true;

    public TextMeshProUGUI WinnerText;

    public Sprite paperImage, rockImage, scissorImage;

    public GameObject botChooseImage;

    // Update is called once per frame
    void Update()
    {
        if (playersTurn && playerChoose == -1) return;

        BotChoose();
        CheckWinner();
        playerChoose = -1;
        playersTurn = true;
    }

    void CheckWinner()
    {
        if (playerChoose == botChoose)
        {
            WinnerText.text = "Draw";
        }
        else if ((playerChoose == (int)elements.Paper && botChoose == (int)elements.Rock) ||
                 (playerChoose == (int)elements.Rock && botChoose == (int)elements.Scissor) ||
                 (playerChoose == (int)elements.Scissor && botChoose == (int)elements.Paper))
        {
            WinnerText.text = "Player Wins";
        }
        else
        {
            WinnerText.text = "Bot Wins";
        }
    }

    public void PlayerChoose(int Choose)
    {
        playerChoose = Choose;
        playersTurn = false;
    }

    public void BotChoose()
    {
        botChoose = Random.Range(1, 3);

        if (botChoose == 1)
        {
            botChooseImage.GetComponent<RawImage>().texture = scissorImage.texture;
        }
        else if (botChoose == 2)
        {
            botChooseImage.GetComponent<RawImage>().texture = paperImage.texture;
        }
        else
        {
            botChooseImage.GetComponent<RawImage>().texture = rockImage.texture;
        }
    }

}
