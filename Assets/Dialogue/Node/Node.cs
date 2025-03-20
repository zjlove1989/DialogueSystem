using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public abstract class Node : ScriptableObject
    {
        public enum State
        {
            Running,
            Waiting,
        }

        public State state = State.Waiting;
        public bool started = false;
        // 每个对话节点的描述
        [TextArea] public string description;

        public Node OnUpdate()
        {
            if (!started)
            {
                OnStart();
                started = true;
            }

            var currentNode = LogicUpdate();
            if (state != State.Running)
            {
                OnStop();
                started = false;
            }

            return currentNode;
        }

        public abstract Node LogicUpdate();
        protected abstract void OnStart();
        protected abstract void OnStop();
    }
}