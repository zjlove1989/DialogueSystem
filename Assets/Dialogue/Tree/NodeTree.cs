using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Dialogue
{
    public class NodeTree : ScriptableObject
    {
        public Node runningNode;
        public Node.State treeState = Node.State.Waiting;
        public List<Node> nodes = new List<Node>();

        public virtual void Update()
        {
            if (treeState == Node.State.Running && runningNode.state == Node.State.Running)
            {
                runningNode = runningNode.OnUpdate();
            }
        }

        public virtual void OnTreeStart()
        {
            treeState = Node.State.Running;
        }

        public virtual void OnTreeEnd()
        {
            treeState = Node.State.Waiting;
        }

#if UNITY_EDITOR
        public Node CreateNode(Type type)
        {
            var node = ScriptableObject.CreateInstance(type) as Node;
            node.name = type.Name;
            node.guid = GUID.Generate().ToString();

            nodes.Add(node);
            if (!Application.isPlaying)
            {
                AssetDatabase.AddObjectToAsset(node, this);
            }

            AssetDatabase.SaveAssets();
            return node;
        }

        public Node DeleteNode(Node node)
        {
            nodes.Remove(node);
            AssetDatabase.RemoveObjectFromAsset(node);
            AssetDatabase.SaveAssets();
            return node;
        }
#endif
    }
}