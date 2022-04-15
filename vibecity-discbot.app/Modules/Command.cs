using Discord.Commands;
using System.Threading.Tasks;
using vibecity_discbot.service.Service;

namespace vibecity_discbot.app.Modules
{
    public class Command : ModuleBase<SocketCommandContext>
    {
        private readonly IUserService _userService;
        private readonly IPointService _pointService;

        public Command(IUserService userService, IPointService pointService)
        {
            _userService = userService;
            _pointService = pointService;
        }

        [Command("point_on")]
        public async Task PointOn()
        {
            //await ValidationChannelPermission(new string[] { "bate-papo" });

            var user = await _userService.GetByNameAsync(Context.Message.Author.Username);
            if (user == null)
            {
                await ReplyAsync("Usuário não existe, favor contactar o administrador");
                return;
            }

            var point = await _pointService.InsertAsync(user);

            await ReplyAsync(Context.Message.Author.ToString());
        }

        [Command("point_off")]
        public async Task PointOff()
        {

        }

        //private async Task ValidationChannelPermission(string[] channel)
        //{
        //    if (!Context.Message.Channel.Name.ToUpper().Contains(channel))
        //    {
        //        await ReplyAsync("Comando inválido para este canal!");
        //        return;
        //    }
        //}
    }
}
