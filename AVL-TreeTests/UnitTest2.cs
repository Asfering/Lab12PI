using AVL_Tree;
using Lab10Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AVL_TreeTests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void BinaryTreeAddTestMethod()
        {
            BinaryTree<Worker> binaryTree = new BinaryTree<Worker>();
            binaryTree.Add(new Worker("Da", "Net", 5, "Fire"));
            Assert.IsNotNull(binaryTree);
        }

        [TestMethod]
        public void BinaryTreeClearTestMethod()
        {
            BinaryTree<Worker> binaryTree = new BinaryTree<Worker>();
            binaryTree.Add(new Worker("Da", "Net", 5, "Fire"));
            binaryTree.Clear();
            Assert.AreEqual(0, binaryTree.count);
        }

        [TestMethod]
        public void BinaryTreeRemoveTestMethod()
        {
            BinaryTree<Worker> binaryTree = new BinaryTree<Worker>();
            binaryTree.Add(new Worker("Da", "Net", 5, "Fire"));
            binaryTree.Add(new Worker("Yes", "No", 19, "Ice"));
            Worker wrkRemove = new Worker("Yes", "No", 19, "Ice");
            binaryTree.Remove(wrkRemove);
            bool ok = false;
            if (!binaryTree.Contains(new Worker("Yes", "No", 19, "Ice"))) ok = true;
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void BinaryTreeCountTestMethod()
        {
            BinaryTree<Worker> binaryTree = new BinaryTree<Worker>();
            binaryTree.Add(new Worker("Da", "Net", 5, "Fire"));
            Assert.AreEqual(1, binaryTree.Count());
        }

        [TestMethod]
        public void BinaryTreeCloneTestMethod()
        {
            BinaryTree<Worker> binaryTree = new BinaryTree<Worker>();
            binaryTree.Add(new Worker("Da", "Net", 5, "Fire"));
            BinaryTree<Worker> binaryTreeClone = new BinaryTree<Worker>();
            binaryTreeClone = (BinaryTree<Worker>) binaryTree.Clone();
            Assert.IsNotNull(binaryTreeClone);
        }

    }
}
