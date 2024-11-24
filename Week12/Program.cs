1.Mis kategooriasse kuuluvad tooted coffee ja cocoa?
2. Mis tooted kuuluvad kategooriasse speciality product?
3. Kes on kohviku esimene külastaja?
4. Kes on tellinud kohvi?
5. Kes tellis kirsikooki? (cherry pie)
6. Kes on kohvikut külastanud rohkem kui ühte korda?
7. Mida tellis Lara Croft?
8. Kes on tellinud kuumi jooke?
9. Kui palju on kohvik teeninud pagaritooteid (bakery) müües?
10. Kes külastas kohvikut 6. mail?

SELECT * from ProductCategory

SELECT rowid, * from ProductCategory

SELECT rowid, * from Customer

SELECT rowid, * from Product

SELECT rowid, * from Orders

SELECT rowid, * from OrderDetails

1. Mis kategooriasse kuuluvad tooted coffee ja cocoa?

SELECT Product.ProductName, ProductCategory.CategoryName from Product
join ProductCategory
on Product.CategoryId = ProductCategory.rowid
WHERE Product.ProductName LIKE "Coffee" or Product.ProductName LIKE "Cocoa"

2. Mis tooted kuuluvad kategooriasse speciality product?

SELECT Product.ProductName, ProductCategory.CategoryName from Product
join ProductCategory
on Product.CategoryId = ProductCategory.rowid
WHERE ProductCategory.CategoryName LIKE "Speciality product"

3. Kes on kohviku esimene külastaja?

select customer.FirstName, Customer.LastName, orders.rowid as OrderNr from Orders
join Customer on Orders.CustomerId = Customer.rowid
order by orders.rowid desc limit 1

4. Kes on tellinud kohvi?

select Customer.FirstName, Customer.LastName, Product.ProductName from OrderDetails
join Orders on OrderDetails.OrderId = Orders.rowid
join Customer on orders.CustomerId = customer.rowid
JOIN Product on OrderDetails.ProductId = Product.rowid
where Product.ProductName like "Coffee"

5. Kes tellis kirsikooki? (cherry pie)

select Customer.FirstName, Customer.LastName, Product.ProductName from OrderDetails
join Orders on OrderDetails.OrderId = Orders.rowid
join Customer on orders.CustomerId = customer.rowid
JOIN Product on OrderDetails.ProductId = Product.rowid
where Product.ProductName like "cherry pie"

6. Kes on kohvikut külastanud rohkem kui ühte korda?

select Customer.FirstName, Customer.LastName, COUNT(orders.CustomerId) as TimesVisited from Orders
JOIN Customer on Orders.CustomerId = Customer.rowid
GROUP BY Customer.rowid
HAVING COUNT(orders.CustomerId) > 1

7. Mida tellis Lara Croft?

select Customer.FirstName, Customer.LastName, Product.ProductName from OrderDetails
join orders on OrderDetails.OrderId = Orders.rowid
join Customer on Orders.CustomerId = Customer.rowid
JOIN Product on OrderDetails.ProductId = Product.rowid
WHERE customer.FirstName LIKE "Lara" and Customer.LastName LIKE "Croft"

8. Kes on tellinud kuumi jooke?

select Customer.FirstName, Customer.LastName, Product.ProductName from OrderDetails
join orders on OrderDetails.OrderId = Orders.rowid
join Customer on Orders.CustomerId = Customer.rowid
JOIN Product on OrderDetails.ProductId = Product.rowid
JOIN ProductCategory on Product.CategoryId = ProductCategory.rowid
WHERE ProductCategory.CategoryName like "Hot drink"

9. Kui palju on kohvik teeninud pagaritooteid (bakery) müües?

select ProductCategory.CategoryName, SUM(Product.Price * OrderDetails.ProductQuantity) as Total from OrderDetails
join Product on OrderDetails.ProductId = Product.rowid
JOIN ProductCategory on Product.CategoryId = ProductCategory.rowid
where ProductCategory.CategoryName like "Bakery"

10. Kes külastas kohvikut 6. mail?

SELECT Customer.FirstName, Customer.LastName, Orders.DateOfOrder from Orders
join Customer on Orders.CustomerId = Customer.rowid
where Orders.DateOfOrder like "%6-May%"