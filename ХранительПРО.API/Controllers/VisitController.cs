using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
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

            user = new User() { Login = login, Password = Encode(registrationDTO.Password) };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return StatusCode(201, new { Login = login });
        }

        [HttpGet]
        public async Task<IActionResult> Authorization([FromBody] AuthorizationDTO authorizationDTO)
        {
            User user = await _context.Users.FirstOrDefaultAsync(user => user.Login == authorizationDTO.Login && user.Password == authorizationDTO.Password);
            
            if (user == null)
                return NotFound("User not found.");

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonalVisiting(VisitingDTO visitingDTO)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetGroupVisiting(VisitingDTO visitingDTO)
        {
            return Ok();
        }

        public string Encode(string original)
        {
            var md5 = MD5.Create();
            var originalBytes = Encoding.Default.GetBytes(original);
            var encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes);
        }

    }
}
