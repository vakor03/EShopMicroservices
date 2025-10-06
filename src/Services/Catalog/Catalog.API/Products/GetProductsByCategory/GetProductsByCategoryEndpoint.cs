namespace Catalog.API.Products.GetProductsByCategory;

// public record GetProductsByIdRequest();

public record GetProductsByIdResponse(IEnumerable<Product> Products);

public class GetProductsByIdEndpoint : ICarterModule {
    public void AddRoutes(IEndpointRouteBuilder app) {
        app.MapGet("/products/category/{category}", async (string category, ISender sender) => {
                var result = await sender.Send(new GetProductsByCategoryQuery(category));

                var response = result.Adapt<GetProductsByIdResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProductsById")
            .Produces<GetProductsByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products By Category")
            .WithDescription("Get Products By Category");
    }
}