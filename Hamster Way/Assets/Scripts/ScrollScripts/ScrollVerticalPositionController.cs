using UnityEngine;

namespace Scroll
{
    public class ScrollVerticalPositionController : MonoBehaviour
    {
        [SerializeField]
        GameObject InfoSpace;
        [SerializeField]
        GameObject TheMostUpperPositionPoint;
        [SerializeField]
        GameObject TheMostLowerPositionPoint;
        void Update()
        {
            if (InfoSpace.transform.position.y < TheMostUpperPositionPoint.transform.position.y)
                InfoSpace.transform.position = TheMostUpperPositionPoint.transform.position;
            else if (InfoSpace.transform.position.y > TheMostLowerPositionPoint.transform.position.y)
                InfoSpace.transform.position = TheMostLowerPositionPoint.transform.position;
        }
    }
}