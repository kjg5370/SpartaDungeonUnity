<h2>[2023] SpartaDungeonUnity 🎮</h2>

**(스파르타 던전 Unity 버전 만들기)**

던전을 떠나기전 마을에서 장비를 구하는 게임을 구현하였습니다.<br> 자신의 칭호, 이름, 레벨, 경험치, 가지고있는 골드를 볼 수 있고 스테이터스 창과 인벤토리 그리고 상점에서 원하는 장비를 살 수 있습니다.😊
</div>

## 목차
  - [개요](#개요) 
  - [설명](#설명)
  - [게임 요소](#게임-요소)
  - [요구사항 달성도](#요구사항-달성도)

## 개요
- 프로젝트 이름: SpartaDungeonUnity
- 프로젝트 지속기간: 2023.09.19-2023.09.22
- 개발 엔진 및 언어: Unity & C#
- 멤버 : 김진규
## 설명
|![image](https://github.com/kjg5370/SpartaDungeonUnity/assets/105926662/cd9d5fd4-e17d-46dc-8848-a26bcaac2ffe)
|:---:|
|시작 화면|

던전을 모험하는 RPG게임의 요소 중 메인 화면의 구성을 연습하기 위하여 만들었습니다.<br>
- 자신의 정보를 한눈에! 🦉<br>
자신의 칭호, 이름, 레벨, 경험치 그리고 칭호의 설명을 볼 수 있도록 화면을 구성하였습니다.
- 다양한 상호작용 버튼들! ⚔️<br>
자신의 스테이터스나 인벤토리를 확인할 수 있습니다. 오른쪽 버튼을 통해 현재 플레이어의 추가적인 스탯 아이템 정보를 확인할 수 있습니다.
- 나만의 장비를 사보자! 💎<br>
상점을 통해 원하는 장비를 구매할 수 있습니다. 구매를 한 아이템은 플레이어의 소유가 되서 인벤토리에 저장됩니다.

## 게임 요소
- 상호작용 UI들

|Info|Status|Inventory|Shop|
|---|---|---|---|
|![image](https://github.com/kjg5370/SpartaDungeonUnity/assets/105926662/34ad4e04-e394-43a6-8d66-d5046696ab72)|![image](https://github.com/kjg5370/SpartaDungeonUnity/assets/105926662/e5ea3d31-03a5-47fa-b723-aecea63e0511)|![image](https://github.com/kjg5370/SpartaDungeonUnity/assets/105926662/eb85ba7f-1412-4fee-bd45-afc1e539aacb)|![image](https://github.com/kjg5370/SpartaDungeonUnity/assets/105926662/ae9fdf08-c08f-4253-ade9-7e38d43da41f)|
|플레이어 정보|플레이어의 스테이터스 확인 가능|플레이어가 가지고 있는 아이템 확인 가능|다양한 아이템 구매 가능 (단, 골드가 충분해야 됨.)

## 요구사항 달성도
- 필수요구사항
   1. 메인 화면 구성
      - 아이디
      - 레벨
      - 골드
      - Status 버튼  - 2. Status 보기
      - Inventory 버튼  - 3. Inventory 보기
   2. Status 보기
      - Status 버튼, Inventory 버튼 - 사라지기
      - 우측에 캐릭터 정보 표현
      - 뒤로가기 버튼을 누르면 1번 화면으로 이동
   3. Inventory 보기
      - Status 버튼, Inventory 버튼 - 사라지기
      - 우측에 인벤토리 표시
      - 아이템을 클릭하면 장착관리
      - 장착중인 아이템은 표시
- 선택요구사항
   1. 아이템 장착 팝업 업그레이드
      - 아이템을 클릭하면 해당 정보가 팝업에 나타나도록 적용
   2. 상점 기능
      - 상점 버튼 추가
      - 구매 완료 후 팝업
      - 구매한 아이템은 인벤토리로 추가
      - 상점 아이템이 넘어간다면 스크롤 되게 적용
- 추가 기능
   1. 아이템 장착 시 스테이터스 반영
   2. 상점 아이템 구매시 플레이어 골드 반영
      - 플레이어 골드 - 아이템 가격
      - 플레이어 골드 < 아이템 가격 이면 아이템 구매 불가능
   3. 캐릭터 Idle 애니메이션 추가
