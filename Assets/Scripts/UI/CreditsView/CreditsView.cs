using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsView : MonoBehaviour
{
    [SerializeField] private Text _creditsCount;
    [SerializeField] private Text _creditsCountMiniGame;

    public void SetCreditsText(float credits)
    {
        _creditsCount.text = credits.ToString();
    }

    public void SetMiniGameCredits(float credits)
    {
        _creditsCountMiniGame.text = credits.ToString();
    }
}
