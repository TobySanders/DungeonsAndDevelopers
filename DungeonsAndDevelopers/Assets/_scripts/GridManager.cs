using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject GridTile;
    public Vector2 GridDimensions;


    private GameObject[,] _grid;
    private Vector3 _origin;
    private Vector3 _tileSize;
    private Vector3 _tilePosition;



    // Start is called before the first frame update
    void Start()
    {
        _origin = transform.position;
        _origin.y = 0.1f;
        _tileSize = GridTile.transform.localScale;
        _grid = new GameObject[(int)GridDimensions.x, (int)GridDimensions.y];


        for (int y = 0; y < GridDimensions.y; y++)
        {
            var row = Instantiate(new GameObject(), transform);
            row.name = $"Row {y}";

            for (int x = 0; x < GridDimensions.x; x++)
            {
                _grid[x, y] = CreateGameTile(x, y, row.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetGridTile(int x, int y)
    {
        return _grid[x, y];
    }

    public Vector2 FindNearestTile(Vector3 position)
    {
        var result = new Vector2();

        result.x = Mathf.Round(position.x) * _tileSize.x;
        result.y = Mathf.Round(position.y) * _tileSize.y;

        if (position.x > GridDimensions.x)
            result.x = GridDimensions.x;
        if (position.x < _origin.x)
            result.x = _origin.x;

        if (position.z > GridDimensions.y)
            result.y = GridDimensions.y;
        if (position.z < GridDimensions.y)
            result.y = _origin.y;
      
        return result;
    }

    private GameObject CreateGameTile(int x, int y, Transform parent)
    {
        _tilePosition.x = x;
        _tilePosition.z = y;
        _tilePosition.Scale(_tileSize);
        var tile = Instantiate(GridTile,_origin + _tilePosition, GridTile.transform.rotation, parent);
        tile.name = $"{x},{y}";
        return tile;
    }

}
