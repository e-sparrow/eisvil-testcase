using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Enemies
{
    public sealed class EnemyView
        : MonoBehaviour
    {
        public event Action OnClick = () => { };

        [SerializeField] private SpriteRenderer renderer;

        private Vector2 _tempSize;

        private void OnMouseUpAsButton()
        {
            OnClick.Invoke();
        }

        private void OnMouseDown()
        {
            _tempSize = renderer.transform.localScale;
            renderer.transform.localScale *= 0.85f;
        }

        private void OnMouseUp()
        {
            renderer.transform.localScale = _tempSize;
        }

        public void SetSprite(Sprite sprite)
        {
            renderer.sprite = sprite;
        }

        public void SetColor(Color color)
        {
            renderer.color = color;
        }

        public void SetSize(Vector2 size)
        {
            transform.localScale = size;
        }

        public void Die()
        {
            renderer.transform.DOScale(transform.localScale * 2f, 1f);
            
            renderer
                .DOColor(new Color(0, 0, 0, 0), 1f)
                .OnComplete(() => Destroy(gameObject));
        }
    }
}