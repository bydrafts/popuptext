using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;

namespace Drafts.TextPopups.Animations
{
    [Preserve, Serializable]
    public class BlinkColor : IPopupTextAnimation
    {
        public Gradient gradient;
        public float duration = .5f;
        public int times;
        public bool pingPong = true;
        public bool useAlpha;

        public IEnumerator Play(TMP_Text text)
        {
            for (var i = times < 1 ? -100 : 0; i < times; i++)
            for (var j = 0f; j < duration; j += Time.deltaTime)
                yield return Apply(text, j, i);

            yield return Apply(text, 1, times - 1);
        }

        public void ResetText(TMP_Text orig, TMP_Text clone)
        {
            clone.color = orig.color;
        }

        private object Apply(TMP_Text text, float j, int i)
        {
            var t = j / duration;
            if (pingPong && i % 2 == 1) t = 1 - t;

            var color = gradient.Evaluate(t);
            if (!useAlpha) color.a = text.color.a;

            text.color = color;
            return null;
        }
    }
}