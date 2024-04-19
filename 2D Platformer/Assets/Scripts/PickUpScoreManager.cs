using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpScoreManager : MonoBehaviour
{
    public int score; // stores score
    public TextMeshProUGUI scoreText; // ref visual text element change

   // rewards player
   public void IncreaseScore(int amount)
   {
        score += amount; // adds amount to score
        UpdateScoreText(); // update score ui
   }

   // penalizes player
   public void DecreaseScore(int amount)
   {
        score -= amount; // sub amount from score
        UpdateScoreText(); // update score ui
   }

   // update text
   public void UpdateScoreText()
   {
        scoreText.text = "COLLECTABLES: "+ score;
   }
}