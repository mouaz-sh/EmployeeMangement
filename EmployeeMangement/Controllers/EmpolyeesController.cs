using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeMangement.Data;
using EmployeeMangement.Models;
using EmployeeMangement.ViewModels.Empolyee;
using System.Diagnostics.Metrics;
using System.Net.Mail;
using System.Net;

namespace EmployeeMangement.Controllers
{
    public class EmpolyeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpolyeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Empolyees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.empolyees.Include(e => e.department).Select(e => new DetailsEmpVm
            {

                Id = e.Id,
                FirstName = e.FirstName,
                MiddleName = e.MiddleName,
                LastName = e.LastName,
                Address = e.Address,
                EmailAddress = e.EmailAddress,
                PhoneNumber = e.PhoneNumber,
                Country = e.Country,
                DateOfBirth = e.DateOfBirth,
                Designation = e.department.Designation,
                CreatedById=e.CreatedById,
                CreatedOn=e.CreeatedOn,
                ModifiedById=e.ModifiedById,
                ModifiedOn=e.ModifiedOn
                
            });


            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Empolyees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empolyee = await _context.empolyees
                .Include(e => e.department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empolyee == null)
            {
                return NotFound();
            }

            return View(new DetailsEmpVm
            {
                Id = empolyee.Id,
                FirstName = empolyee.FirstName,
                MiddleName = empolyee.MiddleName,
                LastName = empolyee.LastName,
                Address = empolyee.Address,
                EmailAddress = empolyee.EmailAddress,
                PhoneNumber = empolyee.PhoneNumber,
                Country = empolyee.Country,
                DateOfBirth = empolyee.DateOfBirth,
                Designation = empolyee.department.Designation,
                CreatedById=empolyee.CreatedById,
                CreatedOn=empolyee.CreeatedOn,
                ModifiedById=empolyee.ModifiedById,
                ModifiedOn=empolyee.ModifiedOn
            });
        }

        // GET: Empolyees/Create
        public IActionResult Create()
        {
            ViewData["departmentId"] = _context.Set<Department>().Select(d => new SelectListItem(d.Designation, d.Id.ToString())).ToList();
            return View();
        }

        // POST: Empolyees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmpVm employee)
        {
            ViewData["departmentId"] = _context.Set<Department>().Select(d => new SelectListItem(d.Designation, d.Id.ToString())).ToList();
            var AddEmpolyee = new Empolyee
            {
                Id = employee.Id,
                EmpNo=employee.EmpNo,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Address = employee.Address,
                EmailAddress = employee.EmailAddress,
                PhoneNumber = employee.PhoneNumber,
                Country = employee.Country,
                DateOfBirth = employee.DateOfBirth,
                departmentId = employee.departmentId,
                CreatedById = User.Identity.Name,
                CreeatedOn = DateTime.Now,
               

            };
            if (ModelState.IsValid)
            {
                _context.Add(AddEmpolyee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        // GET: Empolyees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            ViewData["departmentId"] = _context.Set<Department>().Select(d => new SelectListItem(d.Designation, d.Id.ToString())).ToList();
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.empolyees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(new EditEmpVm
            {
                Id = employee.Id,
                EmpNo=employee.EmpNo,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Address = employee.Address,
                EmailAddress = employee.EmailAddress,
                PhoneNumber = employee.PhoneNumber,
                Country = employee.Country,
                DateOfBirth = employee.DateOfBirth,
                departmentId = employee.departmentId,
               
                ModifiedById = employee.ModifiedById,
                ModifiedOn = employee.ModifiedOn

            });
        }

        // POST: Empolyees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditEmpVm empolyee)
        {
            var EditEmpolyee = _context.Set<Empolyee>().FirstOrDefault(e => e.Id == empolyee.Id);
            EditEmpolyee.Id = empolyee.Id;
            EditEmpolyee.EmpNo = empolyee.EmpNo;
            EditEmpolyee.FirstName = empolyee.FirstName;
            EditEmpolyee.MiddleName = empolyee.MiddleName;
            EditEmpolyee.LastName = empolyee.LastName;
            EditEmpolyee.Address = empolyee.Address;
            EditEmpolyee.EmailAddress = empolyee.EmailAddress;
            EditEmpolyee.PhoneNumber = empolyee.PhoneNumber;
            EditEmpolyee.Country = empolyee.Country;
            EditEmpolyee.DateOfBirth = empolyee.DateOfBirth;
            EditEmpolyee.departmentId = empolyee.departmentId;
            
            EditEmpolyee.ModifiedById = User.Identity.Name;
            EditEmpolyee.ModifiedOn = DateTime.Now;



            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(EditEmpolyee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpolyeeExists(empolyee.Id))
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
            
            return View(empolyee);
        }

        // GET: Empolyees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empolyee = await _context.empolyees
                .Include(e => e.department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empolyee == null)
            {
                return NotFound();
            }

            return View(empolyee);
        }

        // POST: Empolyees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empolyee = await _context.empolyees.FindAsync(id);
            if (empolyee != null)
            {
                _context.empolyees.Remove(empolyee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpolyeeExists(int id)
        {
            return _context.empolyees.Any(e => e.Id == id);
        }
    }
}
