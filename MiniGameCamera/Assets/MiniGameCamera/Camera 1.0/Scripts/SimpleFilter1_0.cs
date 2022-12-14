using UnityEngine;

public class SimpleFilter1_0 : MonoBehaviour
{
    public Shader Shader;

    protected Material Material;

    private bool UseFilterStatus = true;

    private void Awake()
    {
        Init();
        UpdateShader();
    }

    protected virtual void Init()
    {

    }

    private void Update()
    {
        Init();
        OnUpdate();
    }

    protected virtual void OnUpdate()
    {

    }

    private void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        if (UseFilterStatus)
        {
            UseFilter(src, dst);
        }
        else
        {
            Graphics.Blit(src, dst);
        }
    }

    protected virtual void UseFilter(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, Material);
    }

    public void UpdateShader() => Material = new Material(Shader);
}
