using UnityEngine;

public class ContentCreationToolManager : MonoBehaviour
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
    private MiniGameCameraDataManager MiniGameCameraDataManager;

    private void Start()
    {
        SimpleFilterObject.GetComponent<SimpleFilter>().Shader = BlurShader[BlurPower];

        SimpleFilterObject.SetActive(true);
    }

    public void MakeScrenshot()
    {
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/Resources/" + FileName + FileDataType, 1);
        ThisTexture = Resources.Load<Texture2D>(FileName);
        MiniGameCameraDataManager.PhotoTexture2D[BlurPower] = ThisTexture;
    }
}
