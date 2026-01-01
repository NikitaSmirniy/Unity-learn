using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasInitializer : MonoBehaviour
{
    [SerializeField] private Canvas _canvasPrefab;

    private void Awake()
    {
        var createdCnvas =  Instantiate(_canvasPrefab);
        
        createdCnvas.renderMode = RenderMode.ScreenSpaceCamera;
        createdCnvas.worldCamera = Camera.main;

        var canvasScaler = createdCnvas.GetComponent<CanvasScaler>();
        
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        
        canvasScaler.referenceResolution = new Vector2(1920, 1080);
    }
}