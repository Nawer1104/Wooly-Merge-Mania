using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject sheepPrefab;

    public List<GameObject> sheeps;

    public Transform[] sheeps_SpawnPos;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }
     
    public void Spawn()
    {
        if (sheeps.Count == 0)
        {
            foreach(Transform point in sheeps_SpawnPos)
            {
                GameObject sheep = Instantiate(sheepPrefab, point.position, Quaternion.identity);
                sheeps.Add(sheep);
            }
        }
    }
}