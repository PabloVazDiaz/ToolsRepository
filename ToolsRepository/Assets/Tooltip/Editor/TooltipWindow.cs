using UnityEngine;
using UnityEditor;

public class TooltipWindow : EditorWindow
{

    [SerializeField] GameObject TooltipCanvas;

    private GameObject existingTooltipSystem;

    [MenuItem("Tools/TooltipSystem")]
    public static void ShowWindow()
    {
        GetWindow<TooltipWindow>("Initializer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Press to integrate the tooltip system on the scene", EditorStyles.boldLabel);

        if (GUILayout.Button("Initialize"))
        {
            existingTooltipSystem = FindObjectOfType<TooltipSystem>()?.gameObject;
            if(existingTooltipSystem == null)
            {
                GameObject go = Instantiate(TooltipCanvas);
                go.name = "TooltipCanvas";
            }
            
        }
        if(existingTooltipSystem)
            EditorGUILayout.HelpBox("There is already a Tooltip system on the Scene", MessageType.Warning);

        EditorGUILayout.HelpBox("To be functional Tooltip component must be on a UI raycastable object or a gameobject with a collider", MessageType.Warning);
    }
}
