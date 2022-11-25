using UnityEngine;

public class CellController : MonoBehaviour
{
    [SerializeField]
    CircleController CircleController;
    public string EntityType;
    [SerializeField]
    GameObject Coin;
    [SerializeField]
    GameObject Spike;

    void Start() => GameManager.CreateEntity += CreateEntity;

    void OnEnable() => GameManager.CreateEntity += CreateEntity;

    void OnDestroy() => GameManager.CreateEntity -= CreateEntity;

    void OnDisable() => GameManager.CreateEntity -= CreateEntity;

    public void Click() => CircleController.CreateNewTargetPoint(transform.position);

    public void CreateEntity()
    {
        if (EntityType == "coin")
            Coin.SetActive(true);
        else if (EntityType == "spike")
            Spike.SetActive(true);
    }
}
