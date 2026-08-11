using System.Collections;
using TMPro;
using UnityEngine;

namespace Drafts.TextPopups
{
    [CreateAssetMenu(menuName = "Drafts/PopupTextAnimation")]
    public class PopupTextAnimation : ScriptableObject
    {
        [SerializeField] private float duration = 2f;
        [SerializeReference, TypeInstance] private IPopupTextAnimation[] modules;

        public IEnumerator Play(TMP_Text text)
        {
            foreach (var module in modules)
                text.StartCoroutine(module.Play(text));

            yield return new WaitForSeconds(duration);
            text.StopAllCoroutines();
        }

        public void ResetText(TMP_Text orig, TMP_Text clone)
        {
            foreach (var module in modules)
                module.ResetText(orig, clone);
        }
    }
}