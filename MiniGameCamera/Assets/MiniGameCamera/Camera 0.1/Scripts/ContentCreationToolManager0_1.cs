using UnityEngine;

public class ContentCreationToolManager0_1 : MonoBehaviour
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
    private MiniGameCameraDataManager0_1 MiniGameCameraDataManager0_1;

    private void Start()
    {
        SimpleFilterObject.GetComponent<SimpleFilter0_1>().Shader = BlurShader[BlurPower];

        SimpleFilterObject.SetActive(true);
    }

    public void MakeScrenshot()
    {
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/Resources/" + FileName + FileDataType, 1);
        ThisTexture = Resources.Load<Texture2D>(FileName);
        MiniGameCameraDataManager0_1.PhotoTexture2D[BlurPower] = ThisTexture;
    }
}
