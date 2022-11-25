using UnityEngine;

namespace Finish.LoseSystem
{
    public class LoseWindowController : MonoBehaviour
    {
        [SerializeField]
        GameObject ObjectGroupTimeIsOver;
        [SerializeField]
        GameObject ObjectGroupFalsePipeline;
        void Start()
        {
            if (PlayerPrefs.GetString("cause") == "TimeIsOver")
                ObjectGroupTimeIsOver.SetActive(true);
            else if (PlayerPrefs.GetString("cause") == "FalsePipeline")
                ObjectGroupFalsePipeline.SetActive(true);
        }

        public void CloseLoseWindow() => gameObject.SetActive(false);
        
    }
}

