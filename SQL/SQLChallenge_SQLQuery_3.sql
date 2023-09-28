SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- uspLogError logs error information in the ErrorLog table about the
-- error that caused execution to jump to the CATCH block of a
-- TRY...CATCH construct. This should be executed from within the scope
-- of a CATCH block otherwise it will return without inserting error
-- information.
CREATE PROCEDURE [dbo].[GetCustomerPurchaseData-GS]
    @StartingLetterOfCustomerName nvarchar(10) = '%', -- contains the ErrorLogID of the row inserted
    @FilterAmountLow int = 0,
    @FilterAmountHigh int = 1000000
AS                             -- by uspLogError in the ErrorLog table
BEGIN
    SET NOCOUNT ON;
    select
    c.CustomerID as [CustomerID],
    c.FirstName + ',' + c.LastName as [Customer Name],
    c.EmailAddress as [Customer Email],
    c.Phone as [Customer Phone],
    soh.SalesOrderID as [Sales Order ID],
    soh.Subtotal as [Order Subtotal],
    soh.TaxAmt as [Order Amount Due],
    soh.TotalDue as [Order Amount Due]
    From SalesLT.SalesOrderHeader soh JOIN SalesLT.Customer c On soh.CustomerID=c.CustomerID
    WHERE c.FirstName + ',' + c.LastName like @StartingLetterOfCustomerName
    AND soh.SubTotal BETWEEN @FilterAmountLow and @FilterAmountHigh
    Order by [Customer Name], [Order Subtotal] Desc;
END;
GO


exec [dbo].[GetCustomerPurchaseData-GS] default, 0, 1000;
