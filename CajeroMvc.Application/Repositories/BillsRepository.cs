using CajeroMvc.Application.ViewModels;

namespace CajeroMvc.Application.Repositories
{
    public sealed class BillsRepository
    {
        private BillsRepository() { }

        public static BillsRepository Instance { get; } = new BillsRepository();
        public List<BillViewModel> Bills { get; set; } = new();
    }
}
