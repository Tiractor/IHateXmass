using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(RawImage))]
public class TakeDamageCanvas : MonoBehaviour
{
    private float _decreaseTrasparencySpeed = 0.0001f;
    private float _addTrasparency = 0.1f;
    [SerializeField] private RawImage _hitImage;
    private Color _color = new Color(2.55f,0,0,0);
    private void Awake()
    {
        _hitImage = GetComponent<RawImage>();
        //_hitImage.texture = (Texture)UnityEditor.EditorUtility.InstanceIDToObject(43438);
        _hitImage.color = _color;
    }
    private void Update()
    {
        _hitImage.color = new Color(_color.r, 0f, 0f, Mathf.Clamp( _hitImage.color.a - _decreaseTrasparencySpeed, 0f, 1f));
    }
    public void isPlayerTakeDamage()
    {
        _hitImage.color = new Color(_color.r, 0,0, Mathf.Clamp(_hitImage.color.a + _addTrasparency,0f,0.5f ));
    }
}
