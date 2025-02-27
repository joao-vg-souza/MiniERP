using Microsoft.AspNetCore.Mvc;

namespace MiniERP.Infra.API
{
    public class ControllerBaseAPI : ControllerBase
    {
        protected virtual IActionResult ReturnResponse<T>(CommandResponseBase<T> resposta)
        {
            return StatusCode((int)resposta.StatusCode, resposta.Data);
        }

        protected virtual IActionResult ReturnNoContent<T>(CommandResponseBase<T> resposta)
        {
            if (!resposta.Success)
                return StatusCode((int)resposta.StatusCode, resposta);

            return NoContent();
        }
    }
}
