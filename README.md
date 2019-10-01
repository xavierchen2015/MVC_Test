# MVC_Test
MVC Test

- 請下載程式
- 使用 VS 2019 開啟
- 開啟工具->NuGet封裝管理員->管理方案的NuGet套件
- 按「還原」下載套件

裡面有2個專案，因為時間關係，還有很多地方沒辦法完善
包括驗證、LOG、DB PASSWOWD 等等

## MVC_Test
- 實作建立DB(設定在電腦D目錄)及預設資料
- 利用 bootstrap admin theme 套版

## WebApi
- 使用 GET 讀取單筆資料 EX: https://localhost:44365/api/books/1
  ```
  回傳資料
  {
      "code": "0",
      "msg": "OK",
      "result": {
          "Id": "1",
          "Name": "被討厭的勇氣：自我啟發之父「阿德勒」的教導",
          "PublicDate": "2014-10-30T00:00:00",
          "Score": 8
      }
  }
  ```
- 使用 DELETE 刪除單筆資料 EX: https://localhost:44365/api/books/1
  ```
  回傳資料
  {
      "code": "0",
      "msg": "OK",
      "result": null
  }
  ```
- 使用 PUT 更新單筆資料 EX: https://localhost:44365/api/books/2
  ```
  傳送 JSON 來更新資料
  {
    "token": "xsdaasdasdsada",
    "data": [
      {
        "Id": 2,
        "Name": "目錄"
      }
    ]
  }
  ```
- 使用 POST 可新增多筆資料 EX: https://localhost:44365/api/books
  ```
  傳送 JSON 來傳改資料
  {
    "token": "xsdaasdasdsada",
    "data": [
      {
        "Id": 7,
        "Name": "Asp .Net MVC",
        "PublicDate": "2018-10-30T00:00:00",
        "Score": 8
      },
      {
        "Id": 8,
        "Name": "應用程式",
        "PublicDate": "2017-10-30T00:00:00",
        "Score": 5
      }
    ]
  }
  ```
