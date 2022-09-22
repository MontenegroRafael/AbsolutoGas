using System;
using System.Collections.Generic;
using System.Text;
//using Client.Models;
using System.Data.SqlClient;
using System.Linq;
using System.Data;

namespace Client.Menu
{
    public class Listar
    {
        public static void MostarMenu()
        {

            Console.WriteLine("|******************************** Menu ********************************|");
            Console.WriteLine("|___________  Cliente  ____________|_____________  Veículo  ___________|");
            Console.WriteLine("|                                  |                                   |");
            Console.WriteLine("|>>> [ 1  ] - Listar Todos         | >>> [ 5  ] - Listar Todos         |");
            Console.WriteLine("|>>> [ 2  ] - Cadastrar            | >>> [ 6  ] - Cadastrar            |");
            Console.WriteLine("|>>> [ 3  ] - Excluir              | >>> [ 7  ] - Excluir              |");
            Console.WriteLine("|>>> [ 4  ] - Atualizar            | >>> [ 8  ] - Atualizar            |");
            Console.WriteLine("|                                  |                                   |");
            Console.WriteLine("|__________  Motorista  ___________|_____________  Pedido _____________|");
            Console.WriteLine("|                                  |                                   |");
            Console.WriteLine("|>>> [ 9  ] - Listar Todos         |>>> [ 13 ] - Listar Todos          |");
            Console.WriteLine("|>>> [ 10 ] - Cadastrar            |>>> [ 14 ] - Cadastrar             |");
            Console.WriteLine("|>>> [ 11 ] - Excluir              |>>> [ 15 ] - Excluir               |");
            Console.WriteLine("|>>> [ 12 ] - Atualizar            |>>> [ 16 ] - Atualizar             |");
            Console.WriteLine("|                                  |                                   |");
            Console.WriteLine("|___________  Produto  ____________|_____________  Pedido _____________|");
            Console.WriteLine("|                                  |                                   |");
            Console.WriteLine("|>>> [ 17 ] - Listar Todos         |>>> [    ] -                       |");
            Console.WriteLine("|>>> [ 18 ] - Cadastrar            |>>> [    ] -                       |");
            Console.WriteLine("|>>> [ 19 ] - Excluir              |>>> [    ] -                       |");
            Console.WriteLine("|>>> [ 20 ] - Atualizar            |>>> [    ] -                       |");
            Console.WriteLine("|                                  |                                   |");
            Console.WriteLine("|______  Controle de Frota  _______|___________  Finalizar  ___________|");
            Console.WriteLine("|                                  |                                   |");
            Console.WriteLine("|>>> [    ] - Listar Todos         | >>> [ 0  ] - Sair                 |");
            Console.WriteLine("|__________________________________|___________________________________|");
        }
    }
}
