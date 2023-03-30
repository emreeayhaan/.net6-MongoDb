using Microsoft.AspNetCore.Mvc;
using Muvekkil.Collection;
using Muvekkil.Repository;

namespace Muvekkil.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _iuserRepository;
        public UserController(IUserRepository iuserRepository)
        {
            _iuserRepository = iuserRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _iuserRepository.GetAllAsync();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _iuserRepository.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        //User isimli collectina kayıt ekler
        [HttpPost]
        public async Task<IActionResult> Post(User newUser)
        {
            await _iuserRepository.UserAdd(newUser);
            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }

        [HttpPut]
        public async Task<IActionResult> Set(User setUser)
        {
            var people = await _iuserRepository.GetByIdAsync(setUser.Id);
            if (people == null)
                return NotFound();

            await _iuserRepository.SetUser(setUser);
            return NoContent();
        }

        [HttpDelete("{id}/{name}")]
        public async Task<IActionResult> Delete(string id, string name)
        {
            var user = await _iuserRepository.GetByIdAsync(id);
            if (user == null || user.Name != name)
                return NotFound();

            await _iuserRepository.DeleteUser(id, name);
            return NoContent();
        }

    }
}
