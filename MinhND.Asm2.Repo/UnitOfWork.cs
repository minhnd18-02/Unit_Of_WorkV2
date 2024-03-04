using MinhND.Asm2.Repo;
using MinhND.Asm2.Repo.Models;


namespace MinhND.Asm2.Repo
{
    public class UnitOfWork : IDisposable
    {
        private PizzaStoreContext _context;
        private GenericRepository<Account> _accountRepo;
        private GenericRepository<Product> _productRepo;
        private GenericRepository<Category> _categoryRepo;

        public UnitOfWork(PizzaStoreContext context)
        {
           _context = context;
        }

        public GenericRepository<Account> AccountRepository
        {
            get
            {

                if (this._accountRepo == null)
                {
                    this._accountRepo = new GenericRepository<Account>(_context);
                }
                return _accountRepo;
            }
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {

                if (this._productRepo == null)
                {
                    this._productRepo = new GenericRepository<Product>(_context);
                }
                return _productRepo;
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {

                if (this._categoryRepo == null)
                {
                    this._categoryRepo = new GenericRepository<Category>(_context);
                }
                return _categoryRepo;
            }
        }

        public void Complete()
        {
             _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
