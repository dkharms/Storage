using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Storage.Models;

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

        public static TreeNode CreateNode(TreeView treeView, StorageModel storageModel)
        {
            treeView.Nodes.Add(storageModel.Name);
            treeView.Nodes[^1].Tag = storageModel;
            treeView.Nodes[^1].ImageIndex = 3;
            treeView.Nodes[^1].SelectedImageIndex = 3;

            return treeView.Nodes[^1];
        }

        public static TreeNode CreateNode(TreeNode treeNode, SectionModel sectionModel)
        {
            treeNode.Nodes.Add(sectionModel.Name);
            treeNode.Nodes[^1].Tag = sectionModel;

            return treeNode.Nodes[^1];
        }

        public static TreeNode CreateNode(TreeNode treeNode, ProductModel productModel)
        {
            treeNode.Nodes.Add(productModel.Name);
            treeNode.Nodes[^1].Tag = productModel;
            treeNode.Nodes[^1].ImageIndex = 2;
            treeNode.Nodes[^1].SelectedImageIndex = 2;

            return treeNode.Nodes[^1];
        }

        public static void FillTreeView(TreeView treeView, StorageModel storageModel)
        {
            treeView.BeginUpdate();
            TreeNode storageNode = CreateNode(treeView, storageModel);
            foreach (SectionModel sectionModel in storageModel.SectionList)
                CreateAllSubNodes(storageNode, sectionModel);
            treeView.EndUpdate();
        }

        private static void CreateAllSubNodes(TreeNode treeNode, SectionModel sectionModel)
        {
            TreeNode sectionTreeNode = CreateNode(treeNode, sectionModel);
            foreach (ProductModel productModel in sectionModel.ProductList)
            {
                TreeNode productTreeNode = CreateNode(sectionTreeNode, productModel);
                ProductController.AssignProductToNode(productModel, productTreeNode);
            }

            foreach (SectionModel subSectionModel in sectionModel.SectionList)
                CreateAllSubNodes(sectionTreeNode, subSectionModel);
        }

        public static void SortNodes(TreeView treeView, TreeNode parentTreeNode)
        {
            TreeNode[] treeNodes = new TreeNode[parentTreeNode.Nodes.Count];
            parentTreeNode.Nodes.CopyTo(treeNodes, 0);
            Array.Sort(treeNodes, CompareNodes);
            
            treeView.BeginUpdate();
            parentTreeNode.Nodes.Clear();
            parentTreeNode.Nodes.AddRange(treeNodes);
            treeView.EndUpdate();
        }

        private static int CompareNodes(TreeNode left, TreeNode right)
        {
            if (left.Tag is SectionModel leftSectionModel && right.Tag is SectionModel rightSectionModel)
                return leftSectionModel.CompareTo(rightSectionModel);
            if (left.Tag is SectionModel && right.Tag is ProductModel)
                return -1;
            if (left.Tag is ProductModel && right.Tag is SectionModel)
                return 1;

            return 0;
        }
    }
}