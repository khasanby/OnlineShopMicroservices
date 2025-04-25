﻿namespace Inventory.API.Products.GetProducts;

public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);

public record GetProductsResponse(IEnumerable<Product> Products);