using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShowEliteMoneyController : MonoBehaviour
    {
        [SerializeField]
        Text EliteMoneyText;
        void Start() => EliteMoneyText.text = PlayerPrefs.GetInt("EliteMoney").ToString();
        
        void LateUpdate() => EliteMoneyText.text = PlayerPrefs.GetInt("EliteMoney").ToString();
        
    }
}
