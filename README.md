# personalProject-issac-

issue: 캐릭터 움직임이 자연스럽지 않은 이슈 (2023-02-13)
        끝 방으로 움직이는 루트중 방이 겹치는 이슈(2023-02-15)
        방을 이동하면 좌 우 끝방이 이상하게 나오는이슈(2023-02-17)
        

summury: 캐릭터 움직임이 issac과 다름 (2023-02-13)
        각 맨 끝방에 가는 루트 중 이미 길이 있는데도 최단거리를 찾아서 다시 길을 만들어 방이 겹치는 문제 발생(2023-02-13)
        좌우 각 끝 방에 도착하면 문이 이상하게 열리며, 들어갈 수 있는 위치임에도 들어가지지 않는 문제 발생(2023-02-17)

solve: 캐릭터 움직임이 issac과 다른이유는 addforce가 아닌 velocity를 사용했기 때문에 Addforce를 통해       
        이동하고 최대속도를 제한 해 줬다.(2023-02-14)
        최단루트를 저장한 배열을 생성한 후 그 위치에서 다시 BFS를 이용하여 마지막 점에서 시작점으로 모이도록 설정하여 해결했다.(2023-02-17)
        onEnable, start, awake 문제로 제대로 맵이 생성 되지 않았던 문제, 각 스크립트의 발생 순서를 차례대로 정리하여 문제 해결



start project // 0.0.1ver // 2023-02-13
Make Room // 0.0.2 ver // 2023-02-13
Make Item, Update ItemRoom // 0.0.3ver // 2023-02-14
Make ItemAnimation, Make MapLogic, Debug // 0.0.4ver // 2023-02-15
Finish MapLogic, Debug //0.0.5ver// 2023-02-17
Make SampleMonster, make Obj(boom), Debug //0.0.6ver // 2023-02-20