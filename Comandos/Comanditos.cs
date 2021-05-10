using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DSharpPlus;
using System.Timers;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;
using System.Threading;
using DSharpPlus.Entities;
using System.Runtime.CompilerServices;

namespace Bot_Discord.Comandos
{
    public class Comanditos
    {
        private string[] cuentos = { "Hola choricillo mio en quedamos con pollas de la semana pasada en el trabajo",
        "El otro día me dijiste lo de la puta de la foto de la semana que viene y me dice que no se te olvide",
        "No se si lo decias para que me pase lo del cocodrilo y te cuento que no tengo ni idea de que es lo espectacular de todo",
        "Y el domingo igual que me la sopla lo que me digan a mi tío y que no me gusta lo queria de los datos del paro de la tarde",
        "El barsa ganará la liga",
        "Que no me moleste con lo de la factura de la luz.",
        "Si no le gusta el nuevo nombre de usuario y contraseña anteriores para obtener más de un emulador de Nintendo DS y el de la Terra.Si no le gusta el nuevo nombre de usuario y contraseña anteriores para obtener más de un emulador de Nintendo DS y el de la Terra.",
        "Vais a morir todos",
        "Deberían ser los mejores para mi y para mi es un gran reto para mi y para mi ser mi pareja y mi familia y amigos de verdad que no me acuerdo de ti y de que te amo tanto como yo no soy así y no me gusta nada de nada y tu eres mi amor y mi amor te amo mucho mucho mucho mucho mucho mucho mucho mucho mucho y espero que no te he mandado nada de mi parte a la tarde te escribo para saber si te interesa o no te interesa el tema de la miseria humana",
        "POLEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE",
        "Y el pan y el viernes y sábado de la entrevista que le ha pasado a la espera de su sistema y avisar al remitente",
        "Lo mejor de ser feminista es que es el mejor precio del alquiler",
        "Lo mejor de ser feminista es que te pueden comer el roscón de reyes, mientras tienes al fuego unas lentejas de puta madre. Yo recuerdo uno que conocí en un eroski, y lo recuerdo como uno de los mejores polvos de mi vida. Hice unos callos cojonudisisimos, y mientras los preparaba, me daba como un cabrón por el ojete, ya que me había puesto faldita para que fuese haciendo mientras cocinaba. Creo que eyaculó tal cantidad de esperma, que estuvo dos horas inconsciente. Menos mal que los callos le dieron fuerza para acabar el día con un par más. Y como tengo unos hijos majísimos. Menudos vicios echaron al crash bandicoot 2.",
        "Tengo eso desactivado",
        "comprate un teclado nuevo",
        "QUE ME HE VUELTO LOCOOO, QUE ME HE VUELTO LOCOOO!!!",
        "Los de la paella son los mas gilipollas",
        "Me gasté 100 en jamon ibérico de bellota ayer",
        "Acabo de despertarme de la siesta, cuando me espabile te lo cuento."};
        private bool aireAcondicionado = false;
        private bool cabalgata = false;

        private static System.Timers.Timer timer;

