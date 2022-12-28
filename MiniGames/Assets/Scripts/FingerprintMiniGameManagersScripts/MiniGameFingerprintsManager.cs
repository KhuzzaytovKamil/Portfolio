using UnityEngine;
using UnityEngine.UI;

public class MiniGameFingerprintsManager : MonoBehaviour
{
    public GameMode ThisGameMode;
    public enum GameMode { LoupeMode, StandardMode }

    public float FinishFingerprintAmount;
    public float FindedFingerprintAmount;

    [SerializeField]
    private Image GameProgressBar;

    [Space(20)]

    [Header("FinishMiniGameScreen")]
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
    public float RemainingTime;

    [Header("FingerprintSprite")]
    [SerializeField]
    private int FingerprintMaxSpriteNumber;
    public int FingerprintThisSpriteNumber;
    [SerializeField]
    private Sprite[] FingerprintSprites;

    [Header("LostItemGeneratorSettings")]
    [SerializeField]
    private GameObject LostItemParent;
    private GameObject ThisLostItem;
    [SerializeField]
    private GameObject[] LostItem;
    [SerializeField]
    private int LostItemMaxNumber;

    [Header("ComparisonComplement")]
    [SerializeField]
    private bool ComparisonComplement;
    [SerializeField]
    private GameObject ComparisonComplementSystem;
    private GameObject ThisComparisonComplementSystem;
    [SerializeField]
    private Transform MainMiniGameParent;

    public void StartGame() => RemainingTime = StartAllTime;


    private void Start()
    {
        ThisLostItem = Instantiate(LostItem[Random.Range(0, LostItemMaxNumber + 1)], LostItemParent.transform.position, new Quaternion(0, 0, 0, 0));
        ThisLostItem.transform.SetParent(LostItemParent.transform);
        ThisLostItem.transform.localScale = new Vector3(1, 1, 1);

        FingerprintThisSpriteNumber = Random.Range(0, FingerprintMaxSpriteNumber + 1);
        PlayerPrefs.SetInt("FingerprintSpriteNumber", FingerprintThisSpriteNumber);

        ThisLostItem.GetComponent<FingerprintGeneratorController>().MiniGameFingerprintsManager = this;
    }

    private void Update()
    {
        if (FindedFingerprintAmount >= FinishFingerprintAmount)
        {
            FinishMiniGameScreen.SetActive(true);
            FinishText.text = WinMessage;
            if (ComparisonComplement)
            {
                ComparisonComplement = false;

                ThisComparisonComplementSystem = Instantiate(ComparisonComplementSystem, gameObject.transform.position, new Quaternion(0, 0, 0, 0));

                ThisComparisonComplementSystem.transform.SetParent(MainMiniGameParent);
                ThisComparisonComplementSystem.transform.localScale = new Vector3(1, 1, 1);
                ThisComparisonComplementSystem.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                ThisComparisonComplementSystem.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);

                ThisComparisonComplementSystem.GetComponent<ComparisonComplementManager>().FinishText = FinishText;
                ThisComparisonComplementSystem.GetComponent<ComparisonComplementManager>().TimeLoseMessage = LoseMessage;

                Destroy(gameObject);
            }
        }
        else
        {
            if (RemainingTime >= 0)
            {
                RemainingTime -= Time.deltaTime;
                RemainingTimeText.text = Mathf.Round(RemainingTime).ToString() + " sec";
                RemainingTimeBar.fillAmount = RemainingTime / StartAllTime;
            }
            else
            {
                FinishMiniGameScreen.SetActive(true);
                FinishText.text = LoseMessage;
            }

            GameProgressBar.fillAmount = FindedFingerprintAmount / FinishFingerprintAmount;
        }
    }
}
