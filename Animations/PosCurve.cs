using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;

namespace Drafts.TextPopups.Animations
{
    [Preserve, Serializable]
    public class PosCurve : IPopupTextAnimation
    {
        public float duration = 1f;
        public Vector2 offset = new(50, 50);
        public float fontSizeReference = 36f;
        public AnimationCurve xCurve = AnimationCurve.Constant(0, 1, 0);
        public AnimationCurve yCurve = AnimationCurve.Constant(0, 1, 0);

        public void ResetText(TMP_Text orig, TMP_Text clone) { }

        public IEnumerator Play(TMP_Text text)
        {
            var scale = text.fontSize / fontSizeReference;
            var scaledOffset = offset * scale;
            var startPos = text.transform.position;
            var timer = 0f;

            while (timer < duration)
            {
                timer += Time.unscaledDeltaTime;
                var progress = timer / duration;
                var x = xCurve.Evaluate(progress) * scaledOffset.x;
                var y = yCurve.Evaluate(progress) * scaledOffset.y;
                text.transform.position = startPos + new Vector3(x, y, 0);
                yield return null;
            }
        }
    }
}