-- Select Concat(CustomerName,WebsiteURL) "NameAndWebSite"
-- From Sales.Customers

-- select CustomerName, PhoneNumber
-- from Sales.Customers

-- select CustomerName, LEFT(CustomerName, 3) as "FirstThreeChar"
-- from sales.Customers

-- select Left(CustomerName, 1) "CustomerInitial", Count(CustomerID) as Count
-- from Sales.Customers
-- Group by LEFT(CustomerName, 1)

SELECT
        DATEPART(ww, o.OrderDate) as "Week",
        DATEPART(dw, o.OrderDate) as "DayOfWeek",
        Count(OrderID) as "NumberOfOrders"
From [Sales].[Orders] o
Group by DATEPART(ww, o.OrderDate), DATEPART(dw, o.OrderDate)
Order by 1,2
