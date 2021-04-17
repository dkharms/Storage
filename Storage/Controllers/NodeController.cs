using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Storage.Controllers
{
    public static class NodeController
    {
        public static Dictionary<TreeNode, List<TreeNode>> GetDeepestNodes(TreeNode treeNode,
            Dictionary<TreeNode, List<TreeNode>> deepestNodes)
        {
            foreach (TreeNode treeSubNode in treeNode.Nodes)
            {
                if (treeSubNode.Nodes.Count == 0)
                {
                    if (!deepestNodes.ContainsKey(treeSubNode.Parent))
                        deepestNodes.Add(treeSubNode.Parent, new List<TreeNode>());

                    deepestNodes[treeSubNode.Parent].Add(treeSubNode);
                }
                else
                    GetDeepestNodes(treeSubNode, deepestNodes);
            }

            return deepestNodes;
        }

        public static List<TreeNode> GetDeepestNodesByType(TreeNode treeNode, Type type, List<TreeNode> deepestNodes)
        {
            foreach (TreeNode treeSubNode in treeNode.Nodes)
            {
                if (treeSubNode.Nodes.Count == 0 && treeSubNode.Tag.GetType() == type)
                    deepestNodes.Add(treeSubNode);
                else
                    GetDeepestNodesByType(treeSubNode, type, deepestNodes);
            }

            return deepestNodes;
        }
    }
}