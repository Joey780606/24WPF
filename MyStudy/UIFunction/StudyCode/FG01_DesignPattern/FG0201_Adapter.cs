/*
1. Function: Adapter design patter
2. Detail: Find some document and related code.
3. Keyword:
4. 
 */

/*
1. 中文說明:
  https://medium.com/andy%E7%9A%84%E8%B6%A3%E5%91%B3%E7%A8%8B%E5%BC%8F%E7%B7%B4%E5%8A%9F%E5%9D%8A/20%E5%80%8B%E4%B8%BB%E9%A1%8C%E5%AD%B8%E6%9C%83%E8%A8%AD%E8%A8%88%E6%A8%A1%E5%BC%8F-%E4%BA%8C-%E8%90%AC%E8%83%BD%E8%BD%89%E6%8E%A5%E5%99%A8adapter%E6%A8%A1%E5%BC%8F-9e73ea5d872a
  說明內容: 
  1. Adapter的主要目的是想讓兩種東西可以互相適合，ex:想讓我的電腦投影到大螢幕，必須透過HDMI或VGA的轉接頭才能接上，轉接頭在做的事情就跟Adapter類似，可以將它想像成串接兩個獨立事務的一個媒介。
  在我們的程式當中，不是所有程式都能直接使用，需要經過一些轉換才可以使用，用來填補“現有的程式”和“新的程式需求”之間差異的設計模式就是Adapter模式，常有人把Adapter稱為Wrapper模式，意即將現有的程式包裝過後讓新的需求也能夠使用。
  2. Adapter的兩種實現方法: 1.使用繼承(Extend) 2.使用委託(Delegation)
  3. 有例子,但是Java,找其他C#例子
*/

/*
2. 英文範例
  https://www.youtube.com/watch?v=fJO7SnM74dM
  a.說明內容: 
   1. 使用情境: 已有舊的library,要研發新的library,有些功能舊的依然可做到,設計時就可使用此pattern,減少時間浪費
   2:05 本例使用視訊線的例子 (VGA格式要接DVI的格式)
  
  https://www.youtube.com/watch?v=HiFOmujCE8c  (這個不錯,但例子還是太多code了)
  https://medium.com/codenx/adapter-pattern-in-c-b69a32f53f7d (這是簡單的例子,但感覺實作出來 Paypal 和 Strip 還是二個各自的Adapter,無法整合
*/