using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject parentGrasses;
    [SerializeField] private GameObject parentSands;
    [SerializeField] private GameObject parentStones;

    private List<Block> blocks = new List<Block>();

    public List<Block> Blocks { get => blocks; }

    private void Awake()
    {
        AddBlocks();
    }

    private void AddBlocks()
    {
        foreach (var item in parentGrasses.transform.GetComponentsInChildren<Block>())
        {
            blocks.Add(item);
        }
        foreach (var item in parentSands.transform.GetComponentsInChildren<Block>())
        {
            blocks.Add(item);
        }
        foreach (var item in parentStones.transform.GetComponentsInChildren<Block>())
        {
            blocks.Add(item);
        }
    }
}
