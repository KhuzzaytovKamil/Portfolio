using UnityEngine;

namespace Scroll
{
    public class OpenSamePlaceInScroll : MonoBehaviour
    {
        [SerializeField]
        GameObject PlacePositionPoint;
        [SerializeField]
        GameObject Content;
        [SerializeField]
        bool SwitchScrollContentPositionOnStart;
        void Start()
        {
            if (PlayerPrefs.GetInt("SwitchScrollContentPosition") == 1 && PlacePositionPoint != null && Content != null && SwitchScrollContentPositionOnStart)
            {
                Content.transform.position = PlacePositionPoint.transform.position;
                PlayerPrefs.SetInt("SwitchScrollContentPosition", 0);
            }    
            SwitchScrollContentPositionOnStart = true;
        }
        public void SwitchScrollContentPosition()
        {
            PlayerPrefs.SetInt("SwitchScrollContentPosition", 1);
            Start();
        }
    }
}
