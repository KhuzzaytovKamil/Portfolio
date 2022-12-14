using UnityEngine;

public class ContentCreationToolManager1_0 : MonoBehaviour
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
    private MiniGameCameraDataManager1_0 MiniGameCameraDataManager1_0;

    private void Start()
    {
        SimpleFilterObject.GetComponent<SimpleFilter1_0>().Shader = BlurShader[BlurPower];

        SimpleFilterObject.SetActive(true);
    }

    public void MakeScrenshot()
    {
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/Resources/" + FileName + FileDataType, 1);
        ThisTexture = Resources.Load<Texture2D>(FileName);
        MiniGameCameraDataManager1_0.PhotoTexture2D[BlurPower] = ThisTexture;
    }
}
