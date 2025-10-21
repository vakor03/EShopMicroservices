﻿using Discount.Grpc;

namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public record StoreBasketResult(string UserName);

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand> {
    public StoreBasketCommandValidator() {
        RuleFor(x => x.Cart).NotNull().WithMessage("You must provide a shopping cart.");
        RuleFor(x => x.Cart.UserName).NotNull().WithMessage("UserName is required.");
    }
}

internal class StoreBasketCommandHandler
    (IBasketRepository repository, DiscountProtoService.DiscountProtoServiceClient discountProto)
    : ICommandHandler<StoreBasketCommand, StoreBasketResult> {
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        await DeduceDiscount(command.Cart, cancellationToken);
        await repository.StoreBasket(command.Cart, cancellationToken);

        return new StoreBasketResult(command.Cart.UserName);
    }

    private async Task DeduceDiscount(ShoppingCart shoppingCart, CancellationToken cancellationToken)
    {
        foreach (ShoppingCartItem item in shoppingCart.Items)
        {
            var discount = await discountProto.GetDiscountAsync(new GetDiscountRequest(){ProductName = item.ProductName}, cancellationToken: cancellationToken);
            item.Price -= discount.Amount;
        }
    }
}