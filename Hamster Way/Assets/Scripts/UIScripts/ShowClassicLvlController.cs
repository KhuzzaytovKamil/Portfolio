using UnityEngine;
using UnityEngine.UI;
using ClassicLvlGenerator;

namespace UI
{
    public class ShowClassicLvlController : MonoBehaviour
    {
        [SerializeField]
        Text LvlText;
        [SerializeField]
        ClassicLvlSettingsManager LvlManager;
        void Start() => LvlText.text = LvlManager.LvlNumber.ToString(); 
        
    }    
}

