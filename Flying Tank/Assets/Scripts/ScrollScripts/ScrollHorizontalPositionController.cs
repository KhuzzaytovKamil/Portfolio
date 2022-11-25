using UnityEngine;

namespace Scroll
{
    public class ScrollHorizontalPositionController : MonoBehaviour
    {
        [SerializeField]
        GameObject InfoSpace;
        [SerializeField]
        GameObject TheMostRightPositionPoint;
        [SerializeField]
        GameObject TheMostLeftPositionPoint;
        void Update()
        {
            if (InfoSpace.transform.position.x < TheMostRightPositionPoint.transform.position.x)
                InfoSpace.transform.position = TheMostRightPositionPoint.transform.position;
            else if (InfoSpace.transform.position.x > TheMostLeftPositionPoint.transform.position.x)
                InfoSpace.transform.position = TheMostLeftPositionPoint.transform.position;
        }
    }
}