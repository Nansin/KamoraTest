using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    [SerializeField] private Button btnRespawn;
    [SerializeField] private Image blockSelect;
    [SerializeField] private List<Color> colorsBlock;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        blockSelect.color = colorsBlock[(int)BlockType.Grass];
        btnRespawn.onClick.AddListener(OnClick_RespawnPlayer);
    }

    private void OnClick_RespawnPlayer()
    {
        PlayerController.Instance.transform.position = new Vector3(0, 1.5f, 0);
    }

    public void ChangeBlockSelect(BlockType blockType) 
    {
        blockSelect.color = colorsBlock[(int)blockType];
    }
}
