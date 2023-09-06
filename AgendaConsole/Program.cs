using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsole
{
    internal class Program
    {



        //cadastra contatos
        public static void CadastraContatos(Dictionary<string, string> contatos)
        {
            string continuar = "";

            do
            {
                Console.Clear();


                Console.WriteLine("*************************************************");
                Console.WriteLine("************* Adicionando contato ***************");
                Console.WriteLine("*************************************************\n");

                Console.Write("Informe o nome: ");
                string nome = Console.ReadLine();

                Console.Write("Informe o telefone: ");
                string telefone = Console.ReadLine();

                try{
                    Console.WriteLine("------------------------------------------------");
                    contatos.Add(telefone, nome);
                    Console.WriteLine("Contato {0} cadastrado com sucesso! ", nome);

                    Console.Write("Deseja gravar mais algums contato? (s)/(n)");
                    continuar = Console.ReadLine();
                }
                catch(ArgumentException e){
                    Console.WriteLine("O numero de telefone ja exite {0} para outro contato! ", telefone);
                    Console.Write("Deseja gravar mais algums contato? (s)/(n)");
                    continuar = Console.ReadLine();

                }

                if (continuar != "s")
                {
                    continuar = "n";
                }               

            }while(continuar == "s");
               
        }

        public static void MostrarContatos(Dictionary<string, string> contatos)
        {
            Console.Clear();
            Console.WriteLine("*************************************************");
            Console.WriteLine("************* Lista de contatos *****************");
            Console.WriteLine("*************************************************\n");

            foreach (KeyValuePair<string,string> contato in contatos)
            {
                string tel = contato.Key;
                string nome = contato.Value;
                Console.WriteLine("Nome Contato: {0} => telefone: {1}", nome, tel);
            }
            Console.WriteLine("\nPara sair digite qualquer Tecla");
            Console.ReadKey();

        }

        public static void BuscarContato(Dictionary <string, string> contatos)
        {
            string status = "s";

            do
            {
                Console.Clear();

                Console.WriteLine("*************************************************");
                Console.WriteLine("*************   Buscar Contato  *****************");
                Console.WriteLine("*************************************************\n");

                Console.Write("Informe o numero de telefone que deseja buscar o contato: ");
                string tel = Console.ReadLine();

                bool existeContato = contatos.ContainsKey(tel);

                if (existeContato)
                {
                    string contato = contatos[tel];
                    Console.WriteLine("O contato para esse telefone é: {0} => {1}", contato, tel);
                }
                else
                {
                    Console.WriteLine("Não existe contato para esse telefone ! ");

                }

                Console.WriteLine("Deseja buscar outro contato? (s)/(n)");
                status = Console.ReadLine();

            } while (status == "s");

           // Console.ReadKey();

        } 

        public static void AlterarContato(Dictionary<string,string> contatos)
        {

            string status = "s";

            do
            {

                Console.Clear();

                Console.WriteLine("*************************************************");
                Console.WriteLine("*************   AlterarContato  *****************");
                Console.WriteLine("*************************************************\n");

                Console.Write("Para altera um contato digite o numero de telefone: ");
                string telefoneContato = Console.ReadLine();

                bool existeContato = contatos.ContainsKey (telefoneContato);

                if (existeContato)
                {
                    Console.WriteLine("o contato para esse telefone é {0}", contatos[telefoneContato]);

                    Console.Write("Para auterar o nome do contato digite o novo nome: ");
                    string novoNome = Console.ReadLine();

                    contatos[telefoneContato] = novoNome ;

                    Console.WriteLine("Contato atualizado! - nome do contato: {0} => telefone do contato: {1}", contatos[telefoneContato], telefoneContato);
                }
                else
                {
                    Console.WriteLine("Não existe contatos para esse telefone! ");
                }

                Console.Write("Deseja alterar outro contato? (s)/(n): ");
                status = Console.ReadLine();
              

            } while (status == "s");

            
        }

        public static void ExcluirContato(Dictionary<string, string> contatos)
        {
            string status = "s";
            bool contatoExiste = false;
            
            Console.Clear();

            Console.WriteLine("*************************************************");
            Console.WriteLine("*************  Excluir Contato  *****************");
            Console.WriteLine("*************************************************\n");

            Console.Write("Para excluir um contato, informe o telefone dele: ");
            string telefoneContato = Console.ReadLine();

            contatoExiste = contatos.Remove(telefoneContato);

            if (contatoExiste == true)
            {
                Console.WriteLine("Contato excluido com sucesso!! ");
            }
            else
            {
                Console.WriteLine("Não foi possivel excluir o contato, por favor verifique se o número digitado está correto");
            }

            Console.ReadKey();
        }

        public static void LimparListaContatos(Dictionary<string, string> contatos)
        {

            string excluir = "";

            Console.Clear();

            Console.WriteLine("*************************************************");
            Console.WriteLine("*************    Limpar Lista   *****************");
            Console.WriteLine("*************************************************\n");

            Console.WriteLine("Deseja realmente excluir todos os contatos? ");
            Console.Write("Digite (S)sim ou (n)não: ");
            excluir = Console.ReadLine();

            if (excluir == "s")
            {
                contatos.Clear();
                Console.WriteLine("Lista limpa!!! ");
            }
            else
            {
                Console.WriteLine("A lista ainda continua.");
            }
            Console.ReadKey();
            
        }

        static void Main(string[] args)
        {

            int opcao = 0;

            Dictionary<string,string> contatos = new Dictionary<string,string>();

            do
            {
                Console.Clear();

                Console.WriteLine("*************************************************");
                Console.WriteLine("**************Agenda de Contatos*****************");
                Console.WriteLine("*************************************************\n");

                Console.WriteLine("Opções\n");
                Console.WriteLine(" 1) Cadastrar novo contato ");
                Console.WriteLine(" 2) Mostrar lista de contatos ");
                Console.WriteLine(" 3) Consultar contato ");
                Console.WriteLine(" 4) Atualizar contato ");
                Console.WriteLine(" 5) Excluir contato ");
                Console.WriteLine(" 6) Excluir todos os contatos");
                Console.WriteLine(" 7) Sair\n");
                Console.Write("Digite o número da funcionalidade desejada: ");
                try {
                    opcao = Convert.ToInt32(Console.ReadLine());
                } catch {
                    Console.Write("Digite uma opção valida! ");
                    Console.ReadKey();
                }
               



                switch (opcao)
                {
                    case 1:
                        CadastraContatos(contatos);
                        break;
                    case 2:
                        MostrarContatos(contatos);
                        break;
                    case 3:
                        BuscarContato(contatos);
                        break;
                    case 4:
                        AlterarContato(contatos);
                        break;
                    case 5:
                        ExcluirContato(contatos);
                        break;
                    case 6:
                        LimparListaContatos(contatos);
                        break;
                    case 7:
                        Console.WriteLine("Precione qualquer tecla para sair");
                        break;
                    default:
                        Console.Write("Digite uma opção valida! ");
                        Console.ReadKey();
                        break;

                }

            } while (opcao != 7);



            Console.ReadKey();



        }
    }
}
