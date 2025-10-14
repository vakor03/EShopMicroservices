﻿namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public record StoreBasketResult(string UserName);

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand> {
    public StoreBasketCommandValidator() {
        RuleFor(x => x.Cart).NotNull().WithMessage("You must provide a shopping cart.");
        RuleFor(x => x.Cart.UserName).NotNull().WithMessage("UserName is required.");
    }
}

internal class StoreBasketCommandHandler(IBasketRepository repository) : ICommandHandler<StoreBasketCommand, StoreBasketResult> {
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken) {
        await repository.StoreBasket(command.Cart, cancellationToken);

        return new StoreBasketResult(command.Cart.UserName);
    }
}