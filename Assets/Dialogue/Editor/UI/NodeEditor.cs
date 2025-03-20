using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class NodeEditor : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("Window/UI Toolkit/NodeEditor")]
    public static void ShowExample()
    {
        NodeEditor wnd = GetWindow<NodeEditor>();
        wnd.titleContent = new GUIContent("NodeEditor");
    }

    public void CreateGUI()
    {
        var root = rootVisualElement;


        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Dialogue/Editor/UI/NodeEditor.uxml");
        visualTree.CloneTree(root);
   

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Dialogue/Editor/UI/NodeEditor.uss");
        root.styleSheets.Add(styleSheet);
    }
}
