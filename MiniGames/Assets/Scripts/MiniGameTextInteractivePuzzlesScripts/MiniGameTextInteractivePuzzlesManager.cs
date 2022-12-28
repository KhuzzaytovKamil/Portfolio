using UnityEngine;
using UnityEngine.UI;

public class MiniGameTextInteractivePuzzlesManager : MonoBehaviour
{
    private bool MiniGameIsFinish = false;

    [Header("FinishMiniGameScreen")]
    [SerializeField]
    private string TimeLoseMessage;
    [SerializeField]
    private string LoseMessage;
    [SerializeField]
    private string WinMessage;
    [SerializeField]
    private Text FinishText;
    [SerializeField]
    private GameObject FinishMiniGameScreen;

    [Header("RemainingTime")]
    [SerializeField]
    private float StartAllTime = 5;
    [SerializeField]
    private Text RemainingTimeText;
    [SerializeField]
    private Image RemainingTimeBar;
    private float RemainingTime = 10000000;

    public void StartGame() => RemainingTime = StartAllTime;

    private void Update()
    {
        if (RemainingTime >= 0 && MiniGameIsFinish == false)
        {
            RemainingTime -= Time.deltaTime;
            RemainingTimeText.text = Mathf.Round(RemainingTime).ToString() + " sec";
            RemainingTimeBar.fillAmount = RemainingTime / StartAllTime;
        }
        else if (MiniGameIsFinish == false)
        {
            FinishMiniGameScreen.SetActive(true);
            FinishText.text = TimeLoseMessage;
        }
    }

    public void VictoryAction()
    {
        MiniGameIsFinish = true;

        RemainingTime = 1000000;
        FinishMiniGameScreen.SetActive(true);
        FinishText.text = WinMessage;
    }

    public void LoseAction()
    {
        MiniGameIsFinish = true;

        RemainingTime = 1000000;
        FinishMiniGameScreen.SetActive(true);
        FinishText.text = LoseMessage;
    }
}
