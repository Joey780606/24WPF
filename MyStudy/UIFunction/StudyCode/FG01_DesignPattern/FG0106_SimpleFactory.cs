/*
1. Function: Simple factory design pattern
2. Detail: Find some documents and related code.
3. Keyword:
4. 
 */

/*
1. 中文說明 (有工廠與鳥的小範例):
  https://raychiutw.github.io/2019/%E9%9A%A8%E6%89%8B-Design-Pattern-3-%E7%B0%A1%E5%96%AE%E5%B7%A5%E5%BB%A0%E6%A8%A1%E5%BC%8F-Simple-Factory-Pattern/
  說明內容: 
  1. 是相當易用的一種設計模式，當程式複雜度高的時候時候，可以利用此模式切割複雜度高的判斷式，抽離業務邏輯與建構式(主要是這個)
    ，讓業務邏輯單純，隔離複雜的建構式，有效提升程式碼的可讀性，藉由 C# 語法特性更可以降低程式複雜度。
    又稱為靜態工廠方法(Static Factory Method)模式

  2.角色會有三個:
    1. Product：抽象產品角色 (如例中的 IBird)
    抽象產品角色是所有產品的父類別，在 C# 來說可以是 抽象類別 (Abstract Class) 或者是 介面 (Interface)，公開屬性與方法簽章，外部程式依賴此角色。

    2. ConcreteProduct：具體產品角色 (如例中的 Eagle, Swan類別)
    具體產生的產品實體，藉由工廠角色依據條件而建立。

    3. Factory：工廠角色 (如例中的 BirdFactory,較複雜的判斷在此實踐
    工廠角色負責建立對應的物件。
*/