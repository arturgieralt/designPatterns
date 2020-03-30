using Behavioral.CommandPattern.Base;
using Behavioral.CommandPattern.Models;
using Behavioral.CommandPattern.Repositories;

namespace Behavioral.CommandPattern.Implementation
{
    public class AddToCartCommand : ICommand
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;
        private readonly Product product;

        public AddToCartCommand(IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository,
            Product product)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
            this.product = product;
        }

        public bool CanExecute()
        {
            return productRepository.GetStockFor(product.ArticleId) > 0;
        }

        public void Execute()
        {
            productRepository.DecreaseStockBy(product.ArticleId, 1);
            shoppingCartRepository.Add(product);
        }

        public bool CanUndo()
        {
           return shoppingCartRepository.Get(product.ArticleId).Quantity > 0;
        }

        public void Undo()
        {
            var lineItem = shoppingCartRepository.Get(product.ArticleId);

            productRepository.IncreaseStockBy(product.ArticleId, lineItem.Quantity);
            shoppingCartRepository.RemoveAll(product.ArticleId);
        }
    }
}
