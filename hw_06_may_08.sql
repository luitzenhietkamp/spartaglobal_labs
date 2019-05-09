use Northwind

/* create some queries using these  keywords on the Northwind database */

/* 1. sum */
/* Compute total freight cost of all orders */
select SUM(Freight) as 'Total freight costs' from Orders

/* 2. avg */
/* Compute average freight cost */
select AVG(Freight) as 'Average freight cost' from Orders

/* 3. Min/max */
/* Find most expensive product */
select ProductName as 'Most expensive product' from Products
	where UnitPrice=(select max(UnitPrice) from Products)

/* Find cheapest product */
select ProductName as 'Cheapest product' from Products
	where UnitPrice=(select min(UnitPrice) from Products)

/* 4. count */
/* total number of employees */
select count(1) as 'Number of employees' from Employees

/* 5. group by ??? */
/* Number of suppliers by country */
select Country, count(1) as 'Number of suppliers'
	from Suppliers group by Country

/* 6. having ??? */
/* Create a list of cities with at least 1 customer,
   sorted by number of customers per city */
select City as 'Cities with multiple customers',
	count(1) 'Number of customers'
	from Customers
	group by City
	having count(1) > 1
	order by 'number of customers' DESC

/* 7. inner join */
/* Rank employees by total number of sales */
select Employee, Count(1) as Sales
	from
	(
		select FirstName + ' ' + LastName as Employee
		from Employees
		inner join Orders
		on Employees.EmployeeID = Orders.EmployeeID
	) as Employees
	group by Employee
	order by Sales DESC