using Unity.Netcode;
using UnityEngine;
public class PlayerSpawn : MonoBehaviour
{
//    public PlayerSpawn Place;
    public static PlayerSpawn PlaceRef;
    // Update is called once per frame
    private void OnValidate()
    {
        PlaceRef = this;
    }
    void OnDestroy()
    {
        if(PlaceRef == this) PlaceRef = null;
    }
}
