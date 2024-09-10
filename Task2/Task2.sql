SELECT p.Name AS 'Product name', c.Name AS 'Category name' FROM 
Products AS p
	LEFT JOIN Products_Categories AS pc ON p.Id = pc.ProductId
	LEFT JOIN Categories AS c ON c.Id = pc.CategoryId