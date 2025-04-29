using CajeroMvc.Application.Enums;

namespace CajeroMvc.Application.Repositories
{
    public sealed class ModeRepository
    {
        private ModeRepository() { }

        public static ModeRepository Instance { get; } = new ModeRepository();

        public DispenserMode DispenserMode { get; set; } = DispenserMode.Eficiente;
    }
}
