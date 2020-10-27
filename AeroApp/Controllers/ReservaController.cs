﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeroApp.Model;
using AeroApp.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AeroApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {

        private List<Reserva> Reservas = new List<Reserva>();
        private int Id = 1;

        [HttpPost]
        public IActionResult EfetuarReserva(EfetuarReservaRequest request)
        {
            var reserva = new Reserva();
            reserva.Id = Id;
            Id = Id + 1;
            reserva.Documento = request.Documento;
            reserva.VooId = request.VooId;
            reserva.Poltrona = request.Poltrona;

            Reservas.Add(reserva);

            return Ok(reserva);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return null;
        }

        [HttpGet("BuscarPorVoo/{vooId}")]
        public IActionResult BuscarPorVoo(int vooId)
        {
            return null;
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            return null;
        }

        [HttpPut]
        public IActionResult Editar(EfetuarReservaRequest request)
        {
            return null;
        }

        [HttpGet("BuscarPoltronaVazia/{idPoltrona}")]
        public IActionResult BuscarPoltronaVazia(int idPoltrona)
        {
            return null;
        }

    }
}