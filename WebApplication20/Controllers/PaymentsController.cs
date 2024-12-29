using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using WebApplication20.Data;
using WebApplication20.Models;


using Microsoft.AspNetCore.Authorization;
using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text.pdf;
using Paragraph = iTextSharp.text.Paragraph;
using Document = iTextSharp.text.Document;


namespace WebApplication20.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly PaymentContext _context;

        public PaymentsController(PaymentContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: Payments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Payment.ToListAsync());
        }
        public async Task<IActionResult> success()
        {
            return View();
        }
        [Authorize]
        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }
        [Authorize]
        // GET: Payments/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Email,CardNumber,ExpiryDate,CVV,Amount,PaymentDate")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(payment);
        }
        [Authorize]
        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }
        [Authorize]
        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Email,CardNumber,ExpiryDate,CVV,Amount,PaymentDate")] Payment payment)
        {
            if (id != payment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(payment);
        }
        [Authorize]
        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }
        [Authorize]
        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = await _context.Payment.FindAsync(id);
            if (payment != null)
            {
                _context.Payment.Remove(payment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
            return _context.Payment.Any(e => e.Id == id);
        }

        public async Task<IActionResult> DownloadPdf(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment.FirstOrDefaultAsync(m => m.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            // Generate PDF
            byte[] pdfBytes;
            using (var stream = new MemoryStream())
            {
                using (var document = new Document())
                {
                    using (var writer = PdfWriter.GetInstance(document, stream))
                    {
                        document.Open();
                        // Add text to the PDF document
                        // Add logo to PDF
                        string logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "studentliving.jpg"); // Adjust path as necessary
                        if (System.IO.File.Exists(logoPath))
                        {
                            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                            logo.ScaleToFit(170f, 160f); // Adjust size as necessary
                            logo.Alignment = Element.ALIGN_CENTER;
                            document.Add(logo);
                        }
                        document.Add(new Paragraph($"Hello, {payment.FullName}"));
                        document.Add(new Paragraph($"You successfully paid R {payment.Amount.ToString()} to Student living for the following transaction:"));
                        document.Add(new Paragraph($" "));
                        document.Add(new Paragraph($" "));
                        // Create a table with 2 columns
                        var table = new PdfPTable(2);

                        // Set the width of the table columns
                        float[] columnWidths = { 2f, 3f };
                        table.SetWidths(columnWidths);

                        // Add payment details to the table
                        
                        

                        table.AddCell(new PdfPCell(new Phrase("Reference Number")));
                        table.AddCell(new PdfPCell(new Phrase(payment.Id.ToString())));

                        table.AddCell(new PdfPCell(new Phrase("Full Name")));
                        table.AddCell(new PdfPCell(new Phrase(payment.FullName)));

                        table.AddCell(new PdfPCell(new Phrase("Email")));
                        table.AddCell(new PdfPCell(new Phrase(payment.Email)));

                        table.AddCell(new PdfPCell(new Phrase("Amount")));
                        table.AddCell(new PdfPCell(new Phrase(payment.Amount.ToString())));

                        // Add the table to the document
                        document.Add(table);
                        document.Add(new Paragraph($" "));
                        document.Add(new Paragraph($" "));
                        document.Add(new Paragraph($"Have an option ? Rate your experience on our feed back page and insert your comment. "));
                        document.Add(new Paragraph($" "));
                        document.Add(new Paragraph("For any queries, please contact our assistance at StudentLiving@gmail.com or dial 0767319073."));
                        document.Add(new Paragraph(" "));
                        document.Add(new Paragraph("Best Regards"));
                        document.Add(new Paragraph("StudentLiving Support"));
                        document.Close();
                    }
                }

                // Get the bytes of the generated PDF
                pdfBytes = stream.ToArray();
            }

            // Return the file with content type.
            return File(pdfBytes, "application/pdf", $"Payment_Details_{id}.pdf");
        }

    }
    
}
