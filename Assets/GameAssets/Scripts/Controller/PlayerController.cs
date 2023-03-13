using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private GameObject prefabBlock;
    [SerializeField] private Transform spawnBlock;

    [Header("Raycast")]
    [SerializeField] private Transform pointRaycast;
    [SerializeField] private Transform endPoint;

    private Vector3 vec;
    private BlockType blockTypeSelect;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CameraController.Instance.SetTarget(this.transform);
        blockTypeSelect = BlockType.Grass;
    }

    // Update is called once per frame  
    private void Update()
    {
        bool isLookAt = true;
        vec = transform.localPosition;
        if (Input.GetAxis("Jump") != 0)
        {
            vec.y += Input.GetAxis("Jump") * Time.deltaTime * 5;
            isLookAt = false;
        }
        vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * 5;
        vec.z += Input.GetAxis("Vertical") * Time.deltaTime * 5;
        if (isLookAt)
            transform.LookAt(vec);
        transform.localPosition = vec;

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Vector3 direction = endPoint.position - pointRaycast.position;
            Ray ray = new Ray(pointRaycast.position, direction);
            if(Physics.Raycast(ray, out hit))
            {
                Block block = hit.collider.gameObject.GetComponent<Block>();
                if (block != null)
                {
                    if (block.IsDestroy)
                    {
                        MapController.Instance.ListBlocks.Remove(new Vector3Int(Mathf.RoundToInt(block.transform.position.x)
                            , Mathf.RoundToInt(block.transform.position.y)
                            , Mathf.RoundToInt(block.transform.position.z)));
                        Destroy(block.gameObject);
                    }
                    else
                        block.DestroyBlock();
                }
            }
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }    
        if (Input.GetMouseButtonDown(1))
        {
            Vector3Int pos = new Vector3Int(Mathf.RoundToInt(spawnBlock.position.x), Mathf.RoundToInt(spawnBlock.position.y), Mathf.RoundToInt(spawnBlock.position.z));
            if (!MapController.Instance.ListBlocks.ContainsKey(pos))
            {
                GameObject block = Instantiate(prefabBlock, pos, Quaternion.identity);
                block.GetComponent<Block>().BlockType = (BlockType)Random.Range((int)BlockType.Grass, (int)BlockType.Stone + 1);
                MapController.Instance.ListBlocks.Add(pos, block.GetComponent<Block>());
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            blockTypeSelect++;
            if (blockTypeSelect > BlockType.Stone)
                blockTypeSelect = BlockType.Grass;
            UIController.Instance.ChangeBlockSelect(blockTypeSelect);
            Debug.Log(blockTypeSelect);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Vector3Int pos = new Vector3Int(Mathf.RoundToInt(spawnBlock.position.x), Mathf.RoundToInt(spawnBlock.position.y), Mathf.RoundToInt(spawnBlock.position.z));
            if (!MapController.Instance.ListBlocks.ContainsKey(pos))
            {
                GameObject block = Instantiate(prefabBlock, pos, Quaternion.identity);
                block.GetComponent<Block>().BlockType = blockTypeSelect;
                MapController.Instance.ListBlocks.Add(pos, block.GetComponent<Block>());
            }
        }
    }
}
