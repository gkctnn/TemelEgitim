--ANSII
--Case insensitive

--SELECT * 
--FROM Customers

--SELECT ContactName AS 'Adı',CompanyName AS 'Şirket Adı',City AS 'Şehir' 
--FROM Customers

--SELECT * 
--FROM Customers 
--WHERE City = 'London'

--SELECT * 
--FROM Products 
--WHERE CategoryID = 1 OR CategoryID = 3

--SELECT * 
--FROM Products 
--WHERE CategoryID = 1 AND UnitPrice >= 10

--SELECT * 
--FROM Products 
--ORDER BY CategoryID, ProductName DESC --ascending / descending

--SELECT * 
--FROM Products 
--WHERE CategoryID = 1 
--ORDER BY UnitPrice DESC

--SELECT COUNT(*) 
--FROM Products

--SELECT CategoryID,COUNT(*) 
--FROM Products 
--GROUP BY CategoryID

--SELECT CategoryID,COUNT(*) 
--FROM Products 
--GROUP BY CategoryID 
--HAVING COUNT(*) < 10

--SELECT CategoryID,COUNT(*) 
--FROM Products 
--WHERE UnitPrice > 20 
--GROUP BY CategoryID 
--HAVING COUNT(*) < 10

--SELECT p.ProductID, p.ProductName, p.UnitPrice, c.CategoryName 
--FROM Products p
--INNER JOIN Categories c ON p.CategoryID = c.CategoryID
--WHERE p.UnitPrice > 10

--SELECT * 
--FROM Products p
--LEFT JOIN [Order Details] od ON p.ProductID = od.ProductID

--SELECT * 
--FROM Customers c
--LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
--WHERE o.CustomerID IS NULL

;WITH _tmpTable (ProductId, TotalPrice) as 
	(SELECT p.ProductID, FORMAT(SUM((od.UnitPrice * od.Quantity) - ((od.UnitPrice * od.Quantity) * od.Discount)),'N')
	FROM Products p
	LEFT JOIN [Order Details] od ON p.ProductID = od.ProductID AND od.OrderID IS NOT NULL
	LEFT JOIN Orders o ON od.OrderID = o.OrderID
	GROUP BY p.ProductID)

SELECT p.ProductName AS 'Ürün Adı', tmp.TotalPrice AS 'Kazanılan Toplam Miktar'
FROM Products p 
INNER JOIN _tmpTable tmp ON p.ProductID = tmp.ProductId
ORDER BY p.ProductName