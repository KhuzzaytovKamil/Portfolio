using UnityEngine;
using UnityEngine.UI;

public class AttackController : MonoBehaviour
{
    [SerializeField]
    private Text CurrentPlayerCoinsAmountText;
    [SerializeField]
    private PlayerController PlayerController;
    [SerializeField]
    private GameObject AttackScreen;
    [SerializeField]
    private GameObject WinAttackHeader;
    [SerializeField]
    private GameObject LoseAttackHeader;
    [SerializeField]
    private Text AttackScreenMainText;
    [SerializeField]
    private Text AttackScreenButtonText;
    private BotController TemporaryBotControllerVar;

    public void AttackBotAction(BotController BotController) //win
    {
        BotController.CurrentCoinsAmount = BotController.CurrentCoinsAmount / 2;
        PlayerController.CurrentCoinsAmount += BotController.CurrentCoinsAmount;

        AttackScreen.SetActive(true);
        WinAttackHeader.SetActive(true);
        LoseAttackHeader.SetActive(false);
        AttackScreenMainText.text = "Благодаря успешной атаке вы получили " + BotController.CurrentCoinsAmount.ToString() + " монеты.";
        AttackScreenButtonText.text = "Забрать " + BotController.CurrentCoinsAmount.ToString();    
    }

    public void AttackPlayerAction(BotController BotController) //lose
    {
        PlayerController.CurrentCoinsAmount = PlayerController.CurrentCoinsAmount / 2;
        BotController.CurrentCoinsAmount += PlayerController.CurrentCoinsAmount;
        CurrentPlayerCoinsAmountText.text = PlayerController.CurrentCoinsAmount.ToString();

        AttackScreen.SetActive(true);
        LoseAttackHeader.SetActive(true);
        WinAttackHeader.SetActive(false);
        AttackScreenMainText.text = BotController.BotsName + "ограбил тебя на " + PlayerController.CurrentCoinsAmount.ToString() + " монеты.";
        AttackScreenButtonText.text = "Нужно больше защитников!";
        TemporaryBotControllerVar = BotController;
    }

    public void CoinsClaimed() => PlayerController.SpawnIncome();
}
