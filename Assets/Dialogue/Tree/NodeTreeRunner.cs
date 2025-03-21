using UnityEngine;

namespace Dialogue
{
    public class NodeTreeRunner : MonoBehaviour
    {
        public DialogueTree tree;
        public NormalDialogue rootNode;

        private void Awake()
        {
            //tree = tree.CreateRuntimeCopy();
            //tree.runningNode = rootNode.CreateRuntimeCopy();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                tree.OnTreeStart();
            }

            if (tree != null && tree.treeState == Node.State.Running)
            {
                tree.Update();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                tree.OnTreeEnd();
            }
        }
    }
}