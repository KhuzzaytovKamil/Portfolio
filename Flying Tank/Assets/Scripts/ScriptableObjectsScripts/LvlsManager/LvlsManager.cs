using UnityEngine;

namespace ScriptableObjects.LvlsManager
{
    [CreateAssetMenu(menuName = "LvlsManager/LvlsManager")]
    public class LvlsManager : ScriptableObject
    {
        public GameObject[] Lvls;
    }
}
