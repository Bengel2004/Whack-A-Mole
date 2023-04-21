using UnityEngine;

public class SelectRandomSprite : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private Sprite[] _allSprites;

    #endregion

    #region Private Fields

    private SpriteRenderer _renderer = default;

    #endregion

    #region Setup

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _renderer.sprite = _allSprites[Random.Range(0, _allSprites.Length)];
    }

    #endregion
}
