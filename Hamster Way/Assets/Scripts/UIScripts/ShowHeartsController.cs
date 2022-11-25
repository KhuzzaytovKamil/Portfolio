using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShowHeartsController : MonoBehaviour
    {
        [SerializeField]
        Text text;
        void Start() => text.text = PlayerPrefs.GetInt("Hearts").ToString();

        void LateUpdate() => text.text = PlayerPrefs.GetInt("Hearts").ToString();

    }
}
