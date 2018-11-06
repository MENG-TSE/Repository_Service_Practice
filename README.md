#Repository_Service_Practice  參考資料: http://kevintsengtw.blogspot.com/2012/10/aspnet-mvc-part2-repository.html

![Model](/READNE用的圖片/0.PNG)

#Part1 & Part2  沒有Commit，但行為相當簡單可以看以下的圖，看他的進化史，以下都用Category為例子，Product就不闡述了

#Part1 

       在Controller中使用interface類別來操作資料，把原本的Controller中的資料存取程式搬移到Repository中       
       兩個Controller中的方法都沒有直接對資料庫進行資料操作，而是透過Repository類別來進行資料的存取，在Controller就不在需要考慮到資料庫的存取操作，
       只需要考慮流程控制與資料的正確與否。
       
 ![Part1](/READNE用的圖片/Part1.PNG)

      

#Part2  把個別的Repository中相同的部分給抽離出來
  
    利用[泛型]將共同的部分給抽離出來另外建立IRepository介面、GenericRepository，改用這兩個來做資料的存取
    讓ICategoryRepository去繼承IRepository<Categories>
    
 ![Part2](/READNE用的圖片/2.PNG)
#Part3 非每一個類別的資料操作都是相同的，不是建立一個 GenericRepository 就可以滿足所有的需求，當各個類別有不同的資料存取需求時，應該怎麼做呢？

      把 Controller 中使用 GenericRepository<T> 的地方修改為使用各類別的 Repository



![Part3](/READNE用的圖片/3.PNG)


#Part4  抽出 Model 層並建立為類別庫專案


![Part4](/READNE用的圖片/4.PNG)


#Part5 建立Service層
        
        在 Repository 層裡，主要是用來操作資料的存取，例如應該要怎麼取得資料、取得多少的資料等，不牽涉商業邏輯的操作，而取得資料後的一些操作，例如訂單資料要去判斷訂單明細中貨品的存量是否可以出貨，像這樣的判斷處理並不適合放在 Repository 層之中，而 Repository 層為提供給 Service 層來使用。
        
        Controller 其主要的工作為系統流程的控制，依據傳入的需求來決定要存取哪些資料，並且決定要選擇 View 以回應到需求端，資料的存取已經交給 Repository 做處理中，而商業邏輯的處理也不適合放在 Controller 當中，過多的商業邏輯處理反而會讓 Controller 的流程控制與商業邏輯混在一起，使得程式會越來越複雜且難以維護，此外就是不利於測試。

        服務層，主要是把系統的商業邏輯給封裝起來，Service 層使用 Repository 層所提供的服務來存取資料， Controller 則是透過 Service 層來做資料的處理，而不直接使用 Repository。

        總結: Repositiry 主要負責資料的 CRUD，而 Service 則是處理商業邏輯的處理。
        
        
        之前的作法是 Solution 內並沒有區分 Service 層，而對於資料的存取操作雖然是由 Repository 負責，但呼叫使用的卻是 Controller，我們是在 Controller 做了 Service 要做的事情，
        而一開始也有提到，Repository 是用來服務 Service 的，Repository 主要的工作是做資料存取，加入了 Service 層之後，原先在 ICategoryRepository 與 IProductRepository 內所定義的方法就不再需要了，連帶 CategoryRepository 與 ProductRepository 也不需要建立了，將這些工作交給 Service 來處理，Repository 就只保留 GenericRepository。

        Mvc_Repository 5-2
        Web 與 Models 的關聯在於 Model 資料與定義.

        Web 與 Service 的關聯在於 controller 透過 service 來取得或更新 Model 資料.

        Service 與 Models 的關聯在於 controller 使用 Models 的 Respository 來對資料進行存取操作.

![5](/READNE用的圖片/5.PNG)
![5](/READNE用的圖片/-1.PNG)
![5](/READNE用的圖片/5-2.PNG)

#Part6 DI/IoC 使用 Unity.MVC

    DI：Dependency Injection 依賴注入.
    IoC：Inversion of Control 控制反轉.
    
    「程式的內容是針對介面而寫，而不是針對實作而寫」
    「物件反轉又稱為依賴注入，在物件導向設計中，一個用來降低物件之間耦合性的設計原則」
  
