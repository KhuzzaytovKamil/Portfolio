using UnityEngine;
using ScriptableObjects.Economy;

namespace Player
{
    public class ColorInPlayerController : MonoBehaviour
    {
        [SerializeField]
        ColorsManager ColorsManager;
        void Start() => gameObject.GetComponent<Renderer>().material = ColorsManager.ColorMaterial[PlayerPrefs.GetInt("UsedColorNumber")];
    }
}
