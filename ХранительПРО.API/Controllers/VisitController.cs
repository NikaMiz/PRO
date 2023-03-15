using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.ComponentModel.DataAnnotations;
using ХранительПРО.Aplication.DTO;
using ХранительПРО.Domain;

namespace ХранительПРО.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        mainContext _context;
        public VisitController(mainContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Registration([FromBody]RegistrationDTO registrationDTO)
        {
            if (registrationDTO == null)
                return BadRequest("Email and password is null");

            var validationResult = new List<ValidationResult>();
            var validationContext = new ValidationContext(registrationDTO);
            if (!Validator.TryValidateObject(registrationDTO, validationContext, validationResult))
            {
                return BadRequest(String.Join('\n', validationResult));
            }

            string login = registrationDTO.Email.Substring(0, registrationDTO.Email.IndexOf('@'));

            User user = await _context.Users.FirstOrDefaultAsync(user => user.Login == login);

            if (user != null)
            {
                return BadRequest("User is exist");
            }

            user = new User() { Login = login, Password = registrationDTO.Password };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return StatusCode(201, new { Login = login });
        }

        [HttpPost]
        public async Task<IActionResult> Authorization([FromBody] AuthorizationDTO authorizationDTO)
        {
            User user = await _context.Users.FirstOrDefaultAsync(user => user.Login == authorizationDTO.Login && user.Password == authorizationDTO.Password);
            
            if (user == null)
                return NotFound("User not found.");

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> GetPersonalVisiting([FromBody]VisitingDTO visitingDTO)
        {
            List<PersonVisiting> personVisitings = _context.PersonVisitings.Where(personVisiting => personVisiting.User.Login == visitingDTO.Login 
            && personVisiting.Employee.Division == visitingDTO.Division 
            && personVisiting.CreatDate == visitingDTO.CreateDate 
            && personVisiting.Status.Id == visitingDTO.StatusId).Include(user => user.User).Include(employee => employee.Employee).Include(status => status.Status).ToList();


            if (personVisitings.Count == 0)
            {
                return NotFound();
            }

            return Ok(personVisitings);
        }

        [HttpPost]
        public async Task<IActionResult> GetGroupVisiting([FromBody]VisitingDTO visitingDTO)
        {
            List<GroupVisiting> groupVisitings = _context.GroupVisitings.Where(groupVisitings => groupVisitings.User.Login == visitingDTO.Login
            && groupVisitings.Group.Employee.Division == visitingDTO.Division
            && groupVisitings.Group.Created == visitingDTO.CreateDate
            && groupVisitings.Status.Id == visitingDTO.StatusId).Include(user => user.User).Include(employee => employee.Group.Employee).Include(status => status.Status).ToList();

            if (groupVisitings.Count == 0)
            {
                return NotFound();
            }

            return Ok(visitingDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonVisiting([FromBody] PersonDTO personDTO)
        {
            User user = await _context.Users.FirstOrDefaultAsync(user => user.Login == personDTO.User.Login && user.Password == personDTO.User.Password);

            if (user == null)
                return NotFound("User not found.");
            Employee employee = await _context.Employees.FirstOrDefaultAsync(employee => employee.Name == personDTO.NameEmployee 
            && employee.SurName == personDTO.SurNameEmployee
            && employee.MiddleName == personDTO.MiddleNameEmployee
            && employee.Division == personDTO.DivisionEmployee);

            if (employee == null)
                return NotFound("Employee not found.");

            PersonVisiting personVisiting = new PersonVisiting()
            {
                Name = personDTO.Name,
                SurName = personDTO.SurName,
                MiddleName = personDTO.MiddleName,
                Telephone = personDTO.Telephone,
                Email = personDTO.Email,
                BirthDay = personDTO.BirthDay,
                Seria = personDTO.Seria,
                Number = personDTO.Number,
                User = user,
                Employee = employee,
                CreatDate = DateTime.Now,
                Status = await _context.Statuses.FirstOrDefaultAsync(status => status.Id == 3)
            };

            await _context.PersonVisitings.AddAsync(personVisiting);
            await _context.SaveChangesAsync();

            return StatusCode(201, new {Message = "Visit added." });

        }

        [HttpPost]
        public async Task<IActionResult> AddGroupVisiting([FromBody] GroupDTO groupDTO)
        {
            User user = await _context.Users.FirstOrDefaultAsync(user => user.Login == groupDTO.User.Login && user.Password == groupDTO.User.Password);

            if (user == null)
                return NotFound("User not found.");

            Employee employee = await _context.Employees.FirstOrDefaultAsync(employee => employee.Name == groupDTO.NameEmployee
            && employee.SurName == groupDTO.SurNameEmployee
            && employee.MiddleName == groupDTO.MiddleNameEmployee
            && employee.Division == groupDTO.DivisionEmployee);

            if (employee == null)
                return NotFound("Employee not found.");

            InfoGroup infoGroup = new InfoGroup() { Created = DateTime.Now, Employee = employee};

            await _context.InfoGroups.AddAsync(infoGroup);

            if (groupDTO.Users.Count() < 5)
            {

            }

            foreach (var userDTO in groupDTO.Users)
            {
                GroupVisiting groupVisiting = new GroupVisiting()
                {

                    Name = userDTO.Name,
                    SurName = userDTO.SurName,
                    MiddleName = userDTO.MiddleName,
                    Telephone = userDTO.Telephone,
                    Email = userDTO.Email,
                    BirthDay = userDTO.BirthDay,
                    Seria = userDTO.Seria,
                    Number = userDTO.Number,
                    User = user,
                    Group = infoGroup,                    
                    Status = await _context.Statuses.FirstOrDefaultAsync(status => status.Id == 3)
                };

                await _context.GroupVisitings.AddAsync(groupVisiting);
            }

            await _context.SaveChangesAsync();

            return StatusCode(201, new { Message = "Visit added" });
        }

    }
}
