using UnityEngine;

public class ReticuleBehaviour : MonoBehaviour
{
    public GridManager GridManager;

    Vector3 _mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = Input.mousePosition;
        _mousePosition.z = 10;

        Debug.Log($"Mouse pos: {Input.mousePosition}");

        _mousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);

        Debug.Log($"Mouse pos to world : {_mousePosition}");

        var toTileVector = GridManager.FindNearestTile(_mousePosition);
        Debug.Log($"NearestTile: {toTileVector}");
        var tile = GridManager.GetGridTile((int)toTileVector.x, (int)toTileVector.y);

        Debug.Log($"Tile: {tile.transform.position.x} {tile.transform.position.z}");
        transform.position = tile.transform.position;
    }

    private void FixedUpdate()
    {

    }
}
