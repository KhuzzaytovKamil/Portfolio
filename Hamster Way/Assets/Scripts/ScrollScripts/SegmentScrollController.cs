using UnityEngine;
using UnityEngine.UI;

namespace Scroll
{
    public class SegmentScrollController : MonoBehaviour
    {
        [SerializeField]
        Text SegmentNumberText;
        [SerializeField]
        GameObject BackHelper;
        [SerializeField]
        GameObject ForwardHelper;
        [SerializeField]
        GameObject AllPlace;
        [SerializeField]
        int SegmentNumber;
        [SerializeField]
        int CurrentSegment;
        float AllPlaceTruePosition;
        float MouseDownPosition;
        bool MouseDownInLastUpdate;
        [SerializeField]
        GameObject LeftPoint;
        [SerializeField]
        GameObject RightPoint;
        [SerializeField]
        int TheFirstLvlIn_2_Segment;
        [SerializeField]
        int TheFirstLvlIn_3_Segment;
        [SerializeField]
        int TheFirstLvlIn_4_Segment;
        [SerializeField]
        int TheFirstLvlIn_5_Segment;
        void Start()
        {
            if (PlayerPrefs.GetInt("FalseNextBlockInLvl" + (TheFirstLvlIn_5_Segment - 1)) == 1)
            {
                AllPlace.transform.position -= new Vector3(1, 0, 0) * (RightPoint.transform.position.x - LeftPoint.transform.position.x) * 4;
                CurrentSegment = 5;
            }
            else if (PlayerPrefs.GetInt("FalseNextBlockInLvl" + (TheFirstLvlIn_4_Segment - 1)) == 1)
            {
                AllPlace.transform.position -= new Vector3(1, 0, 0) * (RightPoint.transform.position.x - LeftPoint.transform.position.x) * 3;
                CurrentSegment = 4;
            }
            else if (PlayerPrefs.GetInt("FalseNextBlockInLvl" + (TheFirstLvlIn_3_Segment - 1)) == 1)
            {
                AllPlace.transform.position -= new Vector3(1, 0, 0) * (RightPoint.transform.position.x - LeftPoint.transform.position.x) * 2;
                CurrentSegment = 3;
            }
            else if (PlayerPrefs.GetInt("FalseNextBlockInLvl" + (TheFirstLvlIn_2_Segment - 1)) == 1)
            {
                AllPlace.transform.position -= new Vector3(1, 0, 0) * (RightPoint.transform.position.x - LeftPoint.transform.position.x);
                CurrentSegment = 2;
            }
            AllPlaceTruePosition = AllPlace.transform.position.x;
            if (CurrentSegment == 1)
                BackHelper.SetActive(false);
            if (CurrentSegment == SegmentNumber)
                ForwardHelper.SetActive(false);
            SegmentNumberText.text = CurrentSegment + "/" + SegmentNumber;
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                MouseDownPosition = Input.mousePosition.x;
                MouseDownInLastUpdate = true;
            }
            else if (MouseDownInLastUpdate && Input.GetMouseButtonUp(0))
            {
                MouseDownInLastUpdate = false;
                if (((RightPoint.transform.position.x - LeftPoint.transform.position.x) / 3) < (Input.mousePosition.x - MouseDownPosition))
                    SwitchCurrentPlaceToLast();
                else if (((RightPoint.transform.position.x - LeftPoint.transform.position.x) / 3) < (MouseDownPosition - Input.mousePosition.x))
                    SwitchCurrentPlaceToNext();
            }
            if (AllPlace.transform.position.x != AllPlaceTruePosition)
            {
                if (AllPlace.transform.position.x < AllPlaceTruePosition)
                    AllPlace.transform.position += new Vector3(1, 0, 0) * (RightPoint.transform.position.x - LeftPoint.transform.position.x) * Time.deltaTime * 3;
                else
                    AllPlace.transform.position -= new Vector3(1, 0, 0) * (RightPoint.transform.position.x - LeftPoint.transform.position.x) * Time.deltaTime * 3;
                if ((AllPlace.transform.position.x - ((RightPoint.transform.position.x - LeftPoint.transform.position.x) / 10)) < AllPlaceTruePosition && (AllPlace.transform.position.x + ((RightPoint.transform.position.x - LeftPoint.transform.position.x) / 20)) > AllPlaceTruePosition)
                {
                    AllPlace.transform.position = new Vector3(AllPlaceTruePosition, AllPlace.transform.position.y, 0);
                    AllPlaceTruePosition = AllPlace.transform.position.x;
                }
            }
        }
        public void SwitchCurrentPlaceToNext()
        {
            if (CurrentSegment < SegmentNumber)
            {
                AllPlaceTruePosition -= RightPoint.transform.position.x - LeftPoint.transform.position.x;
                CurrentSegment ++;
                if (CurrentSegment == SegmentNumber)
                    ForwardHelper.SetActive(false);
                BackHelper.SetActive(true);
                SegmentNumberText.text = CurrentSegment + "/" + SegmentNumber;
            }
        }
        public void SwitchCurrentPlaceToLast()
        {
            if (CurrentSegment > 1)
            {
                AllPlaceTruePosition += RightPoint.transform.position.x - LeftPoint.transform.position.x;
                CurrentSegment --;
                if (CurrentSegment == 1)
                    BackHelper.SetActive(false);
                ForwardHelper.SetActive(true);
                SegmentNumberText.text = CurrentSegment + "/" + SegmentNumber;
            }
        }
    }    
}

