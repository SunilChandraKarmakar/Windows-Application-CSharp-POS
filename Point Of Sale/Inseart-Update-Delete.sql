select Id, Name
from city

insert into city(name) values('Comilla')

select *
from ledger

select ledger.id, ledger.name, ledger.contact, ledger.email, ledger.gander, city.name as city
from ledger
left join city on ledger.cityId = city.id

select ledger.id, ledger.name, ledger.contact, ledger.email, ledger.gander, city.name as city, country.name as country
from ledger
left join city on ledger.cityId = city.id
left join country on city.countryId = country.id

create view vwLedger as
select ledger.id, ledger.name, ledger.contact, ledger.email, ledger.gander, city.name as city, country.name as country,
((select sum (debit) from [transaction] where ledgerId = ledger.id) - (select sum (credit) from [transaction] where ledgerId = ledger.id)) as Balence
from ledger
left join city on ledger.cityId = city.id
left join country on city.countryId = country.id


select ledger.id, ledger.name, ledger.contact, ledger.email, ledger.gander, city.name as city
from ledger
right join city on ledger.cityId = city.id

select ledger.id, ledger.name, ledger.contact, ledger.email, ledger.gander, city.name as city
from ledger
full join city on ledger.cityId = city.id

insert into ledger(name, contact, email, password, gander, dateOfBirth, address, type)
values('Rubel Hasan', '01786320183', 'rubel@gmail.com', '12354', 1, '3/1/2018', 'Na', 'C')

select *
from [transaction]
