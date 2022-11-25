using UnityEngine;
using ScriptableObjects.Economy;
using UnityEngine.UI;

namespace PlateSkin
{
    public class SetPlateInLvlController : MonoBehaviour
    {
        [SerializeField]
        PlateSkinManager SkinDataManager;
        void Start() => gameObject.GetComponent<Image>().sprite = SkinDataManager.StandardPlateSprite[PlayerPrefs.GetInt("UsedPlateSkinNumber")];
    }
}