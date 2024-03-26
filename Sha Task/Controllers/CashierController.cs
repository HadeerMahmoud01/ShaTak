using Microsoft.AspNetCore.Mvc;
using Sha_Task.Models;
using Sha_Task.Services.CashierServices;
using Sha_Task.Services.Invoice;

namespace Sha_Task.Controllers
{
    public class CashierController : Controller
    {
        private readonly ICashierServices _cashier;
        public CashierController(ICashierServices cashier)
        {
            _cashier = cashier;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _cashier.GetALL();

            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var cashier = new Cashier();

            return PartialView("CreateCashierPartial", cashier);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Cashier cashier)
        {



            await _cashier.Add(cashier);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cashier = await _cashier.GetById(id);
            return PartialView("EditCashierPartial", cashier);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Cashier cashier)
        {

            var result = await _cashier.GetById(cashier.Id);
            if (result != null)
            {
                cashier.BranchId= result.BranchId;
                await _cashier.Update(cashier);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult>Details(int id)
        {
            var cashier = await _cashier.GetById(id);
            return PartialView("DetailsCashierPartial", cashier);

        }
        [HttpPost]
        public async Task<IActionResult> Details(Cashier cashierDetails)
        {
            var cashier = await _cashier.GetById(cashierDetails.Id);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _cashier.GetById(Id);
            return PartialView("DeleteCashierPartialView", result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Cashier cashier)
        {
            await _cashier.Delete(cashier.Id);
            return RedirectToAction("Index");
        }
    }
}
