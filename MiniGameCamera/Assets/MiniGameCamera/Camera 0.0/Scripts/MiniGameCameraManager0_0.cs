using UnityEngine;
using UnityEngine.UI;

public class MiniGameCameraManager0_0 : MonoBehaviour
{
    [SerializeField]
    private MiniGameCameraDataManager0_0 MiniGameCameraDataManager;
    [SerializeField]
    private RawImage MainGamePhotoImage;
    private int CurrentBlurPower = -1;
    [SerializeField]
    private Text PhotosQualityText;
    [SerializeField]
    private GameObject FinishMiniGameScreen;
    [SerializeField]
    private RawImage ResultsPhoto;


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
