using UnityEngine;
using UI = UnityEngine.UI;
using ImageSource = Klak.TestTools.ImageSource;
using static NativeCamera;
using System.Runtime.InteropServices;


// Package -> Test Tools -> Script -> ImageSource.cs에 native camera설정 함수(CameraCheck) 추가해 놓음
// 해당 패키지는 yolo 유니티 버전 제작자 github에서 필수로 요구하는 패키지

//Bounding Box 정보 활용을 위해 Test의 Marker.cs에 참고하기 위한 변수 추가해 놓음 (objectName,objectScore) 

namespace TinyYoloV2
{

    sealed class VisualizerCpu : MonoBehaviour
    {
        #region Editable attributes
        [SerializeField] ImageSource _source = null;
        [SerializeField, Range(0, 1)] float _scoreThreshold = 0.8f;
        [SerializeField, Range(0, 1)] float _overlapThreshold = 0.8f;
        [SerializeField] ResourceSet _resources = null;
        [SerializeField] UI.RawImage _previewUI = null;
        [SerializeField] Marker _markerPrefab = null;

        // Thresholds are exposed to the runtime UI.
        public float scoreThreshold { set => _scoreThreshold = value; }
        public float overlapThreshold { set => _overlapThreshold = value; }

        //직접 추가
        bool check = false;
        int humanScore;
        string fileName;
        string albumName = "tiny_yolo_v2";
        float time = 0f;
        [SerializeField] float delay = 5f;
        #endregion

        #region Internal objects

        ObjectDetector _detector;
        Marker[] _markers = new Marker[50];

        #endregion


        #region MonoBehaviour implementation

        void Start()
        {
            // Object detector initialization
            _detector = new ObjectDetector(_resources);

            // Marker populating
            for (var i = 0; i < _markers.Length; i++)
                _markers[i] = Instantiate(_markerPrefab, _previewUI.transform);


        }

        void OnDisable()
        {
            _detector?.Dispose();
            _detector = null;
        }

        void OnDestroy()
        {
            for (var i = 0; i < _markers.Length; i++) Destroy(_markers[i]);
        }

        void Update()
        {
            TakePicture();

            // Run the object detector with the image input.
            _detector.ProcessImage
          (_source.Texture, _scoreThreshold, _overlapThreshold);

            // Marker update
            var i = 0;

            foreach (var box in _detector.DetectedObjects)
            {
                if (i == _markers.Length) break;
                _markers[i++].SetAttributes(box);

            }

            for (; i < _markers.Length; i++) _markers[i].Hide();

            _previewUI.texture = _source.Texture;
        }

        #endregion
        void TakePicture()
        {
            humanScore = (int)(_scoreThreshold*100);
          
            time += Time.deltaTime;
          
            if (time >= delay)
            {
                check = false;
                time = 0f;
            }
            
            for (int j = 0; j < _markers.Length; j++)
            {
                if (_markers[j].objectName == "Person" && _markers[j].objectScore > humanScore && check == false)
                {
                    Debug.Log("humanScore : "+humanScore);
                    Debug.Log("cheese!");
                    check = true;
#if UNITY_EDITOR
                    fileName = "["+j+" Makers] Score-" + _markers[j].objectScore + "%_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
                    ScreenCapture.CaptureScreenshot(fileName); //set path?
                    Debug.Log("Before : " + _markers[j].objectName);
                    Debug.Log("Before : " + _markers[j].objectScore);
                    break;
                    
#elif UNITY_ANDROID
                    fileName = "Score-" + _markers[j].objectScore+"%_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";

                    // 스크린샷
                    Texture2D screenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
                    screenTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
                    screenTexture.Apply();

                    // 갤러리갱신
                    NativeGallery.SaveImageToGallery(screenTexture, albumName, fileName);

                    Destroy(screenTexture);
                    break;
#endif                   
                }
            }
        }
    }
} // namespace TinyYoloV2
