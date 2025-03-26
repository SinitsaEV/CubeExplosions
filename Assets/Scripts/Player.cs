using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] LayerMask _layerMask;
    private Ray _ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity, _layerMask))
        {
            hit.collider.gameObject.GetComponent<Cube>().Show();
            Destroy(hit.collider.gameObject);
        }
    }
}
