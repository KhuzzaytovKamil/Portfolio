using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShowMoneyController : MonoBehaviour
    {
        [SerializeField]
        Text money_text;
        void Start() => money_text.text = PlayerPrefs.GetInt("money").ToString();
        
        void LateUpdate() => money_text.text = PlayerPrefs.GetInt("money").ToString();
        
    }
}
