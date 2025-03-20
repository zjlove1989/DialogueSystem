using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

public class NodeTreeViewer : GraphView
{
    public new class UxmlFactory : UxmlFactory<NodeTreeViewer, GraphView.UxmlTraits>
    {
    }
    
    public NodeTreeViewer(){
        Insert(0, new GridBackground());
        // 添加视图缩放
        this.AddManipulator(new ContentZoomer());
        // 添加视图拖拽
        this.AddManipulator(new ContentDragger());
        // 添加选中对象拖拽
        this.AddManipulator(new SelectionDragger());
        // 添加框选
        this.AddManipulator(new RectangleSelector());
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Dialogue/Editor/UI/NodeTreeViewer.uss");
        styleSheets.Add(styleSheet);
    }
}