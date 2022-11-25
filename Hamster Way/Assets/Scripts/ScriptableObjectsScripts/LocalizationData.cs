using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "LocalizationData")]
    public class LocalizationData : ScriptableObject
    {
        public string[] LocalizationKeys;
    }
}
