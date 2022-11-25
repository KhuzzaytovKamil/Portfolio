using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PersonController : MonoBehaviour
{
    [SerializeField]
    private PersonsDataManager PersonsDataManager;
    [SerializeField]
    private PersonsSystemManager PersonsSystemManager;
    [SerializeField]
    private PlayerController PlayerController;
    private PersonType ThisPersonType;
    public string ThisPersonTypeString;
    public int CellNumber;
    private int PossibilityPointsStockAmount;
    [SerializeField]
    private Text PossibilityPointsStockAmountText;
    private float DecreaseProgressTime = 0.1f;
    private float MoveProgressTime = 0.25f;
    [SerializeField]
    private Text CurrentPlayerPossibilityPointsAmountText;

    private enum PersonType { A_countrywoman, B_craftsman, C_priest, D_warder, E_knight, F_noble}

    private void Start()
    {
        ChooseNewPersonType();

        PersonsSystemManager.UpdatePersonsSystem += UpdamePersonsData;
    }

    private void OnDestroy() => PersonsSystemManager.UpdatePersonsSystem -= UpdamePersonsData;

    public void ChooseNewPersonType()
    {
        switch(Random.Range(0, 6))
        {
            case 0:
                ThisPersonType = PersonType.A_countrywoman;
                ThisPersonTypeString = "A_countrywoman";
                gameObject.GetComponent<Image>().sprite = PersonsDataManager.PersonSprite[0];
                break;
            case 1:
                ThisPersonType = PersonType.B_craftsman;
                ThisPersonTypeString = "B_craftsman";
                gameObject.GetComponent<Image>().sprite = PersonsDataManager.PersonSprite[1];
                break;
            case 2:
                ThisPersonType = PersonType.C_priest;
                ThisPersonTypeString = "C_priest";
                gameObject.GetComponent<Image>().sprite = PersonsDataManager.PersonSprite[2];
                break;
            case 3:
                ThisPersonType = PersonType.D_warder;
                ThisPersonTypeString = "D_warder";
                gameObject.GetComponent<Image>().sprite = PersonsDataManager.PersonSprite[3];
                break;
            case 4:
                ThisPersonType = PersonType.E_knight;
                ThisPersonTypeString = "E_knight";
                gameObject.GetComponent<Image>().sprite = PersonsDataManager.PersonSprite[4];
                break;
            case 5:
                ThisPersonType = PersonType.F_noble;
                ThisPersonTypeString = "F_noble";
                gameObject.GetComponent<Image>().sprite = PersonsDataManager.PersonSprite[5];
                break;
        }
    }

    public void OnClickAction()
    {
        if (PlayerController.CurrentPossibilityPointsAmount >= CellNumber)
        {
            PlayerController.CurrentPossibilityPointsAmount -= CellNumber;
            PlayerController.CurrentPossibilityPointsAmount += PossibilityPointsStockAmount;
            SpawnPersonInPlayersCastle();
            PlayerController.UpdamePersonsData();
            PlayerController.SpawnIncome();

            PersonsSystemManager.LastTakenPersonNumber = CellNumber;
            PossibilityPointsStockAmount = 0;
            CellNumber = 6;
            StartCoroutine(DecreasePerson());
        }
        else
        {
            CurrentPlayerPossibilityPointsAmountText.color = new Color(1, 0, 0, 1);
            StartCoroutine(SetWhiteColorToTextWithDelay());
        }
    }

    public void BotClaimPersonAction(BotController BotController)
    {
        BotController.CurrentPossibilityPointsAmount -= CellNumber;
        BotController.CurrentPossibilityPointsAmount += PossibilityPointsStockAmount;
        SpawnPersonInBotsCastle(BotController);

        PersonsSystemManager.LastTakenPersonNumber = CellNumber;
        PossibilityPointsStockAmount = 0;
        CellNumber = 6;
        StartCoroutine(DecreasePerson());
    }

    private void SpawnPersonInPlayersCastle()
    {
        if (ThisPersonType == PersonType.A_countrywoman)
            PlayerController.CountrywomanAmount++;
        else if (ThisPersonType == PersonType.B_craftsman)
            PlayerController.CraftsmanAmount++;
        else if (ThisPersonType == PersonType.C_priest)
            PlayerController.PriestAmount++;
        else if (ThisPersonType == PersonType.D_warder)
            PlayerController.WarderAmount++;
        else if (ThisPersonType == PersonType.E_knight)
            PlayerController.KnightAmount++;
        else if (ThisPersonType == PersonType.F_noble)
            PlayerController.NobleAmount++;
    }

    private void SpawnPersonInBotsCastle(BotController BotController)
    {
        if (ThisPersonType == PersonType.A_countrywoman)
            BotController.CountrywomanAmount++;
        else if (ThisPersonType == PersonType.B_craftsman)
            BotController.CraftsmanAmount++;
        else if (ThisPersonType == PersonType.C_priest)
            BotController.PriestAmount++;
        else if (ThisPersonType == PersonType.D_warder)
            BotController.WarderAmount++;
        else if (ThisPersonType == PersonType.E_knight)
            BotController.KnightAmount++;
        else if (ThisPersonType == PersonType.F_noble)
            BotController.NobleAmount++;
    }

    private void UpdamePersonsData()
    {
        if (PersonsSystemManager.LastTakenPersonNumber < CellNumber)
        {
            CellNumber--;
            StartCoroutine(MovePerson());
        }
        else if (PersonsSystemManager.LastTakenPersonNumber != CellNumber)
            PossibilityPointsStockAmount++;

        PossibilityPointsStockAmountText.text = PossibilityPointsStockAmount.ToString();
    }

    private IEnumerator DecreasePerson()
    {
        yield return new WaitForFixedUpdate();
        if (DecreaseProgressTime >= 0)
        {
            transform.localScale = new Vector3(gameObject.transform.localScale.x - 4 * Time.deltaTime, gameObject.transform.localScale.y - 4 * Time.deltaTime, gameObject.transform.localScale.z - 4 * Time.deltaTime);
            DecreaseProgressTime -= Time.deltaTime;
            StartCoroutine(DecreasePerson());
        }
        else
        {
            DecreaseProgressTime = 0.1f;
            transform.localScale = new Vector3(0, 0, 0);
            ScaleSwitched();
        }
    }

    private IEnumerator MovePerson()
    {
        yield return new WaitForFixedUpdate();
        if (MoveProgressTime >= 0)
        {
            gameObject.transform.position -= new Vector3((PersonsSystemManager.PersonsPositionPoint[1].transform.position.x - PersonsSystemManager.PersonsPositionPoint[0].transform.position.x) * 4 * Time.deltaTime, 0, 0);
            MoveProgressTime -= Time.deltaTime;
            StartCoroutine(MovePerson());
        }
        else
        {
            transform.position = PersonsSystemManager.PersonsPositionPoint[CellNumber].transform.position;
            MoveProgressTime = 0.25f;
        }
    }

    private IEnumerator SetWhiteColorToTextWithDelay()
    {
        yield return new WaitForSeconds(0.3f);
        CurrentPlayerPossibilityPointsAmountText.color = new Color(1, 1, 1, 1);
    }

    private void ScaleSwitched()
    {
        ChooseNewPersonType();
        transform.localScale = new Vector3(1, 1, 1);
        transform.position = PersonsSystemManager.PersonsPositionPoint[6].transform.position;
        PersonsSystemManager.UpdatePersonsPositions();
    }
}
