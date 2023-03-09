# holoapp

環境

* Unity 2020.3.37f1

* Mixed Reality Toolkit Version 2.7.3

# 説明

目標地点に向かってお化けが追いかけるアプリです

手前にあるボタンを押すことで追いかけるものを決めます

https://youtu.be/NNTFITJgNOo

# 各種コード使い方 

holoapp/Assets/DateAsset/Script

* chase_finger.cs

指先に向かって指定したオブジェクトが追いかけます．

inspectorから追いかけてほしいオブジェクトをchaseObjにセット

chase_flagにチェックをつけると追いかけます．

また，chase_flagはSet_chase_flagまたはSet_chase_flag_falseでオンオフが切り替えられます．

* chase_obj.cs

任意のオブジェクトを指定したオブジェクトが追いかけます．

inspectorから追いかける目標地点となるオブジェクトをdestinationにセット

追いかけてほしいオブジェクトをchaseObjにセット

chase_flagにチェックをつけると追いかけます．

また，chase_flagはSet_chase_flagまたはSet_chase_flag_falseでオンオフが切り替えられます．

# モデル

holoapp/Assets/models/

* apple.fbx

* obake.fbx

これらのモデルはナツロジさんに作って頂きました．

https://www.pixiv.net/users/36803206
