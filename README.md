## CrossFinance

* [General info](#general-info)
* [Technologies](#technologies)
* [Configuration](#configuration)
* [Print screens](#print-screens)

## General info
* Recruitment project for CrossFinance company.  Simple apliccation, which transform data from excel file to MySql four tables.  Use validation PESEL number.


## Technologies
* C# MVC 
* Entity Framework 
* MySql.Data.EntityFramework
* LinqToExcel
* Bootstrap 

## Configuration

* Create MySql database from: [script sql](https://github.com/farti/CrossFinance/blob/master/CrossFinance/DataBaseScript/crossfinance.sql) 
  as a localhost , password empty or set it , and change in Web.Config file:  
  
  ```C#
  <connectionStrings>
    <add name="ApplicationDbContext" 
         connectionString="metadata=res://*/Models.crossfinanceModel.csdl|res://*/Models.crossfinanceModel.ssdl|res://*/Models.crossfinanceModel.msl;provider=MySql.Data.MySqlClient;provider connection string=&quot;server=localhost;user id=root;password=;database=crossfinance&quot;" 
         providerName="System.Data.EntityClient" />
  </connectionStrings>
  ```
* Clone repository, double click on CrossFinance.sln file in Solution Explorer ( check if Default project is set )
* Go to Package Manager Console and run Update-Package 
* Build and run app !

## Print screens
![alt text](https://github.com/farti/CrossFinance/blob/master/CrossFinance/img/ps1.PNG)  

![alt text](https://github.com/farti/CrossFinance/blob/master/CrossFinance/img/ps2.PNG)

 
