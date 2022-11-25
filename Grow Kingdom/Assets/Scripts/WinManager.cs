using UnityEngine;

public class WinManager : MonoBehaviour
{
    [SerializeField]
    private GamePurpose ThisGamePurpose;
    [SerializeField]
    private int Amount;

    [Space(50)]

    [SerializeField]
    private int LvlNumber;
    [SerializeField]
    private PlayerController PlayerController;
    [SerializeField]
    private GameObject WinScreen;
    [SerializeField]
    private GameMembersManager GameMembersManager;
    public int TheFirstBotLoseProtected;
    public int TheSecondBotLoseProtected;
    public int TheThirdBotLoseProtected;

    private enum GamePurpose { Coins, Countrywoman, Craftsman, Priest, Warder, Knight, Noble, AttackAll }

    public void CheckProgress()
    {
        if (ThisGamePurpose == GamePurpose.Coins)
        {
            if (PlayerController.CurrentCoinsAmount >= Amount)
            {
                WinScreen.SetActive(true);
                WinAction();
            }
            else
                GameMembersManager.StartCoroutineDelayFinished();
        }
        else if (ThisGamePurpose == GamePurpose.Countrywoman)
        {
            if (PlayerController.CountrywomanAmount >= Amount)
            {
                WinScreen.SetActive(true);
                WinAction();
            }
            else
                GameMembersManager.StartCoroutineDelayFinished();
        }
        else if (ThisGamePurpose == GamePurpose.Craftsman)
        {
            if (PlayerController.CraftsmanAmount >= Amount)
            {
                WinScreen.SetActive(true);
                WinAction();
            }
            else
                GameMembersManager.StartCoroutineDelayFinished();
        }
        else if (ThisGamePurpose == GamePurpose.Priest)
        {
            if (PlayerController.PriestAmount >= Amount)
            {
                WinScreen.SetActive(true);
                WinAction();
            }
            else
                GameMembersManager.StartCoroutineDelayFinished();
        }
        else if (ThisGamePurpose == GamePurpose.Warder)
        {
            if (PlayerController.WarderAmount >= Amount)
            {
                WinScreen.SetActive(true);
                WinAction();
            }
            else
                GameMembersManager.StartCoroutineDelayFinished();
        }
        else if (ThisGamePurpose == GamePurpose.Knight)
        {
            if (PlayerController.KnightAmount >= Amount)
            {
                WinScreen.SetActive(true);
                WinAction();
            }
            else
                GameMembersManager.StartCoroutineDelayFinished();
        }
        else if (ThisGamePurpose == GamePurpose.Noble)
        {
            if (PlayerController.NobleAmount >= Amount)
            {
                WinScreen.SetActive(true);
                WinAction();
            }
            else
                GameMembersManager.StartCoroutineDelayFinished();
        }
        else if (ThisGamePurpose == GamePurpose.AttackAll)
        {
            if (TheFirstBotLoseProtected >= Amount && TheSecondBotLoseProtected >= Amount && TheThirdBotLoseProtected >= Amount)
            {
                WinScreen.SetActive(true);
                WinAction();
            }
            else
                GameMembersManager.StartCoroutineDelayFinished();
        }
    }

    private void WinAction()
    {
        if (PlayerPrefs.GetInt("LastCompletedLvl") < LvlNumber)
            PlayerPrefs.SetInt("LastCompletedLvl", LvlNumber);
    }
}
