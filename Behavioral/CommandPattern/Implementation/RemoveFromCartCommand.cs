using Behavioral.CommandPattern.Base;
using Behavioral.CommandPattern.Models;
using Behavioral.CommandPattern.Repositories;
using System;

namespace Behavioral.CommandPattern.Implementation
{
    public class RemoveFromCartCommand : ICommand
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;
        private readonly Product product;

        public RemoveFromCartCommand(IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository,
            Product product)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
            this.product = product;
        }

        public bool CanExecute()
        {
            return shoppingCartRepository.Get(product.ArticleId).Quantity > 0;
        }

        public void Execute()
        {
            var lineItem = shoppingCartRepository.Get(product.ArticleId);

            productRepository.IncreaseStockBy(product.ArticleId, 1);
            shoppingCartRepository.Remove(product.ArticleId);
        }

        public bool CanUndo()
        {
            return productRepository.GetStockFor(product.ArticleId) > 0;
        }

        public void Undo()
        {
            productRepository.DecreaseStockBy(product.ArticleId, 1);
            shoppingCartRepository.Add(product);
        }
    }
}
