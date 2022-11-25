using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShowMoney : MonoBehaviour
    {
        [SerializeField]
        Text MoneyText;
        void Start() => MoneyText.text = PlayerPrefs.GetInt("money").ToString();

        void LateUpdate() => MoneyText.text = PlayerPrefs.GetInt("money").ToString();
    }
}
