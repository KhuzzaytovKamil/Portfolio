using UnityEngine;
using UnityEngine.UI;

public class MiniGameCameraManager0_1 : MonoBehaviour
{
    private bool MiniGameIsFinish = false;

    [Header("Photo")]
    [SerializeField]
    private MiniGameCameraDataManager0_1 MiniGameCameraDataManager;
    [SerializeField]
    private RawImage MainGamePhotoImage;
    private int CurrentBlurPower = -1;

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
    private float RemainingTime;

    private void Start() => RemainingTime = StartAllTime;

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
    }

    public void BlurPower0()
    {
        MainGamePhotoImage.texture = MiniGameCameraDataManager.PhotoTexture2D[0];
        CurrentBlurPower = 0;
    }

    public void BlurPower1()
    {
        MainGamePhotoImage.texture = MiniGameCameraDataManager.PhotoTexture2D[1];
        CurrentBlurPower = 1;
    }

    public void BlurPower2()
    {
        MainGamePhotoImage.texture = MiniGameCameraDataManager.PhotoTexture2D[2];
        CurrentBlurPower = 2;
    }

    public void BlurPower3()
    {
        MainGamePhotoImage.texture = MiniGameCameraDataManager.PhotoTexture2D[3];
        CurrentBlurPower = 3;
    }

    public void BlurPower4()
    {
        MainGamePhotoImage.texture = MiniGameCameraDataManager.PhotoTexture2D[4];
        CurrentBlurPower = 4;
    }

    public void BlurPower5()
    {
        MainGamePhotoImage.texture = MiniGameCameraDataManager.PhotoTexture2D[5];
        CurrentBlurPower = 5;
    }

    public void BlurPower6()
    {
        MainGamePhotoImage.texture = MiniGameCameraDataManager.PhotoTexture2D[6];
        CurrentBlurPower = 6;
    }

    public void TakePhoto()
    {
        FinishMiniGameScreen.SetActive(true);

        ResultsPhoto.texture = MiniGameCameraDataManager.PhotoTexture2D[CurrentBlurPower];

        PhotosQualityText.text = MiniGameCameraDataManager.PhotosQuality[CurrentBlurPower];

        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
}
