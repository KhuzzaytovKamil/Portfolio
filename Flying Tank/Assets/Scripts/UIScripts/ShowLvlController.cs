using UnityEngine;
using UnityEngine.UI;
using LvlGenerator;

namespace UI
{
    public class ShowLvlController : MonoBehaviour
    {
        [SerializeField]
        Text LvlText;
        [SerializeField]
        PlatformGeneratorManager LvlManager;
        void Start() => LvlText.text = LvlManager.LvlNumber.ToString(); 
        
    }    
}

