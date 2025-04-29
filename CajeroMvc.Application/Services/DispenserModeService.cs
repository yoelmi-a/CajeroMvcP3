using CajeroMvc.Application.Enums;
using CajeroMvc.Application.Repositories;

namespace CajeroMvc.Application.Services
{
    public class DispenserModeService
    {
        public DispenserMode GetDispenserMode()
        {
            return ModeRepository.Instance.DispenserMode;
        }

        public void SetDispenserMode(int mode)
        {
            if (mode <= 3 && mode >= 1)
            {
                ModeRepository.Instance.DispenserMode = (DispenserMode)mode;
            }
        }
    }
}
