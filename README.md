# About
This project demonstrates the use of Azure Functions with various triggers: Timer Trigger, HTTP Trigger, MySQL Changes Trigger, and MySQL Select.

# Stacks of this project
- .NET 8
- Azure Function
- MySQL
- Postman _(for API testing)_
- Visual Studio 2022

# MySQL script
Run the script to create the database and table. 

Inside of this project there is a folder named "mysql-script" with the file file "initial-script.sql"
![image](https://github.com/user-attachments/assets/db242f41-58eb-49aa-ac5c-4c66904b8b0a)

# Azure Function - Timer Trigger
This method is getting the data from MySQL every 10 seconds
![image](https://github.com/user-attachments/assets/fd0ced04-031b-4478-8fa6-dbdc995db878)
![image](https://github.com/user-attachments/assets/38c41208-2519-48ff-a810-80e5d896960a)

# Azure Function - Http Trigger
This method receive a HTTP request with verbs POST and GET
![image](https://github.com/user-attachments/assets/b942d2d7-f259-40ef-af00-75a8a7e9bc79)
![image](https://github.com/user-attachments/assets/de363af9-cde1-4c5c-8bfc-e86bed7b055f)
![image](https://github.com/user-attachments/assets/5ae86078-d547-4c5a-879a-0c6952b159d9)
![image](https://github.com/user-attachments/assets/d1a7a9f1-faa7-433a-ba4f-8753f15729ca)

# Azure Function - MySQL Change Trigger
This trigger is watching the table "Customer" for any change that will be executed
![image](https://github.com/user-attachments/assets/1f244cdb-3b3a-48f8-93f9-8a141c38c69c)

Update any data from Customer table
![image](https://github.com/user-attachments/assets/0c671af9-54fe-46f5-bedd-775b85ba0ca5)

It's triggered
![image](https://github.com/user-attachments/assets/4b111d71-ba95-482d-83ec-d2b8a8aa9fb8)
Console logs
![image](https://github.com/user-attachments/assets/ea641837-c09b-4146-b4b7-fb584babae7b)

# Azure Function - MySQL Input
![image](https://github.com/user-attachments/assets/050c0fb2-7485-4bc4-bd58-d2179dcdefb2)

It executes the query directly to database

![image](https://github.com/user-attachments/assets/4c1c3b3d-7b99-4cb0-aa76-ad205f0420ca)

![image](https://github.com/user-attachments/assets/a8a8344f-972d-4eac-96fc-04a047677bd9)
