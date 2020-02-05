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
        
    }

    private void FixedUpdate()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var toTileVector = GridManager.FindNearestTile(_mousePosition);
        var tile = GridManager.GetGridTile((int)toTileVector.x, (int)toTileVector.y);
        transform.position = tile.transform.position;
    }
}
