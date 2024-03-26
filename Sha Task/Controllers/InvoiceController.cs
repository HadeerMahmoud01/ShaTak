using Microsoft.AspNetCore.Mvc;
using Sha_Task.Base;
using Sha_Task.Models;
using Sha_Task.Services.Invoice;

namespace Sha_Task.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceservices _invoiceDetail;
        public InvoiceController(IInvoiceservices invoicedetails)
        {
            _invoiceDetail = invoicedetails;
        }
        public async Task<IActionResult> Index()
        {
          var result= await _invoiceDetail.GetByItem();

            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var invoice=new InvoiceDetail();

            return PartialView("InvoicePartial",invoice);
        }
        [HttpPost]
        public async Task<IActionResult> Create(InvoiceDetail invoice)
        {
            
            
           
            await _invoiceDetail.Add(invoice);

            return RedirectToAction("Index");   

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var invoice=await _invoiceDetail.GetById(id);
            return PartialView("EditInvoicePartial", invoice);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(InvoiceDetail invoice)
        {

            var result= await _invoiceDetail.GetById((int)invoice.Id);
            if (result != null)
            {
                invoice.InvoiceHeaderId = result.InvoiceHeaderId;
                await _invoiceDetail.Update(invoice);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _invoiceDetail.GetById(Id);
            return PartialView("DeletePartialView", result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(InvoiceDetail invoice)
        {
            await _invoiceDetail.Delete((int)invoice.Id);
            return RedirectToAction("Index");
        }
    }
}
