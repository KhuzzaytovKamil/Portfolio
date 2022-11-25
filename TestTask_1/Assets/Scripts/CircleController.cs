using UnityEngine;

public class CircleController : MonoBehaviour
{
    [SerializeField]
    [Min(0)]
    float Speed;
    float SpeedX;
    float SpeedY;
    float XDifference;
    float YDifference;
    [HideInInspector]
    public Vector3 TargetPosition;

    Vector3 [] TargetPositionQueue = new Vector3[5000];
    int QueueFreeItem;
    int QueueCompletedItem;
    [SerializeField]
    GameObject [] WayQueue = new GameObject[5000];

    [SerializeField]
    Animator CircleAnimator;
    [SerializeField]
    GameObject LoseScreen;
    [SerializeField]
    GameManager GameManager;

    [SerializeField]
    GameObject Way;
    GameObject CurrentWay;
    [SerializeField]
    GameObject GeneralWay;

    float WayWidth;
    [SerializeField]
    GameObject UIPosition0;
    [SerializeField]
    GameObject UIPosition100;

    Vector3 StartingPoint;

    void SetSpeed()
    {
        SpeedY = Speed;
        SpeedX = Speed;

        if (TargetPosition.x > transform.position.x)
            XDifference = TargetPosition.x - transform.position.x;
        else
            XDifference = transform.position.x - TargetPosition.x;

        if (TargetPosition.y > transform.position.y)
            YDifference = TargetPosition.y - transform.position.y;
        else
            YDifference = transform.position.y - TargetPosition.y;

        if (XDifference > YDifference)
            SpeedY = YDifference / XDifference * Speed;
        else
            SpeedX = XDifference / YDifference * Speed;
    }

