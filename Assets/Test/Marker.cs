using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using UI = UnityEngine.UI;

namespace TinyYoloV2
{

    sealed class Marker : MonoBehaviour
    {
        RectTransform _parent;
        RectTransform _xform;
        UI.Image _panel;
        UI.Text _label;

        // 추가한 변수들
        public string objectName;
        public int objectScore;

        void Start()
        {
            _xform = GetComponent<RectTransform>();
            _parent = (RectTransform)_xform.parent;
            _panel = GetComponent<UI.Image>();
            _label = GetComponentInChildren<UI.Text>();
        }

        public void SetAttributes(in BoundingBox box)
        {
            var rect = _parent.rect;

            // Bounding box position
            var x = box.x * rect.width;
            var y = (1 - box.y) * rect.height;
            var w = box.w * rect.width;
            var h = box.h * rect.height;

            _xform.anchoredPosition = new Vector2(x, y);
            _xform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, w);
            _xform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, h);

            // Label (class name + score)
            var name = Config.GetLabel((int)box.classIndex);

            //추가분
            objectName = name;
            objectScore = (int)(box.score * 100);

            _label.text = $"{name} {objectScore}%";

            // Panel color
            var hue = box.classIndex * 0.073f % 1.0f;
            var color = Color.HSVToRGB(hue, 1, 1);
            color.a = 0; // original -> 0.4
            _panel.color = color;

            // Enable
            gameObject.SetActive(true);
        }

        public void Hide()
          => gameObject.SetActive(false);
    }

} // namespace TinyYoloV2
