using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;

namespace Drafts.TextPopups.Animations
{
    [Preserve, Serializable]
    public class SpringScale : IPopupTextAnimation
    {
        public AnimationCurve curve = new(
            new(0, 0), new(0.6f, 1.2f), new(0.8f, 0.95f), new(1, 1));
        public float duration = 0.5f;
        public float target = 1f;

        public void ResetText(TMP_Text orig, TMP_Text clone)
        {
            clone.transform.localScale = orig.transform.localScale;
        }

        public IEnumerator Play(TMP_Text text)
        {
            var originalScale = text.transform.localScale;
            var elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                var t = elapsedTime / duration;
                var scaleMultiplier = curve.Evaluate(t) * target;
                text.transform.localScale = originalScale * scaleMultiplier;
                yield return null;
            }

            var finalScale = curve.Evaluate(1f) * target;
            text.transform.localScale = originalScale * finalScale;
        }
    }
}