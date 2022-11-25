using UnityEngine;
using ScriptableObjects.LvlsManager;

namespace LvlGenerator
{
    public class LvlLoadController : MonoBehaviour
    {
        [SerializeField]
        LvlsManager LvlsManager;
        void Start() =>
            Instantiate(LvlsManager.Lvls[PlayerPrefs.GetInt("LvlNumber")],
            LvlsManager.Lvls[PlayerPrefs.GetInt("LvlNumber")].transform.position,
            LvlsManager.Lvls[PlayerPrefs.GetInt("LvlNumber")].transform.rotation);
    }
}