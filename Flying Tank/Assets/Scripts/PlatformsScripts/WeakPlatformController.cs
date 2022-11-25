using UnityEngine;

namespace Platforms
{
    public class WeakPlatformController : MonoBehaviour
    {
        [SerializeField]
        float ContactTimeBeforeDestroy;
        float CurrentTimeBeforeDestroy;
        bool Contact = false;
        void Start()
        {
            CurrentTimeBeforeDestroy = ContactTimeBeforeDestroy;
        }
        void OnCollisionEnter() => Contact = true;
         
        void OnCollisionExit() => Contact = false;
         
        void Update()
        {
            if (Contact)
            {
                if (CurrentTimeBeforeDestroy == 0 || CurrentTimeBeforeDestroy < 0)
                    gameObject.SetActive(false);
                else
                    CurrentTimeBeforeDestroy -= Time.deltaTime;
            }
        }
        void TurnOnPlatform()
        {
            Contact = false;
            CurrentTimeBeforeDestroy = ContactTimeBeforeDestroy;
            gameObject.SetActive(true);
        }
    }
}