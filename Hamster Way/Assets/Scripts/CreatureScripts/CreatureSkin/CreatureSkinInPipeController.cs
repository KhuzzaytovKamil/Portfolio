using UnityEngine;
using UnityEngine.UI;
using ScriptableObjects.Economy;

namespace Creature.Skins
{
    public class CreatureSkinInPipeController : MonoBehaviour
    {
        [SerializeField]
        PlayerSkinsManager PlayerSkinsManager;
        void Start()
        {
            gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinInPipe[PlayerPrefs.GetInt("ActiveSkinNumber")];
        }
    }
}