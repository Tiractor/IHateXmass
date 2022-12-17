using UnityEngine;
using UnityEngine.AI;

namespace ExplosiveEnemySpace
{
    public class NavMeshBaker : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<NavMeshSurface>().BuildNavMesh();
        }
    }
}
