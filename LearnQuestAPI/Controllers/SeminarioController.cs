﻿using LearnQuestAPI.Models;
using LearnQuestAPI.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearnQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeminarioController : ControllerBase
    {
        private readonly ISeminarioRepository _seminarioRepository;
        public SeminarioController(ISeminarioRepository seminarioRepository)
        {
            _seminarioRepository = seminarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seminario>>> ListarTodosSeminario()
        {
            var seminarios = await _seminarioRepository.ListarTodosSeminario();
            return Ok(seminarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Seminario>> BuscarPorId(int id)
        {
            var seminario = await _seminarioRepository.BuscarPorId(id);
            if (seminario == null)
            {
                return NotFound();
            }
            return Ok(seminario);
        }

        [HttpPost]
        public async Task<ActionResult<Seminario>> CriarSeminario(Seminario seminario)
        {
            try
            {
                var novoSeminario = await _seminarioRepository.CriarSeminario(seminario);
                return CreatedAtAction(nameof(BuscarPorId), new { id = novoSeminario.Id }, novoSeminario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar seminário: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarSeminario(int id, Seminario seminario)
        {
            if (id != seminario.Id)
            {
                return BadRequest("IDs não correspondem");
            }

            try
            {
                await _seminarioRepository.AtualizarSeminario(id, seminario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar seminário: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ApagarSeminario(int id)
        {
            try
            {
                await _seminarioRepository.ApagarSeminario(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao apagar seminário: {ex.Message}");
            }
        }
    }
}
