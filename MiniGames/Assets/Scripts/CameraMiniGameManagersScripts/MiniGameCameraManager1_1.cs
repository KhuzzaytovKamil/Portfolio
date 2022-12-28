using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MiniGameCameraManager1_1 : MonoBehaviour
{
    private bool MiniGameIsFinish = false;

    [Header("FocusBarGapWidth")]
    private float FocusBarGapWidth;
    [SerializeField]
    private GameObject FocusBarGapLeftPoint;
    [SerializeField]
    private GameObject FocusBarGapRightPoint;

    [Header("Photo")]
    [SerializeField]
    private MiniGameCameraDataManager MiniGameCameraDataManager;
    [SerializeField]
    private RawImage MainGamePhotoImage;
    private int CurrentBlurPower = -1;
    private string MoveVector;

    [Header("BlurPowerPointControl")]
    [SerializeField]
    private int MoveSpeed;
    [SerializeField]
    private Transform[] SwitchBlurPoint;
    private int CurrentSwitchBlurPointNumber;


    [Header("FinishMiniGameScreen")]
    [SerializeField]
    private string LoseMessage;
    [SerializeField]
    private Text PhotosQualityText;
    [SerializeField]
    private GameObject FinishMiniGameScreen;
    [SerializeField]
    private RawImage ResultsPhoto;

    [Header("RemainingTime")]
    [SerializeField]
    private float StartAllTime = 20;
    [SerializeField]
    private Text RemainingTimeText;
    [SerializeField]
    private Image RemainingTimeBar;
    private float RemainingTime = 10000000;

    public void StartGame() => RemainingTime = StartAllTime;

    private void Start()
    {
        gameObject.transform.position = new Vector3(Random.Range(SwitchBlurPoint[11].position.x, SwitchBlurPoint[12].position.x), gameObject.transform.position.y, 0);
        FocusBarGapWidth = FocusBarGapRightPoint.transform.position.x - FocusBarGapLeftPoint.transform.position.x;
    }

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

            ResultsPhoto.texture = null;

            PhotosQualityText.text = LoseMessage;

            gameObject.transform.localScale = new Vector3(0, 0, 0);
        }

        if (MoveVector == "Right")
        {
            if (gameObject.transform.position.x < SwitchBlurPoint[12].position.x)
                gameObject.transform.position += new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
            if (gameObject.transform.position.x > SwitchBlurPoint[12].position.x)
                gameObject.transform.position = new Vector3(SwitchBlurPoint[12].position.x, gameObject.transform.position.y, 0);
        }
        else if (MoveVector == "Left")
        {
            if (gameObject.transform.position.x > SwitchBlurPoint[11].position.x)
                gameObject.transform.position -= new Vector3(MoveSpeed * Time.deltaTime, 0, 0);
            if (gameObject.transform.position.x < SwitchBlurPoint[11].position.x)
                gameObject.transform.position = new Vector3(SwitchBlurPoint[11].position.x, gameObject.transform.position.y, 0);
        }

        while (true)
        {
            if (gameObject.transform.position.x <= SwitchBlurPoint[CurrentSwitchBlurPointNumber].position.x &&
            gameObject.transform.position.x >= SwitchBlurPoint[CurrentSwitchBlurPointNumber].position.x - FocusBarGapWidth)
            {
                if (CurrentSwitchBlurPointNumber % 2 == 0)
                {
                    MainGamePhotoImage.texture = MiniGameCameraDataManager.PhotoTexture2D[CurrentSwitchBlurPointNumber / 2];
                    CurrentBlurPower = CurrentSwitchBlurPointNumber / 2;
                }
                else
                {
                    MainGamePhotoImage.texture = MiniGameCameraDataManager.PhotoTexture2D[(CurrentSwitchBlurPointNumber + 1) / 2];
                    CurrentBlurPower = (CurrentSwitchBlurPointNumber + 1) / 2;
                }
                break;
            }

            CurrentSwitchBlurPointNumber++;
        }

        CurrentSwitchBlurPointNumber = 0;
    }

    public void TakePhoto()
    {
        FinishMiniGameScreen.SetActive(true);

        ResultsPhoto.texture = MiniGameCameraDataManager.PhotoTexture2D[CurrentBlurPower];

        PhotosQualityText.text = MiniGameCameraDataManager.PhotosQuality[CurrentBlurPower];

        gameObject.transform.localScale = new Vector3(0, 0, 0);

        MiniGameIsFinish = true;
    }
    
    public void DownMoveButton(string ButtonType) => MoveVector = ButtonType;

    public void UpMoveButton() => StartCoroutine(StopMove(UnityEngine.Random.Range(1, 9) / 10));

    private IEnumerator StopMove(float Delay)
    {
        yield return new WaitForSeconds(Delay);
        MoveVector = "null";
    }
}
