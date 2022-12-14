using UnityEngine;

public class ContentCreationToolManager0_0 : MonoBehaviour
{
    [SerializeField]
    private Texture2D ThisTexture;

    [Header("BlurShaderData")]
    [SerializeField]
    private int BlurPower;
    [SerializeField]
    private Shader[] BlurShader;
    [SerializeField]
    private GameObject SimpleFilterObject;

    [Header("FileSaveData")]
    [SerializeField]
    private string FileName;
    [SerializeField]
    private string FileDataType;
    [SerializeField]
    private MiniGameCameraDataManager0_0 MiniGameCameraDataManager0_0;

    private void Start()
    {
        SimpleFilterObject.GetComponent<SimpleFilter0_0>().Shader = BlurShader[BlurPower];

        SimpleFilterObject.SetActive(true);
    }

    public void MakeScrenshot()
    {
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/Resources/" + FileName + FileDataType, 1);
        ThisTexture = Resources.Load<Texture2D>(FileName);
        MiniGameCameraDataManager0_0.PhotoTexture2D[BlurPower] = ThisTexture;
    }
}
