using UnityEngine;

namespace Player
{
    public class FallTrigger : MonoBehaviour
    {
        [SerializeField]
        PlayerMoveController PlayerMoveController;
        void OnCollisionEnter() => PlayerMoveController.SavePoint();
    }
}
