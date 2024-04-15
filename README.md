[Read Me - English](https://github.com/WooChan-Noh/yoloProject/blob/main/ReadMeEng.md)    
[Read Me - Japanese](https://github.com/WooChan-Noh/yoloProject/blob/main/ReadMeJp.md)
# yoloProject
전시회 "Trip"에 사용할 사람 감지 앱의 알파 버전입니다. 


## Overview
안드로이드 빌드 앱입니다. Galaxy Tab 7+에서 테스트했습니다.



**I Used this projects**   
+ Native Gallery : https://github.com/yasirkula/UnityNativeGallery   
+ Tiny YOLOv2 : https://github.com/keijiro/TinyYOLOv2Barracuda   
+ Tool(for YOLOv2) : https://github.com/keijiro/TestTools   


## Learn more
이 앱은 사람을 감지하면 사진(스크린샷)을 찍어 갤러리에 저장합니다.


## Modifided Scripts
1. Maker.cs
  + 알파 값을 0으로 설정하여 바운딩 박스를 투명하게 만들었습니다.
  + `VisuallizerCPU.cs`에 사용할 문자열 변수를 넘깁니다.
2. VisualizerCPU.cs
  + `TakePucture()`를 추가했습니다.
  + 감지한 물체가 사람이며 score가 일정 수준 이상이고, 일정 시간동안 지속된다면 사진을 찍습니다.
---

![img4](https://github.com/WooChan-Noh/yoloProject/assets/103042258/b6ff9973-7aef-4251-850c-8d605ec4c232)
![img7](https://github.com/WooChan-Noh/yoloProject/assets/103042258/557a7e7a-aa9d-4443-b244-a2dabd836485)
![img10](https://github.com/WooChan-Noh/yoloProject/assets/103042258/e82c399f-1df0-4f23-ba53-a8dfa77044aa)


