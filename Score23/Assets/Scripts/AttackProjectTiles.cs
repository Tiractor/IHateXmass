using UnityEngine;

public class AttackProjectTiles : MonoBehaviour
{
    [SerializeField] private GameObject _projectTile;
    [SerializeField] private float _delayBetweenProjectTiles = 3f;
    private Unit _unit;
    private AttackType _Attack;
    private Unit _player;

    private float _delay = 0f;
    GameObject _temporaryProjectTile;
    private void Awake()
    {
        _unit = GetComponent<Unit>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Unit>();
    }
    private void Update()
    {
        _delay = Mathf.Clamp(_delay + Time.fixedDeltaTime, 0, _delayBetweenProjectTiles + 1f);

        if ( (_player.transform.position - transform.position).magnitude < 15f )
        {
            if (_delay > _delayBetweenProjectTiles ) 
            {
                _temporaryProjectTile = Instantiate(_projectTile);
                _temporaryProjectTile.transform.position = transform.position + transform.forward;
                _temporaryProjectTile.AddComponent<ProjectTile>().InitializeProjectTile();
                Debug.Log(_delay);
                _delay = 0f;
            }
        }
    }
}

public class ProjectTile : MonoBehaviour
{
    private Unit _player;
    public void InitializeProjectTile()
    {
        _player = _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Unit>();
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _player.gameObject.transform.position + Vector3.up, 0.01f);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
