using CajeroMvc.Application.Enums;
using CajeroMvc.Application.Repositories;
using CajeroMvc.Application.ViewModels;

namespace CajeroMvc.Application.Services
{
    public class CalculateAmountService
    {
        public bool Calculate(CreateBillViewModel vm)
        {
            bool success = true;
            int thousand, fiveHundred, twoHundred, oneHundred, total;
            if (vm.Amount % 100 != 0 || vm.Amount < 100)
            {
                success = false;
                return success;
            }
            switch (vm.Mode)
            {
                case (int)DispenserMode.MilYDoscientos:
                    if (vm.Amount % 200 != 0)
                    {
                        success = false;
                    }
                    else
                    {
                        total = vm.Amount;
                        thousand = vm.Amount / 1000;
                        twoHundred = (vm.Amount % 1000) / 200;
                        BillsRepository.Instance.Bills.Add(new BillViewModel
                        {
                            Thousand = thousand,
                            TwoHundred = twoHundred,
                            Total = total
                        });
                    }
                    break;

                case (int)DispenserMode.QuinientosYCien:
                    total = vm.Amount;
                    fiveHundred = vm.Amount / 500;
                    oneHundred = (vm.Amount % 500) / 100;
                    BillsRepository.Instance.Bills.Add(new BillViewModel
                    {
                        FiveHundred = fiveHundred,
                        OneHundred = oneHundred,
                        Total = total
                    });
                    break;

                default:
                    total = vm.Amount;
                    thousand = vm.Amount / 1000;
                    vm.Amount = vm.Amount - (thousand * 1000);
                    fiveHundred = vm.Amount / 500;
                    vm.Amount = vm.Amount - (fiveHundred * 500);
                    twoHundred = vm.Amount / 200;
                    vm.Amount = vm.Amount - (twoHundred * 200);
                    oneHundred = vm.Amount / 100;
                    BillsRepository.Instance.Bills.Add(new BillViewModel
                    {
                        Thousand = thousand,
                        FiveHundred = fiveHundred,
                        TwoHundred = twoHundred,
                        OneHundred = oneHundred,
                        Total = total
                    });
                    break;
            }
            return success;
        }

        public List<BillViewModel> GetAll()
        {
            return BillsRepository.Instance.Bills;
        }
    }
}
