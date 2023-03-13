using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static MapController Instance;

    [SerializeField] private GameObject grounds;
    [SerializeField] private Transform grassParent;
    [SerializeField] private Transform sandParent;
    [SerializeField] private Transform stoneParent;

    private Dictionary<Vector3Int, Block> listBlocks = new Dictionary<Vector3Int, Block>();

    public Transform GrassParent { get => grassParent; }
    public Transform SandParent { get => sandParent; }
    public Transform StoneParent { get => stoneParent; }
    public Dictionary<Vector3Int, Block> ListBlocks { get => listBlocks; set => listBlocks = value; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitMap();
    }

    private void InitMap()
    {
        foreach (var chunk in grounds.transform.GetComponentsInChildren<Chunk>())
        {
            foreach (var block in chunk.Blocks)
            {
                listBlocks.Add(new Vector3Int(Mathf.RoundToInt(block.transform.position.x)
                    , Mathf.RoundToInt(block.transform.position.y)
                    , Mathf.RoundToInt(block.transform.position.z))
                    , block);
            }
        }
    }
}
