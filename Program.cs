using System;
using System.Collections.Generic;
using Aula03Colecoes.Models;
using Aula03Colecoes.Models.Enuns;
using System.Linq;

namespace Aula03Colecoes
{
    class Program
    {
        static List<Funcionario> lista = new List<Funcionario>();

        static void Main(string[] args)
        {
            CriarLista();
            ObterPorNome();
            ObterFuncionariosRecentes();
            ObterEstatisticas();
            ValidarSalarioAdmissao();
            ValidarNome();
            ObterPorTipo();

        }

        public static void CriarLista()
        {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 100.000M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Cristiano Ronaldo";
            f2.Cpf = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Messi";
            f3.Cpf = "13579024565";
            f3.DataAdmissao = DateTime.Parse("01/11/2023");
            f3.Salario = 70.000M;
            f3.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Mbappe";
            f4.Cpf = "24658153579";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.000M;
            f4.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f4);

            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Lewa";
            f5.Cpf = "24681035079";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Renato Augusto";
            f6.Cpf = "24068113579";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.000M;
            f6.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f6);
        }

        public static void ExibirLista()
        {
            string dados = "";
            for (int i = 0; i < lista.Count; i++)
            {
                dados += "==============================\n";
                dados += string.Format("Id: {0} \n", lista[i].Id);
                dados += string.Format("Nome: {0} \n", lista[i].Nome);
                dados += string.Format("CPF: {0} \n", lista[i].Cpf);
                dados += string.Format("Admissão: {0:dd/MM/yyyy} \n", lista[i].DataAdmissao);
                dados += string.Format("Salário: {0:c2} \n", lista[i].Salario);
                dados += string.Format("Tipo: {0} \n", lista[i].TipoFuncionario);
                dados += "==============================\n";
            }
            Console.WriteLine(dados);
        }

        public static void ObterPorId()
        {
            lista = lista.FindAll(x => x.Id == 1);
            ExibirLista();
        }

        public static void ObterPorId(int id)
        {
            Funcionario fBusca = lista.Find(x => x.Id == id);

            Console.WriteLine($"Personagem encontrado: {fBusca.Nome}");
        }

        public static void ExemplosListasColecoes()
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("****** Exemplos - Aula 03 Listas e Coleções ******");
                Console.WriteLine("==================================================");
                CriarLista();
                int opcaoEscolhida = 0;
                do
                {
                    Console.WriteLine("==================================================");

                    Console.WriteLine("---Digite o número referente a opção desejada: ---");
                    Console.WriteLine("1 - Obter por Id");
                    Console.WriteLine("2 - Adicionar Funcionário");
                    Console.WriteLine("3 - Obter Por Id Digitado");
                    Console.WriteLine("4 - Obter Por Salário Digitado");
                    Console.WriteLine("==================================================");
                    Console.WriteLine("-----Ou tecle qualquer outro número para sair-----");
                    Console.WriteLine("==================================================");

                    opcaoEscolhida = int.Parse(Console.ReadLine());
                    string mensagem = string.Empty;
                    switch (opcaoEscolhida)
                    {
                        case 1:
                            ObterPorId();
                            break;
                        case 2:
                            AdicionarFuncionario();
                            break;
                        case 3:
                            Console.WriteLine("Digite o Id do funcionário que você deseja buscar: ");
                            int id = int.Parse(Console.ReadLine());
                            ObterPorId(id);
                            break;
                        case 4:
                            Console.WriteLine("Digite o salário para obter todos acima do valor indicado: ");
                            decimal salario = decimal.Parse(Console.ReadLine());
                            ObterPorSalario(salario);
                            break;
                        default:
                            Console.WriteLine("Saindo do sistema...");
                            break;
                    }
                } while (opcaoEscolhida >=1 && opcaoEscolhida <= 10);

                Console.WriteLine("==================================================");
                Console.WriteLine("* Obrigado por utilizar o sistema e volte sempre *");
                Console.WriteLine("==================================================");

            }

            public static void AdicionarFuncionario()
            {
                Funcionario f = new Funcionario();

                Console.WriteLine("Digite o nome: ");
                f.Nome = Console.ReadLine();

                Console.WriteLine("Digite o salário: ");
                f.Salario = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Digite a data de admissão: ");
                f.DataAdmissao = DateTime.Parse(Console.ReadLine());

                if (string.IsNullOrEmpty(f.Nome))
                {
                    Console.WriteLine("O nome deve ser preenchido");
                    return;
                }
                else if (f.Salario == 0)
                {
                    Console.WriteLine("Valor do salário não pode ser 0");
                    return;
                }
                else 
                {
                    lista.Add(f);
                    ExibirLista();
                }
            } 

            public static void ObterPorSalario(decimal valor)
            {
                lista = lista.FindAll(x => x.Salario >= valor);
                ExibirLista();
            }

            public static void Ordenar()
            {
                lista = lista.OrderBy(x => x.Nome).ToList();
                ExibirLista();
            }

            public static void ContarFuncionarios()
            {
                int qtd = lista.Count();
                Console.WriteLine($"Existem {qtd} funcionários.");
            }

            public static void SomarSalarios()
            {
                decimal somatorio = lista.Sum(x => x.Salario);
                Console.WriteLine(string.Format($"A soma dos salários é {0:c2}.", somatorio));
            }

            public static void ExibirAprendizes()
            {

                lista = lista.FindAll(x => x.TipoFuncionario == TipoFuncionarioEnum.Aprendiz);
                ExibirLista();
            }

            public static void BuscarPorNomeAproximado()
            //ToLower transforma os caracteres em minúsculos p/ não ter problema de distinção
            //ToUpper transforma os caracteres em maiúsculos
            {
                lista = lista.FindAll(x => x.Nome.ToLower().Contains("ronaldo"));
                ExibirLista();
            }

            public static void BuscarPorCpfRemover()
            //Filtra um personagem por algum critério removendo o mesmo da lista
            {
                Funcionario fBusca = lista.Find(x => x.Cpf == "01987654321");
                lista.Remove(fBusca);
                Console.WriteLine($"Personagem removido: {fBusca.Nome} \n Lista Atualizada: \n ");
                ExibirLista();
            }

            public static void RemoverIdMenor4()
            //Removendo da lista de acordo com filtragem de Ids
            {
                lista.RemoveAll(x => x.Id < 4);
                ExibirLista();
            }

            //*INICIO DO EXERCÍCIO*
            //a) Método com nome ObterPorNome que selecione um funcionário de acordo com o nome digitado e que, caso não encontre, retorne uma mensagem para o usuário. 
            public static void ObterPorNome()
            {
                Funcionario f = new Funcionario();
                Console.WriteLine("Digite o nome a ser obtido: ");
                f.Nome = Console.ReadLine();  
                string resultado = lista.Find(f => f.Nome == f.Nome).ToString();
 
                if (resultado.Length < 1)
                {
                    Console.WriteLine("O nome deve ser preenchido");
                    return;
                }
                else if (string.IsNullOrEmpty(resultado))
                {   
                    Console.WriteLine("O funcionário não possui registro no banco de dados.");
                    return;
                }
                else 
                {
                    Console.WriteLine($"Nome: {resultado.ToString()}");
                }

            }
            //b) Método com nome ObterFuncionariosRecentes que remova os funcionários com Id menor que 4 e depois faça um filtro na lista para exibi-la em ordem decrescente de Salário.
            public static void ObterFuncionariosRecentes()
            {
            lista.RemoveAll(x => x.Id < 4);
            ExibirLista();
            lista.OrderByDescending(x => x.Salario);
            }
            //c) Método com nome ObterEstatisticas que exiba a quantidade de funcionários da lista e qual o somatório de salário dos funcionários.
            public static void ObterEstatisticas()
            {
            Funcionario busca = new Funcionario();
            busca = lista.FindAll(b => busca.Id);
            decimal somatorio = lista.Sum(x => x.Salario);
            Console.WriteLine(string.Format($"Existem {quantidade} funcionários registrados e a soma dos salários de todos é {0:c2}.", somatorio));
            }
            //d) Método com nome ValidarSalarioAdmissao que não permita que um funcionário seja adicionado com salário 0 ou data de admissão anterior a data atual. Deve ser exibida uma mensagem ao usuário caso isso aconteça
            public static void ValidarSalarioAdmissao()
            {   
              Funcionario f = new Funcionario();

                Console.WriteLine("Digite o salário: ");
                f.Salario = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Digite a data de admissão: ");
                f.DataAdmissao = DateTime.Parse(Console.ReadLine());

                DateTime dataAtual = DateTime.Now;

                if (string.IsNullOrEmpty(f.Salario))
                {
                    Console.WriteLine("O salário deve ser preenchido");
                    return;
                }
                else if (f.Salario == 0)
                {
                    Console.WriteLine("Valor do salário não pode ser 0");
                    return;
                }
                else if (f.DataAdmissao < dataAtual)
                {
                  Console.WriteLine("A data de admissão não pode ser anterior à data atual.");
                return;
                }
                
                else
                {
                    lista.Add(f);
                    ExibirLista();
                }
            }
            //e) Método com nome ValidarNome que não permita que um funcionário tenha nome menor que 2 caracteres. Deve ser exibida uma mensagem ao usuário caso isso aconteça.
            public static void ValidarNome()
            {
            Funcionario f = new Funcionario();
            Console.WriteLine("Digite o nome do funcionário: ");
            f.Nome = Console.ReadLine();

            if (String.Length(f.Nome) < 2)
            {
                Console.WriteLine("O nome do funcionário deve ter mais do que dois caracteres.");
            }
            else
            {
                    lista.Add(f);
                    ExibirLista();
            }
            }
            //f) Método com nome ObterPorTipo que selecione a lista de funcionários de acordo com numeração digitada no console. 
            public static void ObterPorTipo()
            {
            TipoFuncionarioEnum tipo = new TipoFuncionarioEnum();
            Console.WriteLine("Digite o número do tipo de funcionário que deseja obter: 1 para CLT e 2 para APRENDIZ");

            tipo = int.Parse(Console.ReadLine());
            string resultado = lista.FindAll(x => x.TipoFuncionario = tipo.Contains(tipo));
            }



            
    }
}