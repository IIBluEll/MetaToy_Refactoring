# 메타토이 드래곤즈 코드 리팩토링 

## 게임 소개
- __메타토이 드래곤즈란 샌드박스에서 주최했던 '천하제일 용손대회' 공모전에 참가하기 위해 제작했던 게임입니다.__
- __당시 최종 '4위'로 용손을 수상했습니다.__
 
<img src="https://user-images.githubusercontent.com/19919570/230828790-b83cf40a-accf-4841-b2dc-eee3373156f2.jpg" width="400">

* [__작업 과정이 궁금하다면 노션으로 놀러오세요!__][notion]
  
  [notion]: https://hmlee4135.notion.site/Hyunmin-Lee-1436d2f4b6a848a5896f6600b3892dc1

* [__개선 전 코드가 궁금하다면 깃허브도 보러오세요!__][github]
  
    [github]: https://github.com/Team5DD

* [__리팩토링 된 전체 프로젝트를 다운받고 싶으시다면 여기로 오세요!__][new]
  
    [new]: https://github.com/IIBluEll/MetaToy_Refactoring 


</n>

## 개선 전 게임 플레이 영상

[![OldVersionYT](https://img.youtube.com/vi/yil-smoRFbs/maxresdefault.jpg)](https://www.youtube.com/watch?v=yil-smoRFbs)

<br/>

***
<br/>

## 개선 후 게임 플레이 영상

[![OldVersionYT](https://img.youtube.com/vi/Et_NBJbYsxM/maxresdefault.jpg)](https://www.youtube.com/watch?v=Et_NBJbYsxM)

<br/>

* __사실 기능은 유지하며, 코드만 개선하는 것이 목표였기에 크게 바뀐 점은 없습니다.__
* __하지만 다음과 같은 기능이 <u>추가 및 변경 </u> 되었습니다.__
   * __스토리 스킵이 가능해졌습니다.__
    > * 기존에는 스토리를 한번 보게 되면 다음부턴 볼 수 없었습니다. <br/>
    > * 하지만 개선 후, 스토리를 스킵할 수 있거나, 볼 수 있는 선택지가 생겼습니다.
    > ![image](https://user-images.githubusercontent.com/19919570/230831822-d04bf01d-a66f-4b10-b076-237cd940095a.png)

    
  
   * __배경음악 기능이 수정되었습니다.__
    > * 기존에는 Udate 함수로 씬의 이름을 읽어 불필요한 리소스 사용이 많았습니다. <br/>
    > * `SceneManager.sceneLoaded += OnSceneLoad;` 기능을 통해 씬이 전환될 때마다 자동으로 OnSceneLoad() 메서드가 호출되게 하였습니다.
    > * 이로 인해, 리소스 관리 측면에서 효율성이 증가했습니다.
  
   * __스테이지 선택 UI가 추가되었습니다.__
    > * 기존에는 한 스테이지를 클리어하면, 무조건 다음 스테이지만 플레이가 가능했습니다.
    > * 이제는 스테이지를 선택할 수 있는 UI를 추가시켜, 플레이어가 원하는 스테이지를 고를 수 있습니다.
    > * 또한, 플레이어의 레벨에 맞춰 플레이 불가능한 스테이지는 비활성화 처리했습니다.
    > ![image](https://user-images.githubusercontent.com/19919570/230832150-ab3d4e76-3164-46a8-8967-b8c1be9743d2.png)

