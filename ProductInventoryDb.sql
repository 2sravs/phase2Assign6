create database ProductInvetory1Db 
use ProductInvetory1Db 
create table Prds
(PId int primary key,
PName nvarchar(50),
PPrice decimal,
PQty int,
MfDate date,
ExpDate date)
insert into Prds values (111,'wheat',550.50,1,'10/09/2021','09/10/2021')
insert into Prds values (112,'biscuit',440.56,2,'12/12/2019','12/12/2018')
insert into Prds values (113,'ice cream',345.78,3,'12/12/2000','02/12/2019')
insert into Prds values (114,'Sugar',655.45,4,'11/12/2012','3/11/2022')
insert into Prds values (115,'Cofee',8550.50,5,'10/10/2010','19/12/2023')
select * from Prds