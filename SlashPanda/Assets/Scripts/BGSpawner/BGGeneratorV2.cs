using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BGGeneratorV2 : MonoBehaviour
{
   [SerializeField] private GameObject groundPrefab, tree1Prefab, tree2Prefab;

   [SerializeField] private float groundYpos = -6f, treeYPos=0.18f;

   [SerializeField] private float groundXDistance = 17.85f, treeXDistance = 41.2f;

   private float lastGroundXPos, lastTreeXpos;
   private int groundsToSpawn = 5, treesToSpawn = 2;

   [SerializeField] private float generateLevelWaitTime = 3f;

   private float waitTimer;

   private void Start()
   {
      StartCoroutine("SpawnBG");
   }

   private IEnumerator SpawnBG()
   {
      while (true)
      {
         GenerateGrounds();
         
         GenerateTrees();

         yield return new WaitForSeconds(generateLevelWaitTime);
      }
   }
   
   

   private void GenerateGrounds()
   {
      Vector3 groundPosition=Vector3.zero;

      for (int i = 0; i < groundsToSpawn; i++)
      {
         groundPosition = new Vector3(lastGroundXPos, groundYpos, 0f);
         Instantiate(groundPrefab, groundPosition, Quaternion.identity).transform.SetParent(transform);

         lastGroundXPos += groundXDistance;
      }
   }

   private void GenerateTrees()
   {
      Vector3 treePosition=Vector3.zero;

      for (int i = 0; i < treesToSpawn; i++)
      {
         treePosition = new Vector3(lastTreeXpos, treeYPos, 0f);
         if (Random.Range(0,2)>0)
         {
            Instantiate(tree1Prefab, treePosition, Quaternion.identity).transform.SetParent(transform);
            Instantiate(tree2Prefab, treePosition, Quaternion.identity).transform.SetParent(transform);
         }
         else
         {
            Instantiate(tree2Prefab, treePosition, Quaternion.identity).transform.SetParent(transform);
            Instantiate(tree1Prefab, treePosition, Quaternion.identity).transform.SetParent(transform);
         }

         lastTreeXpos += treeXDistance;
      }
   }
}
