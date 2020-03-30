using Xunit;
using Moq;
using Behavioral.CommandPattern.Implementation;
using Behavioral.CommandPattern.Models;
using Behavioral.CommandPattern.Repositories;
using FluentAssertions;
using System;
using System.Collections.Generic;

namespace Behavioral.Tests
{
    public class CommandPattern
    {

        [Fact]
        public void WhenAddingNewProductToCart_ShouldIncreaseStockInCartRepository()
        {
            var productsRepository = new ProductsRepository();
            var cartRepository = new ShoppingCartRepository();

            var cartManager = new CartCommandManager();
            var canon = new Product("EOSR1", "Canon EOS R", 1099);
            
            var addCanonCommand = new AddToCartCommand(
                cartRepository, 
                productsRepository, 
                canon);
            
            cartManager.Execute(addCanonCommand);
            cartManager.Execute(addCanonCommand);
            
            cartRepository.Get("EOSR1").Quantity.Should().Be(2);
        }

        [Fact]
        public void WhenAddingNewProductToCartAndUndoingLast_ShouldDecreaseStockInCartRepository()
        {
            var productsRepository = new ProductsRepository();
            var cartRepository = new ShoppingCartRepository();

            var cartManager = new CartCommandManager();
            var canon = new Product("EOSR1", "Canon EOS R", 1099);
            
            var addCanonCommand = new AddToCartCommand(
                cartRepository, 
                productsRepository, 
                canon);
            
            cartManager.Execute(addCanonCommand);
            cartManager.Execute(addCanonCommand);
            cartManager.UndoLast();
            
            cartRepository.Get("EOSR1").Quantity.Should().Be(1);
        }

        [Fact]
        public void WhenAddingNewProductToCartAndUndoingAll_ShouldDecreaseStockInCartRepository()
        {
            var productsRepository = new ProductsRepository();
            var cartRepository = new ShoppingCartRepository();

            var cartManager = new CartCommandManager();
            var canon = new Product("EOSR1", "Canon EOS R", 1099);
            
            var addCanonCommand = new AddToCartCommand(
                cartRepository, 
                productsRepository, 
                canon);
            
            cartManager.Execute(addCanonCommand);
            cartManager.Execute(addCanonCommand);
            cartManager.UndoAll();
            
            cartRepository.Get("EOSR1").Quantity.Should().Be(0);
        }

        [Fact]
        public void WhenRemovingAddedProduct_ShouldClearProductFromCartAndReturnZeroQuantity()
        {
            var productsRepository = new ProductsRepository();
            var cartRepository = new ShoppingCartRepository();

            var cartManager = new CartCommandManager();
            var canon = new Product("EOSR1", "Canon EOS R", 1099);
            
            var addCanonCommand = new AddToCartCommand(
                cartRepository, 
                productsRepository, 
                canon);

            var removeCanonCommand = new RemoveFromCartCommand(
                cartRepository,
                productsRepository,
                canon
            );
            
            cartManager.Execute(addCanonCommand);
            cartManager.Execute(addCanonCommand);
            cartManager.Execute(removeCanonCommand);
            cartManager.Execute(removeCanonCommand);
            cartManager.Execute(removeCanonCommand);
            
            cartRepository.Get("EOSR1").Quantity.Should().Be(0);
        }

        [Fact]
        public void WhenUndoingRemovingAndAddingProduct_ShouldClearProductFromCartAndReturnZeroQuantity()
        {
            var productsRepository = new ProductsRepository();
            var cartRepository = new ShoppingCartRepository();

            var cartManager = new CartCommandManager();
            var canon = new Product("EOSR1", "Canon EOS R", 1099);
            
            var addCanonCommand = new AddToCartCommand(
                cartRepository, 
                productsRepository, 
                canon);

            var removeCanonCommand = new RemoveFromCartCommand(
                cartRepository,
                productsRepository,
                canon
            );
            
            cartManager.Execute(addCanonCommand);
            cartManager.Execute(addCanonCommand);
            cartManager.Execute(removeCanonCommand);
            cartManager.Execute(removeCanonCommand);
            cartManager.Execute(removeCanonCommand);
            
            cartManager.UndoAll();
            
            cartRepository.Get("EOSR1").Quantity.Should().Be(0);
        }
    }
}