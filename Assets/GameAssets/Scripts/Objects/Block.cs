using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockType
{
    Grass,
    Sand,
    Stone
}

public class Block : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private BlockType blockType;
    [SerializeField] private BlockDatabase blockDatabase;

    private bool isDestroy = false;
    private float timeDestroyBlock = 1f;

    public bool IsDestroy { get => isDestroy; }
    public BlockType BlockType { get => blockType; set => blockType = value; }

    private void Start()
    {
        InitBlock();
    }

    public void InitBlock()
    {
        switch (blockType)
        {
            case BlockType.Grass:
                timeDestroyBlock = 1f;
                break;
            case BlockType.Sand:
                timeDestroyBlock = 2f;
                break;
            case BlockType.Stone:
                timeDestroyBlock = 3f;
                break;
            default:
                break;
        }
        meshRenderer.material = blockDatabase.blockDatas[(int)blockType].material;
    }    

    public void DestroyBlock()
    {
        if (timeDestroyBlock > 0)
        {
            timeDestroyBlock -= Time.deltaTime;
        }
        else
        {
            isDestroy = true;
        }
        Debug.Log("timeDestroyBlock: " + timeDestroyBlock);
    }
}