        private static void terminarCabalgata()
        {
            timer.Stop();
            
        }
        private static void empezarCabalgata(CommandContext ctx)
        {
            
            //temporizador con 3 segundos de delay
            timer = new System.Timers.Timer(4000);
            //timer.Elapsed += elapsedCabalgata;
            timer.Elapsed += (sender, e) => elapsedCabalgata(sender, e, ctx);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static async void elapsedCabalgata(Object source, ElapsedEventArgs e, CommandContext ctx)
        {            
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",e.SignalTime);
            await repartirCaramelosYRegalos(ctx);
            
        }

        private static async Task repartirCaramelosYRegalos(CommandContext ctx)
        {
            Random randomN = new Random();
            int numeroRandom;
            string regaloParaLanzar = "";
            numeroRandom = randomN.Next(1, 101);
            Console.WriteLine(numeroRandom);

            if(numeroRandom >=1 && numeroRandom <= 10)
            {
                regaloParaLanzar = "peluche";
                Lanzar(ctx,regaloParaLanzar);
            }

            if(numeroRandom > 10 && numeroRandom <= 30)
            {
                regaloParaLanzar = "balón";
                Lanzar(ctx,regaloParaLanzar);
            }

            if(numeroRandom > 40 && numeroRandom <= 100)
            {
                regaloParaLanzar = "puñao de caramelos";
                Lanzar(ctx,regaloParaLanzar);
            }


        }

        private static async Task Lanzar(CommandContext ctx, string regaloParaLanzar)
        {
            await ctx.Channel.SendMessageAsync($"Allá va un {regaloParaLanzar}!!");


        } 

        [Command("cabalgata")]
        public async Task Cabalgata(CommandContext ctx)
        {

            //Console.WriteLine(ctx.Message.Author.Username);
            //Console.WriteLine(ctx.Message.Author.Id);
            //Console.WriteLine(ctx.Message.Author);
            if (ctx.Message.Author.Id == 281908889333530626 && cabalgata == false)
            {
                cabalgata = true;
                await ctx.Channel.SendMessageAsync("Aquí llega la ilusión!!");
                empezarCabalgata(ctx);
            }
            else
            {
                if(ctx.Message.Author.Id == 281908889333530626 && cabalgata == true)
                {
                    cabalgata = false;
                    terminarCabalgata();
                }
            }            



        }

        [Command("cuento")]
        public async Task Cuento(CommandContext ctx)
        {
            Random r = new Random();
            int numeroRandom = r.Next(1,cuentos.Length);
            
            string fraseRandom = cuentos[numeroRandom];
            Console.WriteLine(numeroRandom.ToString() + fraseRandom);

            await ctx.Channel.SendMessageAsync(fraseRandom).ConfigureAwait(false);
        }

        [Command("uwu")]
        public async Task Uwu(CommandContext ctx)
        {
            string nombreUsuario = ctx.Message.Author.Mention;

            string respuesta = "¿Tú me has dicho uwu? " + nombreUsuario;
            await ctx.Channel.SendMessageAsync(respuesta);
            var interaccion = ctx.Client.GetInteractivityModule();
            var interaccionUsuario = await interaccion.WaitForMessageAsync(x => x.Channel == ctx.Channel && x.Author == ctx.User).ConfigureAwait(false);
            string respuestaUsuario = interaccionUsuario.Message.Content;
            respuestaUsuario = respuestaUsuario.ToLower();

            if(respuestaUsuario == "si" || respuestaUsuario == "sí" || respuestaUsuario == "zi" || respuestaUsuario == "zí" || respuestaUsuario == "ji" || respuestaUsuario == "jí")
            {
                await ctx.Channel.SendFileAsync("../../../Fotos/uwu.jpg").ConfigureAwait(false);
            }
            else
            {
                if(respuestaUsuario == "no" || respuestaUsuario == "nu")
                {
                    await ctx.Channel.SendMessageAsync("Así me gusta.").ConfigureAwait(false);
                    await ctx.Channel.SendFileAsync("../../../Fotos/pingu.jpg").ConfigureAwait(false);
                   
                }
                else
                {
                    await ctx.Channel.SendMessageAsync("Aquí no ha pasado nada").ConfigureAwait(false);
                }
            }
        }


        [Command("dado")]
        public async Task Dado (CommandContext ctx)
        {
            Random r = new Random();
            int resultado = r.Next(1,7);
            await ctx.Channel.SendMessageAsync(resultado.ToString()).ConfigureAwait(false);
        }

        [Command("juanca")]
        public async Task Juanca(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Juanca manco").ConfigureAwait(false);
        }

        [Command("comida")]
        public async Task PedidoTaco(CommandContext ctx)
        {
            string mencionUsuario = ctx.Message.Author.Username;
            string avatarUsuario = ctx.Message.Author.AvatarUrl;

            var embed = new DiscordEmbedBuilder
            {
                Title = "¡Hola, " + mencionUsuario + "! ¿Qué menú vas a pedir?",
                Color = DiscordColor.Orange,
                ThumbnailUrl = avatarUsuario,
                Description = "1.- Burrito \n" +
                "2.- Quesarito con patatas \n" +
                "3.- CrunchyWrap con patatas \n" +
                "4.- Sorpresa ;)"
            };

            var pedidoEmbed = await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);


            var interaccion = ctx.Client.GetInteractivityModule();

            var numeromenu = await interaccion.WaitForMessageAsync(x => x.Channel == ctx.Channel && x.Author == ctx.User).ConfigureAwait(false);

            var usuarioQueResponde = numeromenu.User.Username;
            
                switch (numeromenu.Message.Content)
                {
                    case "1":
                        await ctx.Channel.SendMessageAsync("Aquí tienes tu pedido!");
                        await ctx.Channel.SendFileAsync("../../../Fotos/burrito.png");
                        break;
                    case "2":
                        await ctx.Channel.SendMessageAsync("Aquí tienes tu pedido!");
                        await ctx.Channel.SendFileAsync("../../../Fotos/quesarito.jpg");
                        break;
                    case "3":
                        await ctx.Channel.SendMessageAsync("Aquí tienes tu pedido!");
                        await ctx.Channel.SendFileAsync("../../../Fotos/crunch.jpg");
                        break;
                    case "4":
                        await ctx.Channel.SendMessageAsync("Aquí tienes tu pedido!");
                        Random ra = new Random();
                        int pedidoAleaotorio = ra.Next(1, 11);
                        await ctx.Channel.SendFileAsync("../../../Fotos/" + pedidoAleaotorio + ".jpg");
                        break;
                }
        }

        [Command("airecito")]
        public async Task EncenderAire(CommandContext ctx)
        {
            string[] comandoAire = ctx.Message.Content.Split(' ');

            if(comandoAire.Length <= 2)
            {
                if (comandoAire[1] == "off")
                {
                    Console.WriteLine(aireAcondicionado);
                    if (aireAcondicionado == false)
                    {
                        await ctx.Channel.SendMessageAsync("El aire ya está apagado.");
                    }
                    else
                    {
                        await ctx.Channel.SendMessageAsync("Apagando aire");
                        aireAcondicionado = false;
                    }
                }
                else
                {
                    if (aireAcondicionado == false) { 
                    int temperaturaAireAcondicionado;
                    try
                    {
                        temperaturaAireAcondicionado = Int32.Parse(comandoAire[1]);
                        aireAcondicionado = true;
                        await ctx.Channel.SendMessageAsync("Encendiendo el aire a " + comandoAire[1] + "ºC");
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                    }
                    else
                    {
                        await ctx.Channel.SendMessageAsync("El aire ya está encendido");
                    }
                }

            }

        }
    }
}
