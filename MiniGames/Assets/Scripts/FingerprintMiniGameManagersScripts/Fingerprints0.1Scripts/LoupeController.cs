using UnityEngine;
using UnityEngine.UI;

public class LoupeController : MonoBehaviour
{
    [SerializeField]
    private MiniGameFingerprintsManager MiniGameFingerprintsManager;
    private Vector3 StartPositionPoint;
    [SerializeField]
    private Transform StubPositionPoint;

    private bool FollowClick;
    [Header("LoupeTime")]
    [SerializeField]
    private float LoupeTime = 2.5f;
    [SerializeField]
    private Image RemainingLoupeTimeBar;
    [SerializeField]
    private GameObject RemainingLoupeTimeBarSystem;
    private float RemainingLoupeTime;
    private bool LoupeCollisionEnter;

    private GameObject CurrentContactFingerprint;

    private void Start()
    {
        RemainingLoupeTime = LoupeTime;
        StartPositionPoint = gameObject.transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && MiniGameFingerprintsManager.RemainingTime != 1000000)
            FollowClick = true;

        if (Input.GetMouseButtonUp(0))
            FollowClick = false;

        if (FollowClick && MiniGameFingerprintsManager.RemainingTime > 0)
        {
            gameObject.transform.position = new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        }

        if (LoupeCollisionEnter && MiniGameFingerprintsManager.RemainingTime > 0)
        {
            if (RemainingLoupeTime >= 0)
            {
                RemainingLoupeTimeBarSystem.SetActive(true);

                RemainingLoupeTime -= Time.deltaTime;

                RemainingLoupeTimeBar.fillAmount += RemainingLoupeTime / LoupeTime * Time.deltaTime * 0.9f;
            }
            else
            {
                LoupeCollisionEnter = false;

                RemainingLoupeTimeBarSystem.SetActive(false);
                RemainingLoupeTimeBar.fillAmount = 0;
                RemainingLoupeTime = LoupeTime;

                MiniGameFingerprintsManager.FindedFingerprintAmount++;
                
                Destroy(CurrentContactFingerprint);

                FollowClick = false;
                gameObject.transform.position = StartPositionPoint;
            } 
        }
    }

    private void OnCollisionEnter(Collision ThisCollision)
    {
        LoupeCollisionEnter = true;

        ThisCollision.gameObject.GetComponent<ObjectsBank>().Objects[0].SetActive(true);

        CurrentContactFingerprint = ThisCollision.gameObject;
    }

    private void OnCollisionExit(Collision ThisCollision)
    {
        LoupeCollisionEnter = false;

        ThisCollision.gameObject.GetComponent<ObjectsBank>().Objects[0].SetActive(false);

        RemainingLoupeTimeBarSystem.SetActive(false);
        RemainingLoupeTimeBar.fillAmount = 0;
        RemainingLoupeTime = LoupeTime;
    }
}
