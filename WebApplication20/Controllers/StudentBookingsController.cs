using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication20.Data;
using WebApplication20.Models;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Authorization;
using Document = iTextSharp.text.Document;
using WebApplication20.Migrations.Payment;


namespace WebApplication20.Controllers
{
    public class StudentBookingsController : Controller
    {
        private readonly BookingContext _context;

        public StudentBookingsController(BookingContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: StudentBookings
        public async Task<IActionResult> Index()
        {
            //// Get the email of the currently logged-in user
            //var userEmailAddress = User.Identity.Name;
            //// Filter orders by the logged-in user's email
            //var userStudentBookings = await _context.StudentBooking
            //    .Where(o => o.Email == userEmailAddress)
            //    .ToListAsync();

            //return View(userStudentBookings);


             return View(await _context.StudentBooking.ToListAsync());
        }

        // GET: StudentBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentBooking = await _context.StudentBooking.FirstOrDefaultAsync(m => m.Id == id);
            if (studentBooking == null)
            {
                return NotFound();
            }

            return View(studentBooking);
        }
        [Authorize]
        // GET: StudentBookings/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: StudentBookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Email,PhoneNumber,Gender,RoomType,BookingStartDate,BookingEndDate,RoomNumber,EmergencyContact")] StudentBooking studentBooking)
        {
            
            if (ModelState.IsValid)
            {
               
                _context.Add(studentBooking);
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentBooking);
        }

        // GET: StudentBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentBooking = await _context.StudentBooking.FindAsync(id);
            if (studentBooking == null)
            {
                return NotFound();
            }
            return View(studentBooking);
        }
        [Authorize]
        // POST: StudentBookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Email,PhoneNumber,Gender,RoomType,BookingStartDate,BookingEndDate,RoomNumber,EmergencyContact")] StudentBooking studentBooking)
        {
            if (id != studentBooking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentBookingExists(studentBooking.Id))
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
            return View(studentBooking);
        }
        [Authorize]
        // GET: StudentBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentBooking = await _context.StudentBooking.FirstOrDefaultAsync(m => m.Id == id);
            if (studentBooking == null)
            {
                return NotFound();
            }

            return View(studentBooking);
        }
        [Authorize]
        // POST: StudentBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentBooking = await _context.StudentBooking.FindAsync(id);
            _context.StudentBooking.Remove(studentBooking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentBookingExists(int id)
        {
            return _context.StudentBooking.Any(e => e.Id == id);
        }

        // GET: StudentBookings/DownloadPdf/5
        public async Task<IActionResult> DownloadPdf(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentBooking = await _context.StudentBooking.FirstOrDefaultAsync(m => m.Id == id);
            if (studentBooking == null)
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

                        // Add logo to PDF
                        string logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "studentliving.jpg"); // Adjust path as necessary
                        if (System.IO.File.Exists(logoPath))
                        {
                            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                            logo.ScaleToFit(170f, 160f); // Adjust size as necessary
                            logo.Alignment = Element.ALIGN_CENTER;
                            document.Add(logo);
                        }

                        // Add student details to PDF
                        document.Add(new Paragraph($"Greetings, {studentBooking.Name} {studentBooking.Surname}"));
                        document.Add(new Paragraph(" "));
                        document.Add(new Paragraph("This is your proof of booking with your details and booking details, keep it."));
                        document.Add(new Paragraph(" "));
                        document.Add(new Paragraph(" "));

                        // Create a table for student details
                        PdfPTable detailsTable = new PdfPTable(2);
                        detailsTable.WidthPercentage = 100;
                        detailsTable.AddCell("Field");
                        detailsTable.AddCell("Value");

                        // Add rows for each student detail
                        detailsTable.AddCell("Name:");
                        detailsTable.AddCell(studentBooking.Name);

                        detailsTable.AddCell("Surname:");
                        detailsTable.AddCell(studentBooking.Surname);

                        detailsTable.AddCell("Email:");
                        detailsTable.AddCell(studentBooking.Email);

                        detailsTable.AddCell("Phone Number:");
                        detailsTable.AddCell(studentBooking.PhoneNumber);

                        detailsTable.AddCell("Gender:");
                        detailsTable.AddCell(studentBooking.gender.ToString());

                        detailsTable.AddCell("Room Type:");
                        detailsTable.AddCell(studentBooking.roomType.ToString());

                        detailsTable.AddCell("Booking Start Date:");
                        detailsTable.AddCell(studentBooking.BookingStartDate.ToString());

                        detailsTable.AddCell("Booking End Date:");
                        detailsTable.AddCell(studentBooking.BookingEndDate.ToString());

                        detailsTable.AddCell("Room Number:");
                        detailsTable.AddCell(studentBooking.RoomNumber.ToString());

                        detailsTable.AddCell("Emergency Contact:");
                        detailsTable.AddCell(studentBooking.EmergencyContact);

                        // Add the details table to the document
                        document.Add(detailsTable);

                        // Add additional information
                        document.Add(new Paragraph(" "));
                        document.Add(new Paragraph(" "));
                        document.Add(new Paragraph("Have an opinion? Rate your experience on our feedback page and insert your comment."));
                        document.Add(new Paragraph(" "));
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

            // Return the file with content type
            return File(pdfBytes, "application/pdf", $"proof of Booking_{id}.pdf");
        }

    }
}
