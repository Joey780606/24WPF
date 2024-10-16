/*
1. Function: Event sample code
2. Detail: Find some useful code about how to use Event.
3. Keyword: [Event]
4. 
 */

/*
Code area 1: 
  1. Ref: https://www.youtube.com/watch?v=fnT1HA0zCEo&list=PLJgD_fXVXZKpI1FIW0ZtT_lLnML8uPhST&index=22 (code看影片即可)
    a. event只能在類的成員裡面宣告 (影片4:25)
    b. event是在委托語句前加入 (影片3:35)
    c. ppt裡的介紹 (影片5:24很重要)
    d. event是以委託為基礎,為委託提供一個發佈/訂閱機制,可說事件是一種具有特殊簽名的委託
    e. 事件聲明: public event 委託類型 事件名;
      事件使用event關鍵字來聲明,返回類值是一個委託類型
      事件的命名,通常以 名字+Evnet 作為他的名稱,儘量使用此規範1
    f. event和delegate的區別:
      4:15 委託聲明可以建立一個局部變數,事件只能在類的成員裡面宣告,不能在類的函式裡宣告 (但這非主要區別)
*/