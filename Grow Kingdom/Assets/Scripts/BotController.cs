using UnityEngine;
using UnityEngine.UI;

public class BotController : MonoBehaviour
{
    [SerializeField]
    private GameMembersManager GameMembersManager;
    [SerializeField]
    private GameObject AttackButton;
    [SerializeField]
    private Text WarderAmountText;
    [SerializeField]
    private Text KnightAmountText;
    public string BotsName;
    [SerializeField]
    private PersonController[] PersonController;
    [SerializeField]
    private BotController[] OtherBotController;
    [SerializeField]
    private PlayerController PlayerController;
    [SerializeField]
    private AttackController AttackController;
    private int[] ClaimPersonPriority = new int[6];
    private int[] AttackPriority = new int[3];
    public int CountrywomanAmount;
    public int CraftsmanAmount;
    public int PriestAmount;
    public int WarderAmount;
    public int KnightAmount;
    public int NobleAmount;

    public int CurrentCoinsAmount;
    public int CurrentPossibilityPointsAmount = 5;

    private void Start()
    {
        if (PlayerController.KnightAmount <= WarderAmount)
            AttackButton.SetActive(false);

        WarderAmountText.text = WarderAmount.ToString();
        KnightAmountText.text = KnightAmount.ToString();
    }

    public void FindTheMostPriorityAction()
    {
        AttackPriority[0] = 0;
        AttackPriority[1] = 0;
        AttackPriority[2] = 0;

        for (int PersonNumber = 0; PersonNumber < 6;)
        {
            ClaimPersonPriority[PersonNumber] = FindClaimPersonPriority(PersonController[PersonNumber]) - PersonController[PersonNumber].CellNumber;
            PersonNumber++;
        }

        FindAttackPriority();

        for (int PersonNumber = 0; PersonNumber < 6;)
        {
            if (ClaimPersonPriority[PersonNumber] >= ClaimPersonPriority[1] && ClaimPersonPriority[PersonNumber] >= ClaimPersonPriority[2] && ClaimPersonPriority[PersonNumber] >= ClaimPersonPriority[3] &&
                ClaimPersonPriority[PersonNumber] >= ClaimPersonPriority[4] && ClaimPersonPriority[PersonNumber] >= ClaimPersonPriority[5] && ClaimPersonPriority[PersonNumber] >= AttackPriority[0] &&
                ClaimPersonPriority[PersonNumber] >= AttackPriority[1] && ClaimPersonPriority[PersonNumber] >= AttackPriority[2])
            {
                PersonController[PersonNumber].BotClaimPersonAction(this);
                
                break;
            }
            PersonNumber++;
        }

        for (int CastleNumber = 0; CastleNumber < 3;)
        {
            if (AttackPriority[CastleNumber] >= ClaimPersonPriority[1] && AttackPriority[CastleNumber] >= ClaimPersonPriority[2] && AttackPriority[CastleNumber] >= ClaimPersonPriority[3] &&
                AttackPriority[CastleNumber] >= ClaimPersonPriority[4] && AttackPriority[CastleNumber] >= ClaimPersonPriority[5] && AttackPriority[CastleNumber] >= AttackPriority[0] &&
                AttackPriority[CastleNumber] >= AttackPriority[1] && AttackPriority[CastleNumber] >= AttackPriority[2])
            {
                if (CastleNumber == 0)
                {
                    OtherBotController[0].CurrentCoinsAmount = OtherBotController[0].CurrentCoinsAmount / 2;
                    CurrentCoinsAmount += OtherBotController[0].CurrentCoinsAmount;
                }
                else if (CastleNumber == 1)
                {
                    OtherBotController[1].CurrentCoinsAmount = OtherBotController[0].CurrentCoinsAmount / 2;
                    CurrentCoinsAmount += OtherBotController[1].CurrentCoinsAmount;
                }
                else
                    AttackController.AttackPlayerAction(this);
                break;
            }
            CastleNumber++;
        }

        SpawnIncome();
    }

    public void SpawnIncome()
    {
        CurrentCoinsAmount = CurrentCoinsAmount + CountrywomanAmount * 2 + CraftsmanAmount * 2 + PriestAmount * 3 + NobleAmount * 5;
        CurrentPossibilityPointsAmount = CurrentPossibilityPointsAmount + CraftsmanAmount + NobleAmount;

        if (CurrentPossibilityPointsAmount > 6)
        {
            CurrentCoinsAmount = CurrentCoinsAmount + (CurrentPossibilityPointsAmount - 6);
            CurrentPossibilityPointsAmount = 6;
        }

        if (PlayerController.KnightAmount <= WarderAmount)
            AttackButton.SetActive(false);

        WarderAmountText.text = WarderAmount.ToString();
        KnightAmountText.text = KnightAmount.ToString();

        GameMembersManager.StartNextMembersAction();
    }

    private int FindClaimPersonPriority(PersonController SomePersonController)
    {
        if (CurrentPossibilityPointsAmount >= SomePersonController.CellNumber)
        {
            if (SomePersonController.ThisPersonTypeString == "A_countrywoman")
                return 10;
            else if (SomePersonController.ThisPersonTypeString == "B_craftsman")
                return 20;
            else if (SomePersonController.ThisPersonTypeString == "C_priest")
                return Random.Range(17, 26);
            else if (SomePersonController.ThisPersonTypeString == "D_warder")
            {
                if (OtherBotController[0].KnightAmount > WarderAmount || OtherBotController[1].KnightAmount > WarderAmount || PlayerController.KnightAmount > WarderAmount)
                    return 200;
                else
                    return Random.Range(10, 33);
            }
            else if (SomePersonController.ThisPersonTypeString == "E_knight")
                return Random.Range(15, 40);
            else
                return 35;
        }
        else
            return 0;
    }

    private void FindAttackPriority()
    {
        if (OtherBotController[0].WarderAmount < KnightAmount)
            AttackPriority[0] = OtherBotController[0].CurrentCoinsAmount;
        if (OtherBotController[1].WarderAmount < KnightAmount)
            AttackPriority[1] = OtherBotController[1].CurrentCoinsAmount;
        if (PlayerController.WarderAmount < KnightAmount)
            AttackPriority[2] = PlayerController.CurrentCoinsAmount;
    }
}
