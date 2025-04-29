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
            int thousand, fiveHundred, twoHundred, oneHundred;
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
                        thousand = vm.Amount / 1000;
                        twoHundred = (vm.Amount % 1000) / 200;
                        BillsRepository.Instance.Bills.Add(new BillViewModel
                        {
                            Thousand = thousand,
                            TwoHundred = twoHundred,
                            Total = vm.Amount
                        });
                    }
                    break;

                case (int)DispenserMode.QuinientosYCien:
                    fiveHundred = vm.Amount / 500;
                    oneHundred = (vm.Amount % 500) / 100;
                    BillsRepository.Instance.Bills.Add(new BillViewModel
                    {
                        FiveHundred = fiveHundred,
                        OneHundred = oneHundred,
                        Total = vm.Amount
                    });
                    break;

                default:
                    thousand = vm.Amount / 1000;
                    fiveHundred = (vm.Amount % 1000) / 500;
                    twoHundred = (vm.Amount % 500) / 200;
                    oneHundred = (vm.Amount % 200) / 100;
                    BillsRepository.Instance.Bills.Add(new BillViewModel
                    {
                        Thousand = thousand,
                        FiveHundred = fiveHundred,
                        TwoHundred = twoHundred,
                        OneHundred = oneHundred,
                        Total = vm.Amount
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
