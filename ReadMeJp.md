# yoloProject
展示会「Trip」で使用する人検知アプリのアルファ版です。


## Overview
Androidビルドアプリです。Galaxy Tab 7+でテストしました。



**I Used this projects**   
+ Native Gallery : https://github.com/yasirkula/UnityNativeGallery   
+ Tiny YOLOv2 : https://github.com/keijiro/TinyYOLOv2Barracuda   
+ Tool(for YOLOv2) : https://github.com/keijiro/TestTools   


## Learn more
このアプリは人を検知すると写真(スクリーンショット)を撮ってギャラリーにセーブします。


## Modifided Scripts
1. Maker.cs
  + アルファ値を0に設定してバウンディングボックスを透明にしました
  + `VisuallizerCPU.cs`で使うstringを渡します.
2. VisualizerCPU.cs
  + `TakePucture()`を追加しました.
  + 検出したオブジェクトが人であり、scoreが一定レベル以上であり、一定時間続いた場合、写真を撮ります。
---

![img4](https://github.com/WooChan-Noh/yoloProject/assets/103042258/b6ff9973-7aef-4251-850c-8d605ec4c232)
![img7](https://github.com/WooChan-Noh/yoloProject/assets/103042258/557a7e7a-aa9d-4443-b244-a2dabd836485)
![img10](https://github.com/WooChan-Noh/yoloProject/assets/103042258/e82c399f-1df0-4f23-ba53-a8dfa77044aa)


