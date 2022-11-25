using UnityEngine;
using UnityEngine.UI;
using Finish.ClassicLvlFinishSystem;
using Main;

namespace ClassicLvlGenerator
{
    public class CreateDoubleRotationPipeController : MonoBehaviour
    {
        [SerializeField]
        GameObject TheFirstRotationPipe;
        [SerializeField]
        GameObject TheSecondRotationPipe;
        [SerializeField]
        GameObject ButtonPrefab;
        GameObject Button;
        [ContextMenu("CreateDoubleRotationPipe")]
        void CreateDoubleRotationPipe()
        {
            Button = Instantiate(ButtonPrefab, TheFirstRotationPipe.transform.position, ButtonPrefab.transform.rotation);
            Button.transform.SetParent(gameObject.transform);
            Button.transform.localScale = new Vector3(1, 1, 1);
            TheFirstRotationPipe.GetComponent<ObjectsBank>().Objects[0].transform.SetParent(Button.transform);
            TheSecondRotationPipe.GetComponent<ObjectsBank>().Objects[0].transform.SetParent(Button.transform);
            Destroy(TheFirstRotationPipe.GetComponent<ObjectsBank>().Objects[0].GetComponent<Button>());
            Destroy(TheSecondRotationPipe.GetComponent<ObjectsBank>().Objects[0].GetComponent<Button>());
        }
        void Start() => PipelineInspector.StartChack += SetOtherPipeToHisParent;
        
        void OnEnable() => PipelineInspector.StartChack += SetOtherPipeToHisParent;
        
        void OnDisable() => PipelineInspector.StartChack -= SetOtherPipeToHisParent;
        
        void OnDestroy() => PipelineInspector.StartChack -= SetOtherPipeToHisParent;
        
        void SetOtherPipeToHisParent()
        {
            TheFirstRotationPipe.GetComponent<ObjectsBank>().Objects[0].transform.SetParent(TheFirstRotationPipe.transform);
            TheSecondRotationPipe.GetComponent<ObjectsBank>().Objects[0].transform.SetParent(TheSecondRotationPipe.transform);
        }
    }
}

