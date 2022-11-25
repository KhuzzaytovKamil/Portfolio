using UnityEngine;

namespace Learner
{
    public class HelperControllerInEducation : MonoBehaviour
    {
        [SerializeField]
        GameObject ThisHelper;
        [SerializeField]
        HelperControllerInEducation NextHelper;
        [SerializeField]
        bool FirstHelper;
        [SerializeField]
        GameObject HelperText;
        void Start()
        {
            if (FirstHelper)
            {
                ThisHelper.SetActive(true);
                HelperText.SetActive(true);
            }
        }
        public void FinishLastHelp()
        {
            ThisHelper.SetActive(true);
            HelperText.SetActive(true);
        }
        public void UserDid()
        {
            if (NextHelper != null)
                NextHelper.FinishLastHelp();
            ThisHelper.SetActive(false);
            HelperText.SetActive(false);
        }
    }
}
