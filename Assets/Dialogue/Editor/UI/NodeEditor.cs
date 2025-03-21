using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialogue
{
    public class NodeEditor : EditorWindow
    {
        [SerializeField] private VisualTreeAsset m_VisualTreeAsset = default;

        NodeTreeViewer nodeTreeViewer;
        InspectorViewer inspectorViewer;

        [MenuItem("Window/UI Toolkit/NodeEditor")]
        public static void ShowExample()
        {
            var wnd = GetWindow<NodeEditor>();
            wnd.titleContent = new GUIContent("NodeEditor");
        }

        public void CreateGUI()
        {
            var root = rootVisualElement;


            var visualTree =
                AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Dialogue/Editor/UI/NodeEditor.uxml");
            visualTree.CloneTree(root);


            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Dialogue/Editor/UI/NodeEditor.uss");
            root.styleSheets.Add(styleSheet);

            // 将节点树视图添加到节点编辑器中
            nodeTreeViewer = root.Q<NodeTreeViewer>();
            // 将节属性面板视图添加到节点编辑器中
            inspectorViewer = root.Q<InspectorViewer>();
        }

        private void OnSelectionChange()
        {
            // 检测该选中对象中是否存在节点树
            NodeTree tree = Selection.activeObject as NodeTree;
            // 判断如果选中对象不为节点树，则获取该对象下的节点树运行器中的节点树
            if (!tree)
            {
                if (Selection.activeGameObject)
                {
                    NodeTreeRunner runner = Selection.activeGameObject.GetComponent<NodeTreeRunner>();
                    if (runner)
                    {
                        tree = runner.tree;
                    }
                }
            }

            if (Application.isPlaying)
            {
                if (tree)
                {
                    if (nodeTreeViewer != null)
                    {
                        nodeTreeViewer.PopulateView(tree);
                    }
                }
            }
            else
            {
                if (tree && AssetDatabase.CanOpenAssetInEditor(tree.GetInstanceID()))
                {
                    if (nodeTreeViewer != null)
                    {
                        nodeTreeViewer.PopulateView(tree);
                    }
                }
            }
        }
    }
}