# yoloProject
Detection app alpha version for exhibition "Trip" (by tinygem)   
Not used now.


## Overview
This is _Detection_ app (Android). Tested with Galaxy Tab 7+.   
"Detection" means Human Detection.   



**I Used this projects**   
+ Native Gallery : https://github.com/yasirkula/UnityNativeGallery   
+ Tiny YOLOv2 : https://github.com/keijiro/TinyYOLOv2Barracuda   
+ Tool(for YOLOv2) : https://github.com/keijiro/TestTools   
_**Before use, Check and Follow this pages!!**_

## Learn more
This app take a photo(Screenshot) when you detect a human and save it to your gallery


## Modifided Scripts
1. Maker.cs
  + Made the bounding box transparent. (set alpha 0)
  + String variable (used in VisuallizerCPU.cs)
2. VisualizerCPU.cs
  + Add `TakePucture()`
  + When a human is detected **above the set Humanscore** and it is detected continuously over a certain **period of time**, Take a photo
  + Take a photo = Screenshot
---

![img4](https://github.com/WooChan-Noh/yoloProject/assets/103042258/b6ff9973-7aef-4251-850c-8d605ec4c232)
![img7](https://github.com/WooChan-Noh/yoloProject/assets/103042258/557a7e7a-aa9d-4443-b244-a2dabd836485)
![img10](https://github.com/WooChan-Noh/yoloProject/assets/103042258/e82c399f-1df0-4f23-ba53-a8dfa77044aa)