    void Update()
    {
        if (Mathf.Round(transform.position.x * 10) != Mathf.Round(TargetPosition.x * 10))
        {
            if (transform.position.x < TargetPosition.x)
                transform.position += new Vector3(1, 0, 0) * SpeedX * Time.deltaTime;
            else
                transform.position -= new Vector3(1, 0, 0) * SpeedX * Time.deltaTime;
        }

        if (Mathf.Round(transform.position.y * 10) != Mathf.Round(TargetPosition.y * 10))
        {
            if (transform.position.y < TargetPosition.y)
                transform.position += new Vector3(0, 1, 0) * SpeedY * Time.deltaTime;
            else
                transform.position -= new Vector3(0, 1, 0) * SpeedY * Time.deltaTime;
        }

        if (Mathf.Round(transform.position.x * 10) == Mathf.Round(TargetPosition.x * 10) && Mathf.Round(transform.position.y * 10) == Mathf.Round(TargetPosition.y * 10))
        {
            Destroy(CurrentWay);
            SetNextTargetPosition();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Spike")
        {
            TargetPosition = transform.position;
            CircleAnimator.SetBool("SpikeContact", true);
        }
        else if (other.gameObject.name == "Coin")
        {
            other.gameObject.SetActive(false);

            if (GameManager.GetCoin() == "coins collected")
                TargetPosition = transform.position;
        }

    }

    public void Lose() => LoseScreen.SetActive(true);

    public void CreateNewTargetPoint(Vector3 TakenTargetPosition)
    {
        TargetPositionQueue[QueueFreeItem] = TakenTargetPosition;

        if (Mathf.Round(transform.position.x * 10) == Mathf.Round(TargetPosition.x * 10) && Mathf.Round(transform.position.y * 10) == Mathf.Round(TargetPosition.y * 10))
            StartingPoint = transform.position;
        else
            StartingPoint = WayQueue[QueueFreeItem - 1].GetComponent<ObjectsBank>().Objects[1].transform.position;

        if (TargetPositionQueue[QueueFreeItem].x > StartingPoint.x)
            XDifference = TargetPositionQueue[QueueFreeItem].x - StartingPoint.x;
        else
            XDifference = StartingPoint.x - TargetPositionQueue[QueueFreeItem].x;

        if (TargetPositionQueue[QueueFreeItem].y > StartingPoint.y)
            YDifference = TargetPositionQueue[QueueFreeItem].y - StartingPoint.y;
        else
            YDifference = StartingPoint.y - TargetPositionQueue[QueueFreeItem].y;

        WayQueue[QueueFreeItem] = Instantiate(Way, StartingPoint, Quaternion.identity);
        WayQueue[QueueFreeItem].transform.SetParent(GeneralWay.transform);
        WayQueue[QueueFreeItem].transform.localScale = new Vector3(1, 1, 1);

        WayWidth = Mathf.Sqrt(XDifference * XDifference + YDifference * YDifference);
        WayQueue[QueueFreeItem].GetComponent<RectTransform>().sizeDelta = new Vector2(40, WayWidth / (UIPosition100.transform.position.x - UIPosition0.transform.position.x) * 100);

        if (TargetPositionQueue[QueueCompletedItem].y < StartingPoint.y && Mathf.Round(TargetPositionQueue[QueueCompletedItem].x) == Mathf.Round(StartingPoint.x))
            WayQueue[QueueFreeItem].transform.Rotate(0, 0, 180);
        else if (TargetPositionQueue[QueueCompletedItem].x > StartingPoint.x && TargetPositionQueue[QueueCompletedItem].y > StartingPoint.y)
            WayQueue[QueueFreeItem].transform.Rotate(0, 0, -Mathf.Asin(XDifference / WayWidth) * 57.14f);
        else if (TargetPositionQueue[QueueCompletedItem].x < StartingPoint.x && TargetPositionQueue[QueueCompletedItem].y > StartingPoint.y)
            WayQueue[QueueFreeItem].transform.Rotate(0, 0, Mathf.Asin(XDifference / WayWidth) * 57.14f);
        else if (TargetPositionQueue[QueueCompletedItem].x > StartingPoint.x && TargetPositionQueue[QueueCompletedItem].y < StartingPoint.y)
            WayQueue[QueueFreeItem].transform.Rotate(180, 180, Mathf.Asin(XDifference / WayWidth) * 57.14f);
        else if (TargetPositionQueue[QueueCompletedItem].x < StartingPoint.x && TargetPositionQueue[QueueCompletedItem].y < StartingPoint.y)
            WayQueue[QueueFreeItem].transform.Rotate(180, 180, -Mathf.Asin(XDifference / WayWidth) * 57.14f);

        if (WayQueue[QueueFreeItem].GetComponent<ObjectsBank>().Objects[0].transform.position.x > StartingPoint.x)
            WayQueue[QueueFreeItem].transform.position -= new Vector3((WayQueue[QueueFreeItem].GetComponent<ObjectsBank>().Objects[0].transform.position.x - StartingPoint.x), 0, 0);
        else
            WayQueue[QueueFreeItem].transform.position += new Vector3((StartingPoint.x - WayQueue[QueueFreeItem].GetComponent<ObjectsBank>().Objects[0].transform.position.x), 0, 0);

        if (WayQueue[QueueFreeItem].GetComponent<ObjectsBank>().Objects[0].transform.position.y > StartingPoint.y)
            WayQueue[QueueFreeItem].transform.position -= new Vector3(0, (WayQueue[QueueFreeItem].GetComponent<ObjectsBank>().Objects[0].transform.position.y - StartingPoint.y), 0);
        else
            WayQueue[QueueFreeItem].transform.position += new Vector3(0, (StartingPoint.y - WayQueue[QueueFreeItem].GetComponent<ObjectsBank>().Objects[0].transform.position.y), 0);


        
        
        QueueFreeItem++;
    }

    void SetNextTargetPosition()
    {
        if (WayQueue[QueueCompletedItem] != null)
        {
            TargetPosition = TargetPositionQueue[QueueCompletedItem];
            CurrentWay = WayQueue[QueueCompletedItem];
            QueueCompletedItem++;
        }
        SetSpeed();
    }
}
