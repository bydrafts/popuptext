using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Drafts.TextPopups
{
    public class PopupTextManager : MonoBehaviour
    {
        public TMP_Text textTemplate;

        private readonly Stack<TMP_Text> _pool = new();
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
            textTemplate.gameObject.SetActive(false);
        }

        public Coroutine ShowPopup(Vector3 worldPos, string text, PopupTextAnimation anim)
        {
            var pos = _camera.WorldToScreenPoint(worldPos);
            return StartCoroutine(PlayAndTrash(pos, text, anim));
        }
        
        public Coroutine ShowWorldPopup(Vector3 worldPos, string text, PopupTextAnimation anim)
        {
            return StartCoroutine(PlayAndTrash(worldPos, text, anim));
        }

        private IEnumerator PlayAndTrash(Vector3 pos, string text, PopupTextAnimation anim)
        {
            var clone = _pool.TryPop(out var t) ? t : Instantiate(textTemplate, textTemplate.transform.parent);
            clone.transform.position = pos;
            clone.text = text;
            
            clone.gameObject.SetActive(true);
            yield return anim.Play(clone);  
            clone.gameObject.SetActive(false);
            
            anim.ResetText(textTemplate, clone);
            _pool.Push(clone);
        }
    }
}