using UnityEngine;

public class ContentCreationToolManager1_1 : MonoBehaviour
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
    private MiniGameCameraDataManager1_1 MiniGameCameraDataManager1_1;

    private void Start()
    {
        SimpleFilterObject.GetComponent<SimpleFilter1_1>().Shader = BlurShader[BlurPower];

        SimpleFilterObject.SetActive(true);
    }

    public void MakeScrenshot()
    {
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/Resources/" + FileName + FileDataType, 1);
        ThisTexture = Resources.Load<Texture2D>(FileName);
        MiniGameCameraDataManager1_1.PhotoTexture2D[BlurPower] = ThisTexture;
    }
}