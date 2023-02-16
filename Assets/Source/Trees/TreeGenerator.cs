using System.Collections.Generic;
using UnityEngine;

namespace Balthazariy.TreeDestroyer.Trees
{
    public class TreeGenerator : MonoBehaviour
    {
        [SerializeField] private Transform _pivot0;
        [SerializeField] private Transform _pivot1;
        [SerializeField] private Transform _treeParent;


        [SerializeField] private GameObject _treePrefabObject;

        [SerializeField] private int _treeCount;

        private List<Tree> _trees;

        private void Start()
        {
            _trees = new List<Tree>();

            InitTrees();
        }

        private void InitTrees()
        {
            for (int i = 0; i < _treeCount; i++)
            {
                Tree tree = Instantiate(_treePrefabObject, _treeParent).GetComponent<Tree>();

                Vector3 generatedPos = new Vector3(UnityEngine.Random.Range(_pivot0.position.x, _pivot1.position.x), 0, 
                                                   UnityEngine.Random.Range(_pivot0.position.z, _pivot1.position.z));

                tree.Init(generatedPos);
                _trees.Add(tree);
            }

            transform.Rotate(new Vector3(0, 45, 0));

        }
    }
}