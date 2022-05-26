use BookStore;
go
create or alter function GetNewBooks()
returns table
as return select * from Books where year(YearIzdat) >= year(getdate())
go
create or alter function GetPopularBooks()
returns table
as return select * from Books where NameBoook in (select top 10 NameBoook from Books group by NameBoook order by count(NameBoook) desc);
go
create or alter function GetPopularAuthor()
returns table
as return select * from Books where FIOAuthor in (select top 10 FIOAuthor from Books group by FIOAuthor order by count(FIOAuthor) desc);
go
create or alter function GetPopularGenre()
returns table 
as return select * from Books where Genre in (select top 10 Genre from Books group by Genre order by count(Genre) desc)
go
exec sp_refreshsqlmodule 'dbo.GetNewBooks'
exec sp_refreshsqlmodule 'dbo.GetPopularBooks'
exec sp_refreshsqlmodule 'dbo.GetPopularAuthor'
exec sp_refreshsqlmodule 'dbo.GetPopularGenre'
select * from GetPopularBooks();
select * from GetPopularAuthor();
select * from GetPopularGenre();
