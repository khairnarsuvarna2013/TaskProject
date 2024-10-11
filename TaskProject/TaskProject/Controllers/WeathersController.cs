using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskProject.Client.Models;
using TaskProject.Data;

namespace TaskProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        private readonly WeatherDbContext _context;

        public WeathersController(WeatherDbContext context)
        {
            _context = context;
        }

        // GET: api/Weathers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weather>>> GetWeather()
        {
            return await _context.Weather.ToListAsync();
        }

        // GET: api/Weathers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weather>> GetWeather(int id)
        {
            var weather = await _context.Weather.FindAsync(id);

            if (weather == null)
            {
                return NotFound();
            }

            return weather;
        }

        // PUT: api/Weathers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeather(int id, Weather weather)
        {
            if (id != weather.WId)
            {
                return BadRequest();
            }

            _context.Entry(weather).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Weathers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //Singel row insert
        //public async Task<ActionResult<Weather>> PostWeather(Weather weather)
        //{
        //    _context.Weather.Add(weather);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetWeather", new { id = weather.WId }, weather);
        //}

        //multirow insert
        public async Task<ActionResult> PostWeatherBatch(List<Weather> weatherList)
        {
            if (weatherList == null || !weatherList.Any())
            {
                return BadRequest("No weather data received.");
            }

            try
            {
                _context.Weather.AddRange(weatherList);
                await _context.SaveChangesAsync();

                return Ok(); // Return success response
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Error saving data: {ex.Message}" });
            }
        }

        // DELETE: api/Weathers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeather(int id)
        {
            var weather = await _context.Weather.FindAsync(id);
            if (weather == null)
            {
                return NotFound();
            }

            _context.Weather.Remove(weather);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherExists(int id)
        {
            return _context.Weather.Any(e => e.WId == id);
        }
    }
}
