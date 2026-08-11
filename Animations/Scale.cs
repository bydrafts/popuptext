using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;

namespace Drafts.TextPopups.Animations
{
    [Preserve, Serializable]
    public class Scale : IPopupTextAnimation
    {
        public AnimationCurve xCurve = AnimationCurve.Linear(0, 0, 1, 1);
        public AnimationCurve yCurve = AnimationCurve.Linear(0, 0, 1, 1);
        [Min(.1f)] public float duration = .5f;
        public int times = 1;

        public void ResetText(TMP_Text orig, TMP_Text clone)
        {
            clone.transform.localScale = orig.transform.localScale;
        }

        public IEnumerator Play(TMP_Text text)
        {
            for (var i = times < 1 ? -100 : 0; i < times; i++)
            for (var j = 0f; j < duration; j += Time.deltaTime)
                yield return Apply(text, j, i);

            yield return Apply(text, 1, times - 1);
        }

        private object Apply(TMP_Text text, float j, int i)
        {
            var t = j / duration;
            if (i % 2 == 1) t = 1 - t;
            var x = xCurve.Evaluate(t);
            var y = yCurve.Evaluate(t);
            text.transform.localScale = new Vector3(x, y, 1);
            return null;
        }
    }
}