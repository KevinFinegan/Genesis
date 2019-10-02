USE Orders
GO

CREATE PROCEDURE dbo.spr_SelectAllOrdersWithCustomers
AS

SELECT ORD.Id [OrderId], ORD.ReferenceNumber, ORD.OrderValue, ORD.OrderDate, CST.Id [CustomerId], CST.FirstName, CST.LastName 
FROM [Order] ORD
	INNER JOIN Customer CST ON
		ORD.CustomerId = CST.Id

GO


CREATE UNIQUE NONCLUSTERED INDEX [UIX_Customer_FirstName_LastName] ON Customer (FirstName, LastName)
GO