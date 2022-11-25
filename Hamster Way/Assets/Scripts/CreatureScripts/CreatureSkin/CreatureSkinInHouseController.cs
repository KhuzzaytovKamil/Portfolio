using UnityEngine;
using ScriptableObjects.Economy;
using UnityEngine.UI;

namespace Creature.Skins
{
    public class CreatureSkinInHouseController : MonoBehaviour
    {
        [SerializeField]
        PlayerSkinsManager PlayerSkinsManager;
        void Start() => gameObject.GetComponent<Image>().sprite = PlayerSkinsManager.SkinStandard[PlayerPrefs.GetInt("ActiveSkinNumber")];
        
        public void SetEmptyAnim() => Destroy(gameObject);
        
    }
}
