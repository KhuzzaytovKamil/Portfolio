using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] AttackButton;
    [SerializeField]
    private BotController[] BotController;
    [SerializeField]
    private Text CountrywomanAmountText;
    [SerializeField]
    private GameMembersManager GameMembersManager;
    [SerializeField]
    private Text CraftsmanAmountText;
    [SerializeField]
    private Text PriestAmountText;
    [SerializeField]
    private Text WarderAmountText;
    [SerializeField]
    private Text KnightAmountText;
    [SerializeField]
    private Text NobleAmountText;
    public int CountrywomanAmount;
    public int CraftsmanAmount;
    public int PriestAmount;
    public int WarderAmount;
    public int KnightAmount;
    public int NobleAmount;

    public int CurrentCoinsAmount;
    public int CurrentPossibilityPointsAmount = 5;

    [SerializeField]
    private Text CurrentCoinsAmountText;
    [SerializeField]
    private Text CurrentPossibilityPointsAmountText;

    private void Start()
    {
        UpdamePersonsData();
        UpdateAssetsAmount();
    }

    public void UpdamePersonsData()
    {
        CountrywomanAmountText.text = CountrywomanAmount.ToString();
        CraftsmanAmountText.text = CraftsmanAmount.ToString();
        PriestAmountText.text = PriestAmount.ToString();
        WarderAmountText.text = WarderAmount.ToString();
        KnightAmountText.text = KnightAmount.ToString();
        NobleAmountText.text = NobleAmount.ToString();
    }

    public void SpawnIncome()
    {
        CurrentCoinsAmount += CountrywomanAmount * 2 + CraftsmanAmount * 2 + PriestAmount * 3 + NobleAmount * 5;
        CurrentPossibilityPointsAmount = CurrentPossibilityPointsAmount + CraftsmanAmount + NobleAmount;

        if (BotController[0].WarderAmount < KnightAmount)
            AttackButton[0].SetActive(true);

        if (BotController[1].WarderAmount < KnightAmount)
            AttackButton[1].SetActive(true);

        if (BotController[2].WarderAmount < KnightAmount)
            AttackButton[2].SetActive(true);

        UpdateAssetsAmount();
        GameMembersManager.StartNextMembersAction();
    }

    private void UpdateAssetsAmount()
    {
        if (CurrentPossibilityPointsAmount > 6)
        {
            CurrentCoinsAmount = CurrentCoinsAmount + (CurrentPossibilityPointsAmount - 6);
            CurrentPossibilityPointsAmount = 6;
        }

        CurrentCoinsAmountText.text = CurrentCoinsAmount.ToString();

        if (CurrentPossibilityPointsAmount != 6)
            CurrentPossibilityPointsAmountText.text = CurrentPossibilityPointsAmount.ToString();
        else
            CurrentPossibilityPointsAmountText.text = CurrentPossibilityPointsAmount.ToString() + "(max)";


    }
}
