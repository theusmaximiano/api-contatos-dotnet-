using ApiContatos10.Data;
using ApiContatos10.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace ApiContatos10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ContatoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var contatos = await _context.Contatos.ToListAsync();
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPorId(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            if (contato == null)
                return NotFound(new { mensagem = "Contato não encontrado" });

            return Ok(contato);

        }

        [HttpPost]

        public async Task<IActionResult> Criar(Contato contato)
        {
            if (!EmailValido(contato.Email))
                return BadRequest(new { mensagem = "E-mail invalido" });

            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPorId), new { id = contato.Id });
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Atualizar(int id, Contato contato)
        {
            var contatoExistente = await _context.Contatos.FindAsync(id);

            if (contatoExistente == null)
                return BadRequest(new { mensagem = "contato não encontrado" });

            if (!EmailValido(contato.Email))
                return BadRequest(new { mensagem = "E-mail invalido" });

            contatoExistente.Nome = contato.Nome;
            contatoExistente.Telefone = contato.Telefone;
            contatoExistente.Email = contato.Email;
            contatoExistente.Endereco = contato.Endereco;
            contatoExistente.Categoria = contato.Categoria;

            _context.Contatos.Update(contatoExistente);
            await _context.SaveChangesAsync();

            return Ok(contatoExistente);

        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);

            if (contato == null)
                return NotFound(new { mensagem = "contato não encontrado" });

            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool EmailValido(string email) 
        { 
            try
            {
                var mail = new MailAddress(email);
                return true;
            } 
            catch
            {
                return false;
            }
        }

      



    }
}
