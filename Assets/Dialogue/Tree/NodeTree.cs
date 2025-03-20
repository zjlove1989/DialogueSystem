using System;
using System.Collections.Generic;
using UnityEngine;

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
    }
}