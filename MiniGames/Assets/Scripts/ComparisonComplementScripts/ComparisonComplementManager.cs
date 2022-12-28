using UnityEngine;
using UnityEngine.UI;

public class ComparisonComplementManager : MonoBehaviour
{
    public string TimeLoseMessage;

    [SerializeField]
    private string LoseMessage;

    public Text FinishText;

    private int RightFingerprintOptionNumber = -1;

    private int TypeNumberTheFirstFingerprintOption = -1;
    private int TypeNumberTheSecondFingerprintOption = -1;
    private int TypeNumberTheThirdFingerprintOption = -1;

    [Header("RemainingTime")]
    private float StartAllTime = 3;
    [SerializeField]
    private Text RemainingTimeText;
    [SerializeField]
    private Image RemainingTimeBar;
    private float RemainingTime;

    [Header("FingerprintSprite")]
    [SerializeField]
    private int FingerprintMaxSpriteNumber;
    [SerializeField]
    private Sprite[] FingerprintSprites;
    [SerializeField]
    private Image ImageTheFirstFingerprintOption;
    [SerializeField]
    private Image ImageTheSecondFingerprintOption;
    [SerializeField]
    private Image ImageTheThirdFingerprintOption;
    [SerializeField]
    private Image ImageFindedFingerprint;

    private void Start()
    {
        RemainingTime = StartAllTime;

        switch (Random.Range(0, 3))
        {
            case 0:
                TypeNumberTheFirstFingerprintOption = PlayerPrefs.GetInt("FingerprintSpriteNumber");
                RightFingerprintOptionNumber = 0;
                break;
            case 1:
                TypeNumberTheSecondFingerprintOption = PlayerPrefs.GetInt("FingerprintSpriteNumber");
                RightFingerprintOptionNumber = 1;
                break;
            case 2:
                TypeNumberTheThirdFingerprintOption = PlayerPrefs.GetInt("FingerprintSpriteNumber");
                RightFingerprintOptionNumber = 2;
                break;
        }

        ImageFindedFingerprint.sprite = FingerprintSprites[PlayerPrefs.GetInt("FingerprintSpriteNumber")];

        if (TypeNumberTheFirstFingerprintOption == -1)
            TypeNumberTheFirstFingerprintOption = Random.Range(0, FingerprintMaxSpriteNumber + 1);

        if (TypeNumberTheSecondFingerprintOption == -1)
            TypeNumberTheSecondFingerprintOption = Random.Range(0, FingerprintMaxSpriteNumber + 1);

        if (TypeNumberTheThirdFingerprintOption == -1)
            TypeNumberTheThirdFingerprintOption = Random.Range(0, FingerprintMaxSpriteNumber + 1);

        ImageTheFirstFingerprintOption.sprite = FingerprintSprites[TypeNumberTheFirstFingerprintOption];
        ImageTheSecondFingerprintOption.sprite = FingerprintSprites[TypeNumberTheSecondFingerprintOption];
        ImageTheThirdFingerprintOption.sprite = FingerprintSprites[TypeNumberTheThirdFingerprintOption];
    }

    public void FingerprintOptionClick(int OptionNumber)
    {
        if (OptionNumber == RightFingerprintOptionNumber)
            Destroy(gameObject);
        else
        {
            FinishText.text = LoseMessage;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (RemainingTime >= 0)
        {
            RemainingTime -= Time.deltaTime;
            RemainingTimeText.text = Mathf.Round(RemainingTime).ToString() + " sec";
            RemainingTimeBar.fillAmount = RemainingTime / StartAllTime;
        }
        else
        {
            FinishText.text = TimeLoseMessage;
            Destroy(gameObject);
        }
    }
}
