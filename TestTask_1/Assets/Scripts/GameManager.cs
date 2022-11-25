using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameSettings GameSettings;
    int NumberCoins;
    int NumberSpikes;
    [SerializeField]
    CellController[] CellController;
    [SerializeField]
    int NumberCell;
    int CurrentCellNumber;

    public static event Action CreateEntity;

    [SerializeField]
    GameObject WinScreen;
    int ReceivedNumberCoins;
    [SerializeField]
    Text ReceivedNumberCoinsText;

    void Start()
    {
        NumberCoins = GameSettings.NumberCoins;
        NumberSpikes = GameSettings.NumberSpikes;

        while (true)
        {
            if (NumberCoins != 0)
            {
                while (true)
                {
                    CurrentCellNumber = UnityEngine.Random.Range(0, NumberCell);
                    if (CellController[CurrentCellNumber].EntityType == "nothing")
                        break;
                }
                CellController[CurrentCellNumber].EntityType = "coin";
                NumberCoins--;
            }
            else if (NumberSpikes != 0)
            {
                while (true)
                {
                    CurrentCellNumber = UnityEngine.Random.Range(0, NumberCell);
                    if (CellController[CurrentCellNumber].EntityType == "nothing")
                        break;
                }
                CellController[CurrentCellNumber].EntityType = "spike";
                NumberSpikes--;
            }
            else
                break;
        }

        CreateEntity.Invoke();
    }

    public string GetCoin()
    {
        ReceivedNumberCoins++;
        ReceivedNumberCoinsText.text = ReceivedNumberCoins.ToString();

        if (ReceivedNumberCoins >= GameSettings.NumberCoins)
        {
            WinScreen.SetActive(true);
            return ("coins collected");
        }
        else
            return ("coins not collected");
    }

    public void Restart() => SceneManager.LoadScene("GameScene");
}
