using UnityEngine;

namespace TeleportationSystem
{
    public class BackContactTrigger : MonoBehaviour
    {
        [SerializeField]
        MainTeleportationSystemController MainTeleportationSystemController;
        void OnCollisionEnter(Collision other)
        {
            if (MainTeleportationSystemController.LastPipe == other.gameObject)
                MainTeleportationSystemController.BackContact = true;   
        }
        void OnCollisionExit(Collision other)
        {
            if (MainTeleportationSystemController.LastPipe == other.gameObject)
                MainTeleportationSystemController.BackContact = false;
        }
    }    
}

