using TreeEditor;
using UnityEngine;

namespace Dialogue
{
    public class NodeTreeRunner : MonoBehaviour
    {
        public NodeTree tree;

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