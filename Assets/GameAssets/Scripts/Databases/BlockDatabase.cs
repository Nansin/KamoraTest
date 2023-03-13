using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Database/Block")]
public class BlockDatabase : ScriptableObject
{
    public List<BlockData> blockDatas; 
}

[Serializable]
public class BlockData
{
    public BlockType blockType;
    public Material material;
}
