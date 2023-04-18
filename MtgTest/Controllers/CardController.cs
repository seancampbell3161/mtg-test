using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MtgApiManager.Lib.Service;

namespace MtgTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly IMtgServiceProvider _mtgServiceProvider;
        // IMtgServiceProvider serviceProvider = new MtgServiceProvider();

        public CardController(IMtgServiceProvider mtgServiceProvider)
        {
            _mtgServiceProvider = mtgServiceProvider;
        }

        [HttpGet]
        public async Task<ActionResult> FindByIdAsync(string id)
        {
            // ICardService service = serviceProvider.GetCardService();
            // var result = await service.FindAsync(id);
            var result = await _mtgServiceProvider.GetCardService().FindAsync(id);

            return Ok(result.Value);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult> FindByNameAsync(string name)
        {
            var result = await _mtgServiceProvider.GetCardService()
                .Where(x => x.Name, name)
                .AllAsync();

            return Ok(result.Value);
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<ActionResult> GetCardsAsync(int pageNumber, int pageSize)
        {
            var cards = await _mtgServiceProvider.GetCardService()
                .Where(x => x.Page, pageNumber)
                .Where(x => x.PageSize, pageSize)
                .AllAsync();
        
            return Ok(cards);
        }
    }
}
